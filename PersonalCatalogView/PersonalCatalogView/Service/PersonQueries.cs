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
            return PersonReadService.FindPersonByFirstName(FirstName);
        }

        public Person FindPersonByAddress(string address)
        {
            return PersonReadService.FindPersonByAddress(address);
        }

        public Person FindPersonByPhoneNumber(string phoneNumber)
        {
            return PersonReadService.FindPersonByPhoneNumber(phoneNumber);
        }

        public Person FindPersonByIBAN(string iban)
        {
            return PersonReadService.FindPersonByIBAN(iban);
        }

        public Person FindPersonById(int Id)
        {
            return PersonReadService.GetPersonById(Id);
        }
    }
}
