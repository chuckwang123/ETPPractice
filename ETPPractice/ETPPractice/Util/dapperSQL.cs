using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using Dapper;

namespace ETPPractice.Util
{
    public class DapperSql
    {
        private readonly Webconfig _mWebconfig = new Webconfig();

        public IEnumerable<T> Query<T>(string connection, string sql, object parameter = null)
        {
            IEnumerable<T> response;
            using (var sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();

                response = sqlConnection.Query<T>(sql, parameter);

                sqlConnection.Close();
            }

            return response;
        }

        public void Execute(string connection, string sql, object parameter = null)
        {
            using (var sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();

                sqlConnection.Query(sql, parameter);

                sqlConnection.Close();
            }
        }

        public int ExecuteSingle(string connection, string sql, object parameter = null)
        {
            IEnumerable<int> response;
            using (var sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();

                response = sqlConnection.Query<int>(sql, parameter);

                sqlConnection.Close();
            }
            return  response.Single();
        }

        public string GetsqlQuery(string fileName)
        {
            var sqlquery = "";
            // ReSharper disable once AssignNullToNotNullAttribute
            using (StreamReader sr = new StreamReader(HostingEnvironment.MapPath(_mWebconfig.SqlQueryPath + fileName)))
            {
                String line = sr.ReadToEnd();
                sqlquery = line.Replace(Environment.NewLine, "");
            }
            return sqlquery;
        }
    }
}