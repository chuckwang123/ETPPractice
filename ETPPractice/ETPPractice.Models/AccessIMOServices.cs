using System;

namespace ETPPractice.Models
{
    public class AccessImoServices
    {
        public int Id { get; set; }
        public int checkList_id { get; set; }
        public int service_id { get; set; }
        public string validate_by { get; set; }
        public DateTime access_date { get; set; }
        public string notes { get; set; }
    }
}
