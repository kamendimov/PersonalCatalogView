using PersonalCatalogView.ObjectModel;

namespace PersonalCatalogView.Service
{
    public interface IPersonWriteService
    {
        void SavePerson(Person person);
        void UpdatePerson(Person person);
    }
}
