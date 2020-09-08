using System;
using System.Collections.Generic;
using Xunit;

namespace CheckPasswordStrength.Tests
{
    public class ClassifyStrengthTest
    {
        [Theory]
        [InlineData("asdf")]
        [InlineData("1234")]
        [InlineData("!@#$")]
        [InlineData("ASDF")]
        public void ClassifyStregth_ShouldReturnWeakCriteria(string password)
        {
            // arrange
            // na
            // act
            var result = password.PasswordStrength();

            // assert
            Assert.Equal("Weak", result.Value);
            Assert.Equal(0, result.Id);
            Assert.Equal(4, result.Length);

            Assert.IsType<string>(result.Value);
            Assert.IsType<int>(result.Id);
            Assert.IsType<int>(result.Length);
            Assert.IsType<List<Contain>>(result.Contains);
        }

        [Theory]
        [InlineData("asdfAS")]
        [InlineData("asdf12")]
        [InlineData("ASDF12")]
        [InlineData("ASDF!@")]
        [InlineData("asdf!@")]
        [InlineData("1234!@")]
        public void ClassifyStrength_ShouldReturnMediumCriteria(string password)
        {
            // arrange
            // na
            // act
            var result = password.PasswordStrength();

            // assert
            Assert.Equal("Medium", result.Value);
            Assert.Equal(1, result.Id);
            Assert.Equal(6, result.Length);

            Assert.IsType<string>(result.Value);
            Assert.IsType<int>(result.Id);
            Assert.IsType<int>(result.Length);
            Assert.IsType<List<Contain>>(result.Contains);
        }

        [Theory]
        [InlineData("asdfASDF!@#$1234")]
        public void ClassifyStrength_ShouldReturnStrongCriteria(string password)
        {
            // arrange
            // na
            // act
            var result = password.PasswordStrength();

            // assert
            Assert.Equal("Strong", result.Value);
            Assert.Equal(2, result.Id);
            Assert.Equal(16, result.Length);

            Assert.IsType<string>(result.Value);
            Assert.IsType<int>(result.Id);
            Assert.IsType<int>(result.Length);
            Assert.IsType<List<Contain>>(result.Contains);
        }

        [Theory]
        [InlineData("asdf")]
        public void ClassifyStrength_ShouldReturnContainsaLowerCase(string password)
        {
            // arrange

            // na
            // act
            var result = password.PasswordStrength();

            // assert
            Assert.Collection(result.Contains, item => Assert.Contains("lowercase", item.Message));
            Assert.Equal(1, result.Contains.Count);
        }

        [Theory]
        [InlineData("ASDF")]
        public void ClassifyStrength_ShouldReturnContainsaUpperCase(string password)
        {
            // arrange

            // na
            // act
            var result = password.PasswordStrength();

            // assert
            Assert.Collection(result.Contains, item => Assert.Contains("uppercase", item.Message));
            Assert.Equal(1, result.Contains.Count);
        }

        [Theory]
        [InlineData("!@#$")]
        public void ClassifyStrength_ShouldReturnContainsaSymbol(string password)
        {
            // arrange

            // na
            // act
            var result = password.PasswordStrength();

            // assert
            Assert.Collection(result.Contains, item => Assert.Contains("symbol", item.Message));
            Assert.Equal(1, result.Contains.Count);
        }

        [Theory]
        [InlineData("1234")]
        public void ClassifyStrength_ShouldReturnContainsaNumeric(string password)
        {
            // arrange

            // na
            // act
            var result = password.PasswordStrength();

            // assert
            Assert.Collection(result.Contains, item => Assert.Contains("number", item.Message));
            Assert.Equal(1, result.Contains.Count);
        }

        [Theory]
        [InlineData("asdfASDF!2")]
        public void ClassifyStrength_ShouldReturnContainsMultipleCriteria(string password)
        {
            // arrange

            // na
            // act
            var result = password.PasswordStrength();

            // assert
            Assert.Collection(result.Contains, item => Assert.Contains("lowercase", item.Message),
                item => Assert.Contains("uppercase", item.Message),
                item => Assert.Contains("symbol", item.Message),
                item => Assert.Contains("number", item.Message));
            Assert.Equal(4, result.Contains.Count);
        }

        // exceptions
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void ClassifyStrength_ShouldReturnArgumentNullExceptionIfPasswordIsEmpty(string passsword)
        {
            // arrange
            var message = "Value cannot be null.";
            // act
            // assert
            var exception = Assert.Throws<ArgumentNullException>(() => passsword.PasswordStrength());
            Assert.Equal(message, exception.Message);
        }
    }
}
