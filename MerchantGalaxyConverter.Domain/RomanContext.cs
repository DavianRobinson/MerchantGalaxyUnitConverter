using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGalaxyConverter.Domain
{
    public class RomanContext
    {
        private string input;
        private int output;

        public RomanContext(string input)
        {
            this.Input = input;
        }
        public string Input
        {
            get
            {
                return input;
            }

            set
            {
                input = value;
            }
        }

        public int Output
        {
            get
            {
                return output;
            }

            set
            {
                output = value;
            }
        }


    }
}
