using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brovushka.EF
{
    public partial class Product
    {
        public string GetImage
        {
            get
            {
                if (MainImagePath != null)
                {
                    return $"/{MainImagePath}";
                }
                else
                {
                    return MainImagePath;
                }
            }
        }

        public string GetColor
        {
            get
            {
                if (IsActive == true)
                {
                    return "White";
                }
                else
                {
                    return "LightGray";
                }
            }
        }

    }
}
