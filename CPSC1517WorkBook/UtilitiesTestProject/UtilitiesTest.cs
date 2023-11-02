using FluentAssertions;
using System.Security.Cryptography.X509Certificates;
using Utils;
namespace UtilitiesTestProject;

public class UtilitiesTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(1.0D)]
    [InlineData("1.0")] //1.0M 인데 아래서 decimal로 만듬
    public void Utilities_IsPositive_ReturnsTrueForPositive(object value)
    {
        bool actual;

        if (value.GetType() == typeof(int))
        {
            actual = Utilities.IsPositive((int)value);
        }
        else if (value.GetType() == typeof(double))
        {
            actual = Utilities.IsPositive((double)value);
        }
        else
        {
            actual = Utilities.IsPositive(Convert.ToDecimal(value));
        }

        actual.Should().BeTrue();
    }

    //DateOnly data generator 
    public static IEnumerable<object[]> GenerateIsInTheFutureTestData()
    {
        //present
        yield return new object[]
        {
            DateOnly.FromDateTime(DateTime.Now),
            false,
        };

        //past
        yield return new object[]
        {
            DateOnly.FromDateTime(DateTime.Now).AddDays(-1),
            false,
        };

        //future
        yield return new object[]
        {
            DateOnly.FromDateTime(DateTime.Now).AddDays(1),
            true,
        };
    }

    [Theory]
    [MemberData(nameof(GenerateIsInTheFutureTestData))]
    public void Utilities_IsInTheFuture_ReturnsTrueForFutureFalseOtherwise(DateOnly value, bool expected)
    {
        //Arrange
        bool actual;

        //Act 
        actual = Utilities.IsInTheFuture(value);

        //Assert
        actual.Should().Be(expected);
    }
    
    //testing one 
/*    [Fact]
    public void Utilities_IsInTheFuture_ReturnsTrueForFuture()
    {
        //Arrange
        bool actual; 
        DateOnly now = DateOnly.FromDateTime(DateTime.Now).AddDays(1);

        //Act 
        actual = Utilities.IsInTheFuture(now);

        //Assert
        actual.Should().BeTrue();
    }*/

    [Theory]
    [InlineData("")] //Empty string
    [InlineData(" ")] //White Space 
    [InlineData(null)] //null 
    public void Utilities_IsNullEmptyOrWhiteSpace_ReturnsTrueForNullEmptyOrWhiteSpace(string value)
    {
        //Arrange
        bool actual;

        //Act
        actual = Utilities.IsNullEmptyOrWhiteSpace(value);

        //Assert
        actual.Should().BeTrue();
    }


    [Fact]
    public void Utilities_IsNullEmptyOrWhiteSpace_ReturnsFalseForNonEmpty()
    {
        //Arrange
        bool actual;
        const string GOOD_STRING = "x";

        //Act
        actual = Utilities.IsNullEmptyOrWhiteSpace(GOOD_STRING);

        //Assert
        actual.Should().BeFalse();
        //same as 'actual.Should().Be(false)'
    }
}