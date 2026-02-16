using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Gusakov_WPF
{
    public class Core
    {
        private static Entities _context;
        public static Entities DBContext
        {
            get
            {
                if (_context == null)
                {
                    _context = new Entities();
                }
                return _context;
            }
        }

        public static Users CurrentUser { get; set; }
    }
}
