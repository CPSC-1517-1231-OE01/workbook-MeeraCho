using FluentAssertions;
using Hockey.Data;
using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;
using Xunit.Sdk;

namespace Hockey.Test
{
    public class HockeyPlayerTest
    {
        const string FirstName = "Connor";
        const string LastName = "Brown";
        const string BirthPlace = "Toronto, ON, CAN";
        static readonly DateOnly DateOfBirth = new DateOnly(1994, 01, 14);
        const int HeightInInches = 72;
        const int WeightInPounds = 188;
        const int JerseyNumber = 28;
        const Position PlayerPosition = Position.Center;
        const Shot PlayerShot = Shot.Left;
        readonly int Age = (DateOnly.FromDateTime(DateTime.Now).DayNumber - DateOfBirth.DayNumber) / 365;

        string ToStringValue = $"{FirstName},{LastName},{JerseyNumber},{PlayerPosition},{PlayerShot},{HeightInInches},{WeightInPounds},Jan-14-1994,{BirthPlace.Replace(", ", "-")}";

        public HockeyPlayer CreateTestHockeyPlayer()
        {
            return new HockeyPlayer(FirstName, LastName, BirthPlace, DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot);
        }

        private class BadHockeyPlayerTestDataGenerator : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                 //First Name Tests 
                new object[] {"", LastName, BirthPlace, DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot, "First name cannot be null or empty."},
                new object[] {" ", LastName, BirthPlace, DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot, "First name cannot be null or empty."},
                new object[] {null, LastName, BirthPlace, DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot, "First name cannot be null or empty."},
                
                //Last Name Tests
                new object[] { FirstName, "", BirthPlace, DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot, "Last name cannot be null or empty." },
                new object[] { FirstName, " ", BirthPlace, DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot, "Last name cannot be null or empty." },
                new object[] { FirstName, null, BirthPlace, DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot, "Last name cannot be null or empty." },

                //Birth Place tests
                new object[] { FirstName, LastName, "", DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot, "Birth Place cannot be null or empty." },
                new object[] { FirstName, LastName, " ", DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot, "Birth Place cannot be null or empty." },
                new object[] { FirstName, LastName, null, DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot, "Birth Place cannot be null or empty." },
                
                //Date of Birth test
                new object[] { FirstName, LastName, BirthPlace, DateOnly.FromDateTime(DateTime.Now.AddDays(1)), WeightInPounds, HeightInInches, JerseyNumber, PlayerPosition, PlayerShot, "Date of birth cannot be in the future." },
                
                //Height test 
                new object[] { FirstName, LastName, BirthPlace, DateOfBirth, -1, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot, "Height must be positive." },
                
                //Weight test
                new object[] { FirstName, LastName, BirthPlace, DateOfBirth, HeightInInches, -1, JerseyNumber, PlayerPosition, PlayerShot, "Weight must be positive." },
                
                // Jersey number tests
                new object[] { FirstName, LastName, BirthPlace, DateOfBirth, WeightInPounds, HeightInInches, 0, PlayerPosition, PlayerShot, "Jersey number must be between 1 and 98." },
                new object[] { FirstName, LastName, BirthPlace, DateOfBirth, WeightInPounds, HeightInInches, 100, PlayerPosition, PlayerShot, "Jersey number must be between 1 and 98." },
            };
            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        public static IEnumerable<object[]> GoodHockeyPlayerTestDataGenerator()
        {
            yield return new object[]
            {
                FirstName, LastName, BirthPlace, DateOfBirth, WeightInPounds, HeightInInches, JerseyNumber, PlayerPosition, PlayerShot,
            };
        }

        [Theory]
        [MemberData(nameof(GoodHockeyPlayerTestDataGenerator))]
        public void HockeyPlayer_GreedyConstructor_ReturnsHockeyPlayer(string firstName, string lastName, string birthPlace, DateOnly dateOfBirth, int heightInInches, int weightInInches, int jerseyNumber, Position position, Shot shot)
        {
            HockeyPlayer actual;
            actual = new HockeyPlayer(firstName, lastName, birthPlace, dateOfBirth, heightInInches, weightInInches, jerseyNumber, position, shot);
            actual.Should().NotBeNull();
        }

