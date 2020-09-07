using System;
using Xunit;

namespace CheckPasswordStrength.Tests
{
    public class TestFile
    {
        [Fact]
        public void ClassifyStregth_ShouldReturnWeak()
        {
            // arrange
            var password = "hey";

            // act
            var result = password.PasswordStrength();

            // assert
            Assert.Equal("Weak", result.Value);
        }

        [Fact]
        public void ClassifyStrength_ShouldReturnStrong()
        {
            // arrange
            var password = "heyHey1234!";

            // act
            var result = password.PasswordStrength();

            // assert
            Assert.Equal("Strong", result.Value);
        }

        [Fact]
        public void ClassifyStrength_ShouldReturnMedium()
        {
            // arrange
            var password = "heyHey123";

            // act
            var result = password.PasswordStrength();

            // assert
            Assert.Equal("Medium", result.Value);
        }
    }
}
