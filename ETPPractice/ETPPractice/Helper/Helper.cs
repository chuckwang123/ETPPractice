using System;
using System.Collections.Generic;
using ETPPractice.Models;
using ETPPractice.Util;

namespace ETPPractice.Helper
{
    public class Helper
    {
        private readonly DapperSql _mDapperSql;
        private readonly Webconfig _webconfig;

        public Helper()
        {
            _mDapperSql = new DapperSql();
            _webconfig = new Webconfig();
        }
        
        public IEnumerable<ContactInfo> GetContactRoles(int checkList_id = -1)
        {
            if (checkList_id < 0) throw new ArgumentOutOfRangeException(nameof(checkList_id));

            string sqlQuery = _mDapperSql.GetsqlQuery("GetContactInformation.txt");
            var responses = _mDapperSql.Query<ContactInfo>(_webconfig.RdssqlServerConnection, sqlQuery, new { checkList_id });
            return responses;
        }

        public IEnumerable<LttmMigrationFile> GetMigrationFiles(int checkList_id = -1)
        {
            if (checkList_id <= 0) throw new ArgumentOutOfRangeException(nameof(checkList_id));

            var sqlQuery = _mDapperSql.GetsqlQuery("GetLTTMMigrationFiles.txt");
            var responses = _mDapperSql.Query<LttmMigrationFile>(_webconfig.RdssqlServerConnection, sqlQuery, new { checkList_id });
            return responses;
        }

        public IEnumerable<ChecklistDocumentation> GetDocumentations(int checkList_id = -1)
        {
            if (checkList_id < 0) throw new ArgumentOutOfRangeException(nameof(checkList_id));
            var sqlQuery = _mDapperSql.GetsqlQuery("GetChecklistDocumentation.txt");
            var responses = _mDapperSql.Query<ChecklistDocumentation>(_webconfig.RdssqlServerConnection, sqlQuery, new { checkList_id });
            return responses;
        }

        public IEnumerable<AccessImoServices> GetAccessImoServices(int checkList_id = -1)
        {
            if (checkList_id <= 0) throw new ArgumentOutOfRangeException(nameof(checkList_id));

            var sqlQuery = _mDapperSql.GetsqlQuery("GetAccessIMOServices.txt");
            var responses = _mDapperSql.Query<AccessImoServices>(_webconfig.RdssqlServerConnection, sqlQuery, new { checkList_id });
            return responses;
        }
    }
}