using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Gusakov_WPF
{
    public class Core
    {
        private static MAGAZ_CosmosEntities1 _db;
        public static MAGAZ_CosmosEntities1 DB => GetContext();
        public static MAGAZ_CosmosEntities1 GetContext()
        {
            if( _db == null )
            {
                _db = new MAGAZ_CosmosEntities1();
            }
            return _db;
        }
        public static Users AuthUser { get; set; }
        public static List<Products> SelectedProducts = new List<Products>();
    }
}
