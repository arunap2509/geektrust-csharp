using System;
using System.IO;
using Xunit;

namespace tameofthrones
{
    public class TameOfThronesTests
    {
        private string _projectDirectory;

        public TameOfThronesTests()
        {
            string workingDirectory = Environment.CurrentDirectory;
            _projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        }

        [Fact]
        public void ReturnsNone()
        {
            var path = _projectDirectory + "/TestInput.txt";
            Southeros southeros = new Southeros(path);
            Assert.Equal("None", southeros.GetRulerAndAllies());
        }

        [Fact]
        public void ReturnsKingAndAllies()
        {
            var path = _projectDirectory + "/input.txt";
            Southeros southeros = new Southeros(path);
            Assert.Equal("SPACE FIRE AIR WATER", southeros.GetRulerAndAllies());
        }

        [Fact]
        public void ReturnsNoneAndWontMatchWithAssert()
        {
            var path = _projectDirectory + "/TestInput.txt";
            Southeros southeros = new Southeros(path);
            Assert.NotEqual("SPACE LAND AIR", southeros.GetRulerAndAllies());
        }
    }
}