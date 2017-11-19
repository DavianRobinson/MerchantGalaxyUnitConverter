using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MerchantGalaxyConverter.Domain.Tests
{
    public class RomanNumeralTests
    {
        [Theory]
        [InlineData("glob", "glob is I")]
        [InlineData("prok", "prok is V")]
        [InlineData("pish", "pish is X")]
        [InlineData("tegj", "tegj is L")]
        [InlineData("glob glob", "glob glob is II")]

        public void Given_A_GalacticUnit_String_Should_Return_A_RomanNumeral(string galaxyString, string expectedResult)
        {
            //Arrange 
            var GalaxyContext = new GalaxyContext(galaxyString);
            var tree = new List<Expression>();
            tree.Add(new Thousand());
            tree.Add(new Hundred());
            tree.Add(new Ten());
            tree.Add(new One());
            tree.Add(new SilverMaterial());
            //Act
            foreach (var item in tree)
            {
                item.Interpret(GalaxyContext);
            }
            //Assert
            Assert.Equal(expectedResult, GalaxyContext.MessageRoman);
        }
        [Theory]
        [InlineData("glob glob Silver", "glob glob Silver is 34 Credits")]
        [InlineData("glob prok Gold", "glob prok Gold is 57800 Credits")]
        [InlineData("glob prok Iron", "glob prok Iron is 782.00 Credits")]
        [InlineData("pish pish Iron", "pish pish Iron is 3910.00 Credits")]
        [InlineData("pish tegj glob glob", "pish tegj glob glob is 42")]
        [InlineData("how much wood could a woodchuck chuck if a woodchuck could chuck wood", "I have no idea what you are talking about")]

        public void Should_return_Total_Credits(string galaxyUnit, string expectedResult)
        {
            //Arrange 
            var GalaxyContext = new GalaxyContext(galaxyUnit);
            var tree = new List<Expression>();
            tree.Add(new Thousand());
            tree.Add(new Hundred());
            tree.Add(new Ten());
            tree.Add(new One());
            tree.Add(new SilverMaterial());
            tree.Add(new GoldMaterial());
            tree.Add(new IronMaterial());
            //Act
            foreach (var item in tree)
            {
                item.Interpret(GalaxyContext);
            }
            if (!GalaxyContext.IsKnown)
                GalaxyContext.SetUnknown();
            //Assert
            Assert.Equal(expectedResult, GalaxyContext.Output);
        }

    }
}
