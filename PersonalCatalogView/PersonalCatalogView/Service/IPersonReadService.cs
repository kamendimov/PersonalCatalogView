using PersonalCatalogView.ObjectModel;

namespace PersonalCatalogView.Service
{
    public interface IPersonReadService
    {
        PersonPersistentObject GetPersonById(int Id);
        PersonPersistentObject FindPersonByFirstName(string FirstName);
        PersonPersistentObject FindPersonByAddress(string address);
        PersonPersistentObject FindPersonByPhoneNumber(string address);
        PersonPersistentObject FindPersonByIBAN(string iban);
    }
}
