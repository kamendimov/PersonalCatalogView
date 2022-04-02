using System;
using System.ComponentModel;

namespace PersonalCatalogView.ObjectModel
{
    public class Person : BasicObject
    {
        private const int MIN_FIRST_NAME_LENGTH = 1;
        private const int MIN_SURNAME_LENGTH = 1;
        private const int MIN_ADDRESS_LENGTH = 10;
        private const int MIN_PHONE_NUMBER_LENGTH = 10;
        public const int IBAN_LENGTH = 22;
        public string FirstName { get; set; } = String.Empty;
        public string SurName { get; set; } = String.Empty;
        public DateTime? Dob { get; set; }
        public string Address { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public string IBAN { get; set; } = String.Empty;

        public override PERSIST_DATA_ERROR Validate()
        {
            if(FirstName.Length < MIN_FIRST_NAME_LENGTH)
            {
                return PERSIST_DATA_ERROR.INVALID_FIRST_NAME;
            }
            if (SurName.Length < MIN_SURNAME_LENGTH)
            {
                return PERSIST_DATA_ERROR.INVALID_SUR_NAME;
            }
            if(!Dob.HasValue || Dob.Value > DateTime.Today)
            {
                return PERSIST_DATA_ERROR.INVALID_DOB;
            }
            if (Address.Length < MIN_ADDRESS_LENGTH)
            {
                return PERSIST_DATA_ERROR.INVALID_ADDRESS;
            }
            if (PhoneNumber.Length < MIN_PHONE_NUMBER_LENGTH)
            {
                return PERSIST_DATA_ERROR.INVALID_PHONE_NUMBER;
            }
            if (IBAN.Length < IBAN_LENGTH)
            {
                return PERSIST_DATA_ERROR.INVALID_IBAN;
            }
            return PERSIST_DATA_ERROR.SUCCESS;
        }

        public void SetDobFromString(string birthday)
        {
            Dob = DateTime.Parse(birthday);
        }

        public string GetDobAsTring()
        {
            if (Dob.HasValue)
            {
                return Dob.Value.ToShortDateString();
            }
            return String.Empty;
        }
    }

    public enum PERSIST_DATA_ERROR
    {
        SUCCESS,

        [Description("Invalid first name!")]
        INVALID_FIRST_NAME,

        [Description("Invalid surname!")]
        INVALID_SUR_NAME,

        [Description("Invalid birthday!")]
        INVALID_DOB,

        [Description("Invalid address!")]
        INVALID_ADDRESS,

        [Description("Invalid phone number!")]
        INVALID_PHONE_NUMBER,

        [Description("Invalid IBAN!")]
        INVALID_IBAN,

        [Description("Invalid person Id!")]
        INVALID_PERSON_ID,

        [Description("Missing object!")]
        MISSING_OBJECT,

        [Description("Person exixts!")]
        PERSON_EXISTS
    }
}
