using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGalaxyConverter.Domain
{
    public interface IExpression
    {
        void Interpret(GalaxyContext context);
    }
}
