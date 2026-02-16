using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Gusakov_WPF
{
    public class Core
    {
        private static Entities1 _context;
        public static Entities1 DBContext
        {
            get
            {
                if (_context == null)
                {
                    _context = new Entities1();
                }
                return _context;
            }
        }

        public static Users CurrentUser { get; set; }
    }
}
