using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Test.Models;
using Test.Models.Dto;

namespace Test.BackEnd.Controllers
{
    public class FarmsController : BaseApiController
    {
        // GET: api/Farms
        public IEnumerable<Farm> Get()
        {
            var farms = unitOfWork.Farms.GetAll().ToArray();
            return Mapper.Map<Test.Models.Entities.Farm[], Farm[]>(farms);
        }

        // GET: api/Farms/5
        public Farm Get(int id)
        {
            var farm = unitOfWork.Farms.Get(id);
            return Mapper.Map<Test.Models.Entities.Farm, Farm>(farm);
        }

        // POST: api/Farms
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Farms/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Farms/5
        //public void Delete(int id)
        //{
        //}
    }
}
