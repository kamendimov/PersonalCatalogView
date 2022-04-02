using PersonalCatalogView.ObjectModel;

namespace PersonalCatalogView.Service
{
    public interface IPersonReadService
    {
        Person GetPersonById(int Id);
        Person FindPersonByFirstName(string FirstName);
        Person FindPersonByAddress(string address);
        Person FindPersonByPhoneNumber(string address);
        Person FindPersonByIBAN(string iban);
    }
}
