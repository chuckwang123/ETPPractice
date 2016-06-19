using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETPPractice.Models
{
    public class CheckList
    {
        public int CheckListId { get; set; }
        public Guid CrmOpportunityId { get; set; }
        public string OrganizationName { get; set; }
        public DateTime WebinarDateTime { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string AdditionalContactInfo { get; set; }
        public bool LttmMarkAllYes { get; set; }
        public IEnumerable<ContactInfo> ContactInfos { get; set; }
        public IEnumerable<ChecklistDocumentation> Documentations { get; set; }
        public IEnumerable<AccessImoServices> Serviceses { get; set; }
        public IEnumerable<LttmMigrationFile> Files { get; set; }
    }
}