        [Theory]
        [ClassData(typeof(BadHockeyPlayerTestDataGenerator))]
        public void HockeyPlayer_GreedyConstructor_ThrowException(string firstName, string lastName, string birthPlace, DateOnly dateOfBirth, int heightInInches, int weightInInches, int jerseyNumber, Position position, Shot shot, string errMsg)
        {
            Action act = () => new HockeyPlayer(firstName, lastName, birthPlace, dateOfBirth, heightInInches, weightInInches, jerseyNumber, position, shot);
            act.Should().Throw<ArgumentException>().WithMessage(errMsg);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(98)]
        public void HockeyPlayer_JerseyNumber_GoodSetAndGet(int value)
        {
            HockeyPlayer player = CreateTestHockeyPlayer();
            player.JerseyNumber = value;
            int actual = player.JerseyNumber;
            actual.Should().Be(value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(99)]
        public void HockeyPlayer_JerseyNumber_BadSetThrows(int value)
        {
            HockeyPlayer player = CreateTestHockeyPlayer();
            Action act = () => player.JerseyNumber = value;
            act.Should().Throw<ArgumentException>().WithMessage("Jersey number must be between 1 and 98.");
        }

        [Fact]
        public void HockeyPlayer_Age_ReturnsCorrectAge()
        {
            HockeyPlayer player = CreateTestHockeyPlayer();
            int actual = player.Age;
            actual.Should().Be(Age);
        }

        [Fact]
        public void HockeyPlayer_ToString_ReturnsCorrectValue()
        {
            HockeyPlayer player = CreateTestHockeyPlayer();
            string actual = player.ToString();
            actual.Should().Be(ToStringValue);
        }

        //incoming data change to Hockeydata object, so need to check the outcome is Hockeydata object 
        [Fact]
        public void HockeyPlayer_Parse_ParsesCorrectly()
        {
            HockeyPlayer actual;
            string line = $"{FirstName},{LastName},{JerseyNumber},{PlayerPosition},{PlayerShot},{HeightInInches},{WeightInPounds},Jan-14-1994,{BirthPlace.Replace(", ", "-")}";
            //string line = ToStringValue;
            actual = HockeyPlayer.Parse(line);
            actual.Should().BeOfType<HockeyPlayer>();
            actual.Should().NotBeNull();
        }

        [Theory] //line이 비어있는 경우 
        [InlineData(null, "Line cannot be null or empty.")]
        [InlineData("", "Line cannot be null or empty.")]
        [InlineData(" ", "Line cannot be null or empty.")]
        public void HockeyPlayer_Parse_ThrowsForInvalidNumberOfFields(string line, string errMsg)
        {
            Action act = () => HockeyPlayer.Parse(line);
            act.Should().Throw<ArgumentNullException>().WithMessage(errMsg); //.WithMessage 한 파라미터 안에 에러 날 게 많아서 메세지를 추가하여 구분해 준다 
        }

        [Theory]
        [InlineData("one", "Incorrect number of fields.")] //if (fields.Length != 9) 테스트. 9개 아니면 에러 
        public void HockeyPlayer_Parse_ThrowForInvalidNumberOfFields(string line, string errMsg)
        {
            Action act = () => HockeyPlayer.Parse(line);
            act.Should().Throw<InvalidDataException>().WithMessage(errMsg);
        }

/*        [Fact]
        public void HockeyPlayer_Parse_ThrowForInvalidNumberOfFields()
        {
            string line = "one";
            Action act = () => HockeyPlayer.Parse(line);
            act.Should().Throw<InvalidDataException>().WithMessage("Incorrect number of fields.");
        }*/


        [Theory] //fields 8개 인데 9개 넣은 경우 
        [InlineData("one,two,three,four,five,six,seven,eight,nine", "Error parsing line")]
        public void HockeyPlayer_Parse_ThrowForFormatError(string line, string errMsg)
        {
            Action act = () => HockeyPlayer.Parse(line);
            act.Should().Throw<FormatException>().WithMessage($"*{errMsg}*"); //the asterisk is a wildcard
        }

        [Fact]
        public void HockeyPlayer_TryParse_ParsesCorrectly() //tryparse is boolean and out variable return value 
        {
            /*HockeyPlayer? actual = null;*/
            HockeyPlayer? actual;
            bool result;

            result = HockeyPlayer.TryParse(ToStringValue, out actual);
            result.Should().BeTrue();
            actual.Should().NotBeNull();
        }

        //Todo: false TryParse
    }
}







