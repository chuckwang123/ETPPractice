using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ETPPractice.Helper;
using ETPPractice.Models;
using ETPPractice.Util;
using Serilog;

namespace ETPPractice.Controllers
{
    
    [RoutePrefix("api/Contact")]
    public class ContactController : ApiController
    {
        private readonly DapperSql _mDapperSql;
        private readonly Webconfig _webconfig;
        private readonly ContactInfoValidator _contactInfoValidator = new ContactInfoValidator();
        private string path = HttpContext.Current.Request.Url.AbsoluteUri;
        public ContactController()
        {
            _webconfig = new Webconfig();
            _mDapperSql = new DapperSql();
        }

        // GET: api/Contact/Roles
        [Route("Roles")]
        public IEnumerable<ContactCategoryInfo> GetContactRoles()
        {
            var sqlQuery = _mDapperSql.GetsqlQuery("GetContactRoles.txt");
            var responses = _mDapperSql.Query<ContactCategoryInfo>(_webconfig.RdssqlServerConnection, sqlQuery);
            Log.Information("{path}，{@responses}", path, responses);
            return responses;
        }

        //GET: api/Contract
        [Route("")]
        public IEnumerable<ContactInfo> GetContactRoles(int checkList_id = -1)
        {
            if (checkList_id < 0) throw new ArgumentOutOfRangeException(nameof(checkList_id));
            
            var sqlQuery = _mDapperSql.GetsqlQuery("GetContactInformation.txt");
            var responses = _mDapperSql.Query<ContactInfo>(_webconfig.RdssqlServerConnection, sqlQuery, new { checkList_id });
            var contactInfos = responses as IList<ContactInfo> ?? responses.ToList();
            var results = contactInfos.Select(response => _contactInfoValidator.Validate(response)).ToList();
            var failures = results.Select(x=>x.Errors);
            if (failures.Any())
            {
                //Log.Error();
            }
            Log.Information("{path}，The request is {checkList_id}, and the response if {@responses}", path, checkList_id, responses);
            return contactInfos;
        }

        // POST: api/Contact
        [HttpPost, Route("")]
        public void Post(ContactInfo info)
        {
            var sqlQuery = _mDapperSql.GetsqlQuery("InsertContactInformation.txt");
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
        public void Put(ContactInfo info)
        {
            string sqlQuery = _mDapperSql.GetsqlQuery("UpdateContactInformation.txt");
            _mDapperSql.Execute(_webconfig.RdssqlServerConnection, sqlQuery, new
            {
                info.id,
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
