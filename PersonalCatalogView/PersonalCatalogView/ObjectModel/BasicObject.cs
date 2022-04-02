using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCatalogView.ObjectModel
{
    public abstract class BasicObject
    {
        public long Id;
        public abstract PERSIST_DATA_ERROR Validate();
    }
}
