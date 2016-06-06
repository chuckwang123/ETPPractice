using System;

namespace ETPPractice.Models
{
    public class ChecklistDocumentation
    {
        public int Id { get; set; }
        public int checkList_id { get; set; }
        public int documentation_id { get; set; }
        public string reviewed_by { get; set; }
        public DateTime access_date { get; set; }
    }
}
