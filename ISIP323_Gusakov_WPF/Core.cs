using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Gusakov_WPF
{
    public class Core
    {
        private static Entities4 _db;

        public static Entities4 DB
        {
            get
            {
                if (_db == null)
                    _db = new Entities4();
                return _db;
            }
        }

    }
}
