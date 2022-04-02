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
            personWriteService.SavePerson(person);
        }

        public void UpdatePerson(Person person)
        {
            personWriteService.UpdatePerson(person);
        }
    }
}
