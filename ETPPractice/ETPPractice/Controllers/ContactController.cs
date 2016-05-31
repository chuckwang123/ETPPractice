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

        // POST: api/Contact
        [HttpPost, Route("")]
        public void Post(ContactInfo info)
        {
            string sqlQuery = _mDapperSql.GetsqlQuery("InsertContactInformation.txt");
            _mDapperSql.Execute(_webconfig.RdssqlServerConnection, sqlQuery, new
            {
                info.checkList_id,
                info.role_ID,
                info.Name,
                info.Email,
                info.org_position
            });
        }

        // PUT: api/Contact/5
        [HttpPut, Route("{id:int}")]
        public void Put(int id, ContactInfo info)
        {
            string sqlQuery = _mDapperSql.GetsqlQuery("UpdateContactInformation.txt");
            _mDapperSql.Execute(_webconfig.RdssqlServerConnection, sqlQuery, new
            {
                id,
                info.checkList_id,
                info.role_ID,
                info.Name,
                info.Email,
                info.org_position
            });
        }

        // DELETE: api/Contact/5
        [HttpDelete, Route("{id:int}")]
        public void Delete(int id)
        {
            string sqlQuery = _mDapperSql.GetsqlQuery("DeleteContactInformation.txt");
            _mDapperSql.Execute(_webconfig.RdssqlServerConnection, sqlQuery, new
            {
                id
            });
        }
    }
}
