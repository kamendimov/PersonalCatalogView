using PersonalCatalogView.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCatalogView.Service
{
    public class PersonCommand : IPersonCommand
    {
        private readonly IPersonWriteService personWriteService;

        public PersonCommand(IPersonWriteService writeService)
        {
            personWriteService = writeService;
        }

        public void SavePerson(Person person)
        {
            PersonPersistentObject personPersistentObject = new PersonPersistentObject();
            personPersistentObject.FirstName = person.FirstName;
            personPersistentObject.SurName = person.SurName;
            personPersistentObject.Dob = person.Dob;
            personPersistentObject.Address = person.Address;
            personPersistentObject.PhoneNumber = person.PhoneNumber;
            personPersistentObject.IBAN = person.IBAN;

            personWriteService.SavePerson(personPersistentObject);
        }

        public void UpdatePerson(Person person)
        {
            PersonPersistentObject personPersistentObject = new PersonPersistentObject();
            personPersistentObject.Id = person.Id;
            personPersistentObject.FirstName = person.FirstName;
            personPersistentObject.SurName = person.SurName;
            personPersistentObject.Dob = person.Dob;
            personPersistentObject.Address = person.Address;
            personPersistentObject.PhoneNumber = person.PhoneNumber;
            personPersistentObject.IBAN = person.IBAN;

            personWriteService.UpdatePerson(personPersistentObject);
        }
    }
}
