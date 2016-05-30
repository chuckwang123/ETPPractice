using System;
using System.Collections.Generic;
using System.Web.Http;
using ETPPractice.Models;
using ETPPractice.Util;

namespace ETPPractice.Controllers
{
    
    [RoutePrefix("api/Contact")]
    public class ContactController : ApiController
    {
        private readonly DapperSql _mDapperSql;
        private readonly Webconfig _webconfig;

        public ContactController()
        {
            _webconfig = new Webconfig();
            _mDapperSql = new DapperSql();
        }

        // GET: api/Contact/Roles
        [Route("Roles")]
        public IEnumerable<ContactCategoryInfo> GetContactRoles()
        {
            string sqlQuery = _mDapperSql.GetsqlQuery("GetContactRoles.txt");
            var responses = _mDapperSql.Query<ContactCategoryInfo>(_webconfig.RdssqlServerConnection, sqlQuery);
            return responses;
        }

        //GET: api/Contract
        

        [Route("")]
        public IEnumerable<ContactInfo> GetContactRoles(int checkListId = -1)
        {
            if (checkListId < 0) throw new ArgumentOutOfRangeException(nameof(checkListId));
            
            string sqlQuery = _mDapperSql.GetsqlQuery("GetContactInformation.txt");
            var responses = _mDapperSql.Query<ContactInfo>(_webconfig.RdssqlServerConnection, sqlQuery, new {checkListId});
            return responses;
        }

        // GET: api/Contact/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Contact
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Contact/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contact/5
        public void Delete(int id)
        {
        }
    }
}
