using PersonalCatalogView.ObjectModel;

namespace PersonalCatalogView.Service
{
    public interface IPersonQueries
    {
        Person FindPersonById(int Id);
        Person FindPersonByFirstName(string FirstName);
        Person FindPersonByAddress(string address);
        Person FindPersonByPhoneNumber(string phoneNumber);
        Person FindPersonByIBAN(string iban);
    }
}
