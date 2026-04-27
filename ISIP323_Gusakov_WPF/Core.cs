using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Gusakov_WPF
{
    public class Core
    {
        private static MAGAZ_CosmosEntities _db;
        public static MAGAZ_CosmosEntities DB => GetContext();
        public static MAGAZ_CosmosEntities GetContext()
        {
            if( _db == null )
            {
                _db = new MAGAZ_CosmosEntities();
            }
            return _db;
        }
        public static Users AuthUser { get; set; }
        public static List<Products> SelectedProducts = new List<Products>();
    }
}
