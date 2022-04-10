using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCatalogView.ObjectModel
{
    public class PersonPersistentObject
    {
        public long Id;
        public string FirstName { get; set; } = String.Empty;
        public string SurName { get; set; } = String.Empty;
        public DateTime? Dob { get; set; }
        public string Address { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public string IBAN { get; set; } = String.Empty;

        public string GetDobAsTring()
        {
            if (Dob.HasValue)
            {
                return Dob.Value.ToShortDateString();
            }
            return String.Empty;
        }

        public void SetDobFromString(string birthday)
        {
            Dob = DateTime.Parse(birthday);
        }
    }
}
