using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGalaxyConverter.Domain
{
    public class SilverMaterial : Expression
    {
        private decimal _unitPrice=17.00M;

        public decimal UnitPrice
        {
            get
            {
                return _unitPrice;
            }

            set
            {
                _unitPrice = value;
            }
        }

        public override string five()
        {
            return " ";
        }

        public override string four()
        {
            return " ";
        }

        public override string glob()
        {
            return " ";
        }

        public override string Gold()
        {
            return " ";
        }

        public override string Iron()
        {
            return " ";
        }

        public override decimal multiplier()
        {
            return 17;
        }

        public override string nine()
        {
            return " ";
        }

        public override string one()
        {
            return " ";
        }

        public override string pish()
        {
            return " ";
        }

        public override string prok()
        {
            return " ";
        }
        
        public override string Silver()
        {
            return "Silver";
        }

        public override string tegj()
        {
            return " ";
        }
    }
}
