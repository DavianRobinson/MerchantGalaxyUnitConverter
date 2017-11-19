using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGalaxyConverter.Domain
{
    public abstract class Expression
    {
        public void Interpret(GalaxyContext context)
        {
            if (context.Input.Length == 0)
                return;

            if (context.Input.TrimStart(' ').StartsWith(glob()))
            {
                context.RomanOutput = context.RomanOutput + one();
                context.Output = String.IsNullOrWhiteSpace(context.Output) ? glob() : context.Output + " " + glob();
                context.Quantity++;
                context.Input = context.Input.TrimStart(' ').Substring(4);
                context._previousToken = glob();
                context.IsKnown = true;
            }
            if (context.Input.TrimStart(' ').StartsWith(prok()))
            {
                context.RomanOutput = context.RomanOutput + five();
                context.Output = String.IsNullOrWhiteSpace(context.Output) ? prok() : context.Output + " " + prok();
                context.Input = context.Input.TrimStart(' ').Substring(4);
                if (!String.IsNullOrWhiteSpace(context._previousToken))
                {
                    if (isLower(context._previousToken, prok()))
                    { context.Quantity = 4; }
                    else { context.Quantity = context.Quantity + 5; }
                }


                context._previousToken = prok();
                context.IsKnown = true;
            }
            if (context.Input.TrimStart(' ').StartsWith(pish()))
            {
                context.RomanOutput = context.RomanOutput + one();
                context.Output = pish();
                context.Input = context.Input.Substring(4);
                if (!String.IsNullOrWhiteSpace(context._previousToken))
                {
                    if (isLower(context._previousToken, pish()))
                    { context.Quantity = 9; }
                    else { context.Quantity = context.Quantity + multiplier(); }
                }
                else
                {
                    context.Quantity = context.Quantity + multiplier();
                }

                context._previousToken = pish();
                context.IsKnown = true;
            }
            if (context.Input.TrimStart(' ').StartsWith(tegj()))
            {
                context.RomanOutput = context.RomanOutput + five();
                context.Output = String.IsNullOrWhiteSpace(context.Output) ? tegj() : context.Output + " " + tegj();
                context.Input = context.Input.TrimStart(' ').Substring(4);
                if (!String.IsNullOrWhiteSpace(context._previousToken))
                {
                    if (isLower(context._previousToken, tegj()))
                    { context.Quantity = (5 * multiplier()) - 10; }
                    else { context.Quantity = context.Quantity + (5 * multiplier()); }
                }
                else
                {
                    context.Quantity = context.Quantity + multiplier();
                }
                context._previousToken = tegj();
                context.IsKnown = true;
            }
            else if (context.Input.TrimStart(' ').StartsWith(four()))
            {
                context.Output = (context.Output + (4 * multiplier()));
                context.Input = context.Input.Substring(2);
                context.IsKnown = true;
            }
            else if (context.Input.TrimStart(' ').StartsWith(five()))
            {
                context.Output = (context.Output + (5 * multiplier()));
                context.Input = context.Input.Substring(2);
                context.IsKnown = true;
            }
            while (context.Input.TrimStart(' ').Equals(one()))
            {
                context.Output = (context.Output + (1 * multiplier()));
                context.Input = context.Input.Substring(2);
                context.IsKnown = true;
            }

            while (context.Input.TrimStart(' ').StartsWith(glob()))
            {
                context.Quantity++;
                context.RomanOutput = context.RomanOutput + one();
                context.Output = context.Output + " " + glob();
                context.Input = context.Input.Substring(5);
                
            }
            while (context.Input.TrimStart(' ').StartsWith(pish()))
            {
                context.Quantity = context.Quantity + multiplier();
                context.RomanOutput = context.RomanOutput + new Ten().multiplier();
                context.Output = context.Output + " " + pish();
                context.Input = context.Input.Substring(5);
            }
            if (context.Input.TrimStart(' ').StartsWith(Silver()))
            {

                context.Output = context.Output + " " + Silver() + " is " + (context.Quantity * new SilverMaterial().multiplier() + " " + "Credits");
                context.Input = context.Input.Substring(6);
                context.IsKnown = true;
            }
            if (context.Input.TrimStart(' ').StartsWith(Gold()))
            {

                context.Output = context.Output + " " + Gold() + " is " + (context.Quantity * new GoldMaterial().multiplier() + " " + "Credits");
                context.Input = context.Input.Substring(4);
                context.IsKnown = true;
            }
            if (context.Input.TrimStart(' ').StartsWith(Iron()))
            {

                context.Output = context.Output + " " + Iron() + " is " + (context.Quantity * new IronMaterial().multiplier() + " " + "Credits");
                context.Input = context.Input.Substring(4);
                context.IsKnown = true;
            }
            if (context.Input.Length == 0)
            {
                context.MessageRoman = string.Format("{0} is {1}", context.Output, context.RomanOutput);
                context.Output = string.Format("{0} is {1}", context.Output, context.Quantity);               
            }

        }

        private bool isLower(String previousToken, String currentToken)
        {
            if (currentToken.Equals(prok()) & previousToken.Equals(glob()))
                return true;
            if (currentToken.Equals(pish()) & previousToken.Equals(prok()))
                return true;
            if (currentToken.Equals(tegj()) & previousToken.Equals(pish()))
                return true;

            return false;
        }

        public abstract string one();
        public abstract String four();
        public abstract String five();
        public abstract String nine();
        public abstract String glob();
        public abstract String prok();
        public abstract String pish();
        public abstract String tegj();
        public abstract String Silver();
        public abstract String Gold();
        public abstract String Iron();
        public abstract decimal multiplier();
    }
}
