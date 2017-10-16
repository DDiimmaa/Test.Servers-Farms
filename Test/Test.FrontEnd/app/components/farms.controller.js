(function () {
    'use strict';

    angular
        .module('app.Farms')
        .controller('farmsController', farmsController);

    farmsController.$inject = ['$scope', '$filter', '$state', 'farmsFactory'];

    function farmsController($scope, $filter, $state, farmsFactory) {
        var fvm = this;
        fvm.Farms = [];
        fvm.RefreshFarm = refreshFarm;
        fvm.RefreshServer = refreshServer;
        fvm.GlobalError = null;
        fvm.Timers = {};

        activate();

        function activate() {
            resetControllerProperties();
            //get farms
            farmsFactory.getAllFarms().then(
                    function (data) {
                        fvm.Farms = data.data;
                        
                        $.each(fvm.Farms, function(index, farm) {
                            refreshFarm(farm, false);
                        })
                    }, function (error) {
                        console.log(error);
                        fvm.GlobalError = "An error has been occured. Please try again later.";
                    }
                );
        }

        function refreshFarm(farm, refreshServerList) {
            //console.log("Refreshing farm " + farm.Id + "...");
            farm.IsRefreshing = true;

            if (refreshServerList) {
                farmsFactory.getFarm(farm.Id)
                    .then(
                        function (data) {
                            farm.IsRefreshing = false;
                            farm.IsAvailable = true;

                            farm.Name = data.data.Name;
                            farm.Servers = data.data.Servers;
                            $.each(farm.Servers,
                               function (index, server) {
                                   refreshServer(server);
                               });
                        },
                        function(error) {
                            console.log(error);
                            farm.IsRefreshing = false;
                            farm.IsAvailable = false;
                        }
                    );
            } else {
                farm.IsRefreshing = false;
                farm.IsAvailable = true;

                $.each(farm.Servers,
                    function (index, server) {
                        refreshServer(server);
                    });
            }
        }
        function refreshServer(server) {
            //console.log("Refreshing server " + server.Id + "...");
            server.IsRefreshing = true;
            farmsFactory.getServer(server.Id).then(
                    function (data) {
                        server.IsRefreshing = false;
                        server.IsAvailable = true;
                        server.Details = data.data.Details;
                        server.Name = data.data.Name;

                        if (data.data.AutoRefreshTime > 0) {
                            if (fvm.Timers[data.data.AutoRefreshTime] == null) {
                                console.log(server.Id);
                                fvm.Timers[data.data.AutoRefreshTime] = new TimerInstance(data.data.AutoRefreshTime,server);
                            } else {
                                if (fvm.Timers[data.data.AutoRefreshTime].ServersForRefresh .filter(function(serv) { return serv.Id === server.Id }).length === 0) {
                                    console.log(server.Id);
                                    fvm.Timers[data.data.AutoRefreshTime].updateTimerWithServer(server);
                                }
                            }
                        }

                    }, function (error) {
                        
                        console.log(error);
                        server.IsRefreshing = false;
                        server.IsAvailable = false;
                    }
                );
        }

        function resetControllerProperties() {
            fvm.Farms = [];
            fvm.GlobalError = null;
        }

        var TimerInstance = function (seconds, server) {
            var that = this;
            that.ServersForRefresh = [];
            that.Interval = seconds;
            that.timer = null;
            that.updateTimerWithServer = function (server) {
                that.ServersForRefresh.push(server);

                if (that.timer != null)
                    clearInterval(that.timer);

                that.timer = setInterval(function () {
                    $.each(that.ServersForRefresh,
                        function(index, server) {
                            refreshServer(server);
                        });
                }, that.Interval * 1000);
            }
            that.updateTimerWithServer(server);
            return that;
        }
    }
})();