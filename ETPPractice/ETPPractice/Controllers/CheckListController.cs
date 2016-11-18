using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ETPPractice.Models;
using ETPPractice.Util;

namespace ETPPractice.Controllers
{
    [RoutePrefix("api/CheckList")]
    public class CheckListController : ApiController
    {
        private readonly DapperSql _mDapperSql;
        private readonly Webconfig _webconfig;
        private readonly Helper.Helper _helper;

        public CheckListController()
        {
            _mDapperSql = new DapperSql();
            _webconfig = new Webconfig();
            _helper = new Helper.Helper();
        }

        // GET: api/CheckList
        [Route("")]
        public IEnumerable<CheckList> Get()
        {
            var sqlQuery = _mDapperSql.GetsqlQuery("GetAllCheckList.txt");
            var responses = _mDapperSql.Query<CheckList>(_webconfig.RdssqlServerConnection, sqlQuery);
            var checkLists = responses as IList<CheckList> ?? responses.ToList();
            foreach (var response in checkLists)
            {
                response.ContactInfos = _helper.GetContactRoles(response.CheckListId);
                response.Documentations = _helper.GetDocumentations(response.CheckListId);
                response.Files = _helper.GetMigrationFiles(response.CheckListId);
                response.Serviceses = _helper.GetAccessImoServices(response.CheckListId);
            }
            return checkLists;
        }

        // GET: api/CheckList/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CheckList
        [HttpPost, Route("")]
        public void Post(CheckList checkList)
        {
            if (checkList == null)
            {
                throw new ArgumentNullException($"Nothing there");
            }

            var sqlQuery = _mDapperSql.GetsqlQuery("InsertCheckList.txt");
            var checkList_id = _mDapperSql.ExecuteSingle(_webconfig.RdssqlServerConnection, sqlQuery, new
            {
                checkList.CrmOpportunityId,
                checkList.OrganizationName,
                checkList.WebinarDateTime,
                checkList.AdditionalContactInfo,
                checkList.LttmMarkAllYes
            });

            foreach (var info in checkList.ContactInfos)
            {
                sqlQuery = _mDapperSql.GetsqlQuery("InsertContactInformation.txt");
                _mDapperSql.Execute(_webconfig.RdssqlServerConnection, sqlQuery, new
                {
                    checkList_id,
                    info.role_ID,
                    info.Name,
                    info.Email,
                    info.org_position
                });
            }

            foreach (var service in checkList.Serviceses)
            {
                sqlQuery = _mDapperSql.GetsqlQuery("InsertChecklistAccessIMOServices.txt");
                _mDapperSql.Execute(_webconfig.RdssqlServerConnection, sqlQuery, new
                {
                    checkList_id,
                    service.service_id,
                    service.validate_by,
                    service.access_date,
                    service.notes
                });
            }

            foreach (var file in checkList.Files)
            {
                sqlQuery = _mDapperSql.GetsqlQuery("InsertLTTMMigrationFiles.txt");
                _mDapperSql.Execute(_webconfig.RdssqlServerConnection, sqlQuery, new
                {
                    checkList_id,
                    file.dictionary_Id,
                    file.IsSendFile,
                    file.Reason,
                    file.reviewed_migration,
                    file.export_info
                });
            }

            foreach (var documentation in checkList.Documentations)
            {
                sqlQuery = _mDapperSql.GetsqlQuery("InsertChecklistDocumentation.txt");
                _mDapperSql.Execute(_webconfig.RdssqlServerConnection, sqlQuery, new
                {
                    checkList_id,
                    documentation.documentation_id,
                    documentation.reviewed_by,
                    documentation.access_date
                });
            }
        }

        // PUT: api/CheckList/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CheckList/5
        public void Delete(int id)
        {
        }
    }
}
