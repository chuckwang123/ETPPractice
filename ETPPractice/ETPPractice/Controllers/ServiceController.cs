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

        // POST: api/Service
        [Route("")]
        public void Post(AccessImoServices service)
        {
            string sqlQuery = _mDapperSql.GetsqlQuery("InsertChecklistAccessIMOServices.txt");
            _mDapperSql.Execute(_webconfig.RdssqlServerConnection, sqlQuery, new
            {
                service.checkList_id,
                service.service_id,
                service.validate_by,
                service.access_date,
                service.notes
            });
        }

        // PUT: api/Service/5
        public void Put(AccessImoServices service)
        {
            string sqlQuery = _mDapperSql.GetsqlQuery("UpdateChecklistAccessIMOServices.txt");
            _mDapperSql.Execute(_webconfig.RdssqlServerConnection, sqlQuery, new
            {
                service.Id,
                service.checkList_id,
                service.service_id,
                service.validate_by,
                service.access_date,
                service.notes
            });
        }

        // DELETE: api/Service/5
        public void Delete(int id)
        {
            string sqlQuery = _mDapperSql.GetsqlQuery("DeleteChecklistAccessIMOServices.txt");
            _mDapperSql.Execute(_webconfig.RdssqlServerConnection, sqlQuery, new
            {
                id
            });
        }
    }
}
