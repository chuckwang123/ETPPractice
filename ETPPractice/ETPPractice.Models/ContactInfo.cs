using System;

namespace ETPPractice.Models
{
    public class ContactInfo
    {
        public int id { get; set; }
        public int checkList_id { get; set; }
        public int role_ID { get; set; }
        public string Name
        {
            get { return ""; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
            }
        }

        public string Email { get { return ""; } set
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
        }
        }
        public string org_position
        {
            get { return ""; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
            }
        }
    }
}
