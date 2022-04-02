using PersonalCatalogView.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCatalogView.Service
{
    public interface IPersonCommand
    {
        void SavePerson(Person person);
        void UpdatePerson(Person person);
    }
}
