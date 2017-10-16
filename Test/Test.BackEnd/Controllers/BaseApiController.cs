using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Test.BackEnd.Controllers
{
    public class BaseApiController : ApiController
    {
        protected UnitOfWork.UnitOfWork unitOfWork;

        public BaseApiController()
        {
            unitOfWork = new UnitOfWork.UnitOfWork();
        }
    }
}
