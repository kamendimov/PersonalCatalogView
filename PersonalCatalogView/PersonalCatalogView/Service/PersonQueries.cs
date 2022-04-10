using PersonalCatalogView.ObjectModel;

namespace PersonalCatalogView.Service
{
    public class PersonQueries : IPersonQueries
    {
        private readonly IPersonReadService PersonReadService;
        public PersonQueries(IPersonReadService personReadService)
        {
            PersonReadService = personReadService;
        }

        public Person FindPersonByFirstName(string FirstName)
        {
            PersonPersistentObject personPersistentObject = PersonReadService.FindPersonByFirstName(FirstName);
            return new Person
            {
                Id = personPersistentObject.Id,
                FirstName = personPersistentObject.FirstName,
                SurName = personPersistentObject.SurName,
                Address = personPersistentObject.Address,
                PhoneNumber = personPersistentObject.PhoneNumber,
                Dob = personPersistentObject.Dob,
                IBAN = personPersistentObject.IBAN
            };
        }

        public Person FindPersonByAddress(string address)
        {
            PersonPersistentObject personPersistentObject = PersonReadService.FindPersonByAddress(address);
            return new Person
            {
                Id = personPersistentObject.Id,
                FirstName = personPersistentObject.FirstName,
                SurName = personPersistentObject.SurName,
                Address = personPersistentObject.Address,
                PhoneNumber = personPersistentObject.PhoneNumber,
                Dob = personPersistentObject.Dob,
                IBAN = personPersistentObject.IBAN
            };
        }

        public Person FindPersonByPhoneNumber(string phoneNumber)
        {
            PersonPersistentObject personPersistentObject = PersonReadService.FindPersonByPhoneNumber(phoneNumber);
            return new Person
            {
                Id = personPersistentObject.Id,
                FirstName = personPersistentObject.FirstName,
                SurName = personPersistentObject.SurName,
                Address = personPersistentObject.Address,
                PhoneNumber = personPersistentObject.PhoneNumber,
                Dob = personPersistentObject.Dob,
                IBAN = personPersistentObject.IBAN
            };
        }

        public Person FindPersonByIBAN(string iban)
        {
            PersonPersistentObject personPersistentObject = PersonReadService.FindPersonByIBAN(iban);
            return new Person
            {
                Id = personPersistentObject.Id,
                FirstName = personPersistentObject.FirstName,
                SurName = personPersistentObject.SurName,
                Address = personPersistentObject.Address,
                PhoneNumber = personPersistentObject.PhoneNumber,
                Dob = personPersistentObject.Dob,
                IBAN = personPersistentObject.IBAN
            };
        }

        public Person FindPersonById(int Id)
        {
            PersonPersistentObject personPersistentObject = PersonReadService.GetPersonById(Id);
            return new Person
            {
                Id = personPersistentObject.Id,
                FirstName = personPersistentObject.FirstName,
                SurName = personPersistentObject.SurName,
                Address = personPersistentObject.Address,
                PhoneNumber = personPersistentObject.PhoneNumber,
                Dob = personPersistentObject.Dob,
                IBAN = personPersistentObject.IBAN
            };
        }
    }
}
