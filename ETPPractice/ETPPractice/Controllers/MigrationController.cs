using System;
using System.Collections.Generic;
using System.Web.Http;
using ETPPractice.Models;
using ETPPractice.Util;

namespace ETPPractice.Controllers
{
    [RoutePrefix("api/migration")]
    public class MigrationController : ApiController
    {
        private readonly DapperSql _mDapperSql;
        private readonly Webconfig _webconfig;

        public MigrationController()
        {
            _mDapperSql = new DapperSql();
            _webconfig = new Webconfig();
        }

        // GET: api/Migration
        [Route("dictionary")]
        public IEnumerable<LttmDictionary> GetLttmDictionary()
        {
            var sqlQuery = _mDapperSql.GetsqlQuery("GetLTTMDictionary.txt");
            var responses = _mDapperSql.Query<LttmDictionary>(_webconfig.RdssqlServerConnection, sqlQuery);
            return responses;
        }

        // GET: api/Migration/5
        [Route("")]
        public IEnumerable<LttmMigrationFile> Get(int checkListId = -1)
        {
            if (checkListId <= 0) throw new ArgumentOutOfRangeException(nameof(checkListId));

            var sqlQuery = _mDapperSql.GetsqlQuery("GetLTTMMigrationFiles.txt");
            var responses = _mDapperSql.Query<LttmMigrationFile>(_webconfig.RdssqlServerConnection, sqlQuery);
            return responses;
        }

        // POST: api/Migration
        [HttpPost,Route("")]
        public void Post(LttmMigrationFile file)
        {
            string sqlQuery = _mDapperSql.GetsqlQuery("InsertLTTMMigrationFiles.txt");
            _mDapperSql.Execute(_webconfig.RdssqlServerConnection, sqlQuery, new
            {
                file.checkList_id,
                file.dictionary_Id,
                file.IsSendFile,
                file.Reason,
                file.reviewed_migration,
                file.export_info
            });
        }

        // PUT: api/Migration/5
        [HttpPut,Route("")]
        public void Put(LttmMigrationFile file)
        {
            string sqlQuery = _mDapperSql.GetsqlQuery("UpdateLTTMMigrationFiles.txt");
            _mDapperSql.Execute(_webconfig.RdssqlServerConnection, sqlQuery, new
            {
                file.Id,
                file.checkList_id,
                file.dictionary_Id,
                file.IsSendFile,
                file.Reason,
                file.reviewed_migration,
                file.export_info
            });
        }

        // DELETE: api/Migration/5
        [HttpDelete,Route("")]
        public void Delete(int id)
        {
            string sqlQuery = _mDapperSql.GetsqlQuery("DeleteLTTMMigrationFiles.txt");
            _mDapperSql.Execute(_webconfig.RdssqlServerConnection, sqlQuery, new
            {
                id
            });
        }
    }
}
