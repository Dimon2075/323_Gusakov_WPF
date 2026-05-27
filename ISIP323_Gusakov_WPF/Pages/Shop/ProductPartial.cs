using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Gusakov_WPF
{
    public partial class Products // Имя должно совпадать с именем класса в модели
    {
        public bool IsHighDiscount => DiscountPercentage > 15;
    }
}
