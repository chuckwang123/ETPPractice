
using System.Configuration;

namespace ETPPractice.Util
{
    public class Webconfig
    {
        public string RdssqlServerConnection
        {
            get { return ConfigurationManager.ConnectionStrings["RDSSQLServerConnection"].ConnectionString; }
        }

        public string SqlQueryPath
        {
            get { return ConfigurationManager.AppSettings["SqlQueryPath"]; }
        }
    }
}