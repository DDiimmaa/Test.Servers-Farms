using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models.Dto
{
    public class Server
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EndPointURL { get; set; }

        public int FarmId { get; set; }

        public ServerDetails Details { get; set; }

        //in seconds
        public int AutoRefreshTime { get; set; }

        public Server()
        {
            Details = new ServerDetails();
        }
    }

    public class ServerDetails
    {
        public string ModuleName { get; set; }
        public string ModuleInitTime { get; set; }
        public string SystemTime { get; set; }

        //QueueSizes
        public string QueuesInsert { get; set; }
        public string QueuesInsert_ToProces { get; set; }
        public string QueuesIn { get; set; }
        public string QueuesIn_ToProcess { get; set; }
        public string QueuesOut { get; set; }
        public string QueuesOutV2 { get; set; }
        public string QueuesError { get; set; }
        public string QueuesHealth { get; set; }


        public string ThreadCount { get; set; }
        public string ThreadHealth { get; set; }

        public string DatabaseHealth { get; set; }
    }
}
