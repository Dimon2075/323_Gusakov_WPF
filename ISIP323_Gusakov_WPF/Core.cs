using ISIP323_Gusakov_WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Gusakov_WPF
{
    public static class Core
    {
        private static MAGAZEntities2 _context;
        public static MAGAZEntities2 Context
        {
            get
            {
                if (_context == null)
                    _context = new MAGAZEntities2();
                return _context;
            }
        }

        public static List<Products> Cart = new List<Products>();
    }
}