using System;
using System.Collections.Generic;
using System.Web.Http;
using ETPPractice.Models;
using ETPPractice.Util;

namespace ETPPractice.Controllers
{
    [RoutePrefix("api/Service")]
    public class ServiceController : ApiController
    {
        private readonly DapperSql _mDapperSql;
        private readonly Webconfig _webconfig;

        public ServiceController()
        {
            _mDapperSql = new DapperSql();
            _webconfig = new Webconfig();
        }

        // GET: api/Service/Category
        [Route("Category")]
        public IEnumerable<ImoCategoryServices> GetImoCategoryServices()
        {
            string sqlQuery = _mDapperSql.GetsqlQuery("GetIMOServices.txt");
            var responses = _mDapperSql.Query<ImoCategoryServices>(_webconfig.RdssqlServerConnection, sqlQuery);
            return responses;
        }

        //GET: api/Service
        [Route("")]
        public IEnumerable<AccessImoServices> GetAccessImoServices(int checkListId = -1)
        {
            if (checkListId <= 0) throw new ArgumentOutOfRangeException(nameof(checkListId));

            string sqlQuery = _mDapperSql.GetsqlQuery("GetAccessIMOServices.txt");
            var responses = _mDapperSql.Query<AccessImoServices>(_webconfig.RdssqlServerConnection, sqlQuery);
            return responses;
        }

        // GET: api/Service/5

        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Service
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Service/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Service/5
        public void Delete(int id)
        {
        }
    }
}
