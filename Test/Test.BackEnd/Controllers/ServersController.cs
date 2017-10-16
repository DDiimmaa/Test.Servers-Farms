using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Test.BackEnd.Helpers;
using Test.Models;
using Test.Models.Dto;

namespace Test.BackEnd.Controllers
{
    public class ServersController : BaseApiController
    {
        // GET: api/Servers
        //public IEnumerable<Server> Get()
        //{
        //    var servers = unitOfWork.Servers.GetAll().ToArray();
        //    return Mapper.Map<Test.Models.Entities.Server[], Server[]>(servers);
        //}

        // GET: api/Servers/5
        public async Task<Server> Get(int id)
        {
            var server = unitOfWork.Servers.Get(id);

            var serverDto = Mapper.Map<Test.Models.Entities.Server, Server>(server);

            string html = await HttpRequestHelper.GetServerPage(serverDto.EndPointURL);

            ServerDetails details = serverDto.Details;
            ExtendObject<ServerDetails>.ExtendFromHtmlBody(ref details, html);

            return serverDto;
        }

        //// POST: api/Servers
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Servers/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Servers/5
        //public void Delete(int id)
        //{
        //}
    }
}
