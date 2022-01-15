using System;
using Xunit;
using Microsoft.VisualStudio.TestPlatform.TestExecutor;
using Game_Logic;
using Deck_of_Cards;

namespace Game_Unit_Tests
{
    public class PilesTest
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            int NombreJoueurs = 4;
            int expected = 13;
            Game_Manager DistributionTest = new Distribution(NombreJoueurs, deck);
            Deck deck = new Deck();

            // Act
            DistributionTest.Distribution(NombreJoueurs, deck);

            // Assert
            int actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Distribution pas réalisée correctement");
        }
    }
}