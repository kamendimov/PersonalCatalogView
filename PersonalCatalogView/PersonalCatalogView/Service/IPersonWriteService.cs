using PersonalCatalogView.ObjectModel;

namespace PersonalCatalogView.Service
{
    public interface IPersonWriteService
    {
        void SavePerson(PersonPersistentObject person);
        void UpdatePerson(PersonPersistentObject person);
    }
}
