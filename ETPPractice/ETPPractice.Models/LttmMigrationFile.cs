using System;

namespace ETPPractice.Models
{
    public class LttmMigrationFile
    {
        public int Id { get; set; }
        public int checkList_id { get; set; }
        public int dictionary_Id { get; set; }
        public bool IsSendFile { get; set; }
        public string Reason { get; set; }
        public bool reviewed_migration { get; set; }
        public DateTime export_info { get; set; }
    }
}
