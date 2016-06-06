using System.Collections.Generic;
using System.Web.Http;
using ETPPractice.Models;
using ETPPractice.Util;

namespace ETPPractice.Controllers
{
    [RoutePrefix("api/Documentation")]
    public class DocumentationController : ApiController
    {
        private readonly DapperSql _mDapperSql;
        private readonly Webconfig _webconfig;

        public DocumentationController()
        {
            _mDapperSql = new DapperSql();
            _webconfig = new Webconfig();
        }

        // GET: api/Documentation
        [Route("Category")]
        public IEnumerable<Documentation> GetDocumentation()
        {
            string sqlQuery = _mDapperSql.GetsqlQuery("GetDocumentation.txt");
            var responses = _mDapperSql.Query<Documentation>(_webconfig.RdssqlServerConnection, sqlQuery);
            return responses;
        }

        // GET: api/Documentation/5
        [Route("")]
        public IEnumerable<ChecklistDocumentation> Get()
        {
            string sqlQuery = _mDapperSql.GetsqlQuery("GetChecklistDocumentation.txt");
            var responses = _mDapperSql.Query<ChecklistDocumentation>(_webconfig.RdssqlServerConnection, sqlQuery);
            return responses;
        }

        // POST: api/Documentation
        [HttpPost,Route("")]
        public void Post(ChecklistDocumentation documentation)
        {
            string sqlQuery = _mDapperSql.GetsqlQuery("InsertChecklistDocumentation.txt");
            _mDapperSql.Execute(_webconfig.RdssqlServerConnection, sqlQuery, new
            {
                documentation.checkList_id,
                documentation.documentation_id,
                documentation.reviewed_by,
                documentation.access_date
            });
        }

        // PUT: api/Documentation/5
        [HttpPut, Route("")]
        public void Put(ChecklistDocumentation documentation)
        {
            string sqlQuery = _mDapperSql.GetsqlQuery("UpdateChecklistDocumentation.txt");
            _mDapperSql.Execute(_webconfig.RdssqlServerConnection, sqlQuery, new
            {
                documentation.Id,
                documentation.checkList_id,
                documentation.documentation_id,
                documentation.reviewed_by,
                documentation.access_date
            });
        }

        // DELETE: api/Documentation/5
        [HttpDelete,Route("")]
        public void Delete(int id)
        {
            string sqlQuery = _mDapperSql.GetsqlQuery("DeleteChecklistDocumentation.txt");
            _mDapperSql.Execute(_webconfig.RdssqlServerConnection, sqlQuery, new
            {
                id
            });
        }
    }
}
