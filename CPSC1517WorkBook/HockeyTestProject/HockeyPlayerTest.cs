using FluentAssertions;
using Hockey.Data;
using System.Security.Cryptography.X509Certificates;

namespace Hockey.Test
{
    public class HockeyPlayerTest
    {
        public HockeyPlayer GenerateTestPlayer()
        {
            return new HockeyPlayer();
        }

        [Fact]
        public void HockeyPlayer_FirstName_ReturnsGoodFirstName()
        {
            //Arrange
            HockeyPlayer player = GenerateTestPlayer();
            const string NAME = "test";
            player.FirstName = NAME; 

            //Act 
            string actual = player.FirstName; //can help logical errors, syntax errors, runtime errors still work 

            //Assert
            //Assert.Equal(3, actual);
            actual.Should().Be(NAME);
        }

        [Fact]
        public void HockeyPlayer_FirstName_ThrowsExceptionForEmptyArg()
        {
            //Arrange
            HockeyPlayer player = GenerateTestPlayer();
            const string EMPTY_NAME = "";
            
            //Act
            Action act = () => player.FirstName = EMPTY_NAME;   

            //Assert
            act.Should().Throw<ArgumentException>().WithMessage("First name cannot be null or empty.");
             
        }

    }
}