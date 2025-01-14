using Microsoft.Extensions.Logging;
using Moq;
using StringManipulation;

namespace StringManipulationTests
{
    public class StringOperationsTest
    {
        [Fact]
        public void ConcatenateStringsTest()
        {
            // Arrange
            var operations = new StringOperations();
            // Act
            var result = operations.ConcatenateStrings("Cadena1", "Cadena2");
            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Cadena1 Cadena2", result);
        }

        [Theory]
        [InlineData("reconocer", true)]
        [InlineData("conocimiento", false)]
        public void IsPalindromoTest(string word, bool validareTure)
        {
            // Arrange
            var operations = new StringOperations();

            // Act
            var result = operations.IsPalindrome(word);

            // Assert            
            if(validareTure)
                Assert.True(result);
            else 
                Assert.False(result);
        }

        [Fact]
        public void QuantintyInWordsTest()
        {
            // Arrange
            var operations = new StringOperations();
            // Act
            var result = operations.QuantintyInWords("Dog", 10);
            // Assert            
            Assert.StartsWith("diez", result);
            Assert.Contains("Dog", result);
        }

        [Fact]
        public void TruncateStringExceptionTest()
        {
            // Arrange
            var operations = new StringOperations();
            // Assert
            Assert.ThrowsAny<ArgumentException>(() => operations.GetStringLength(null));
        }

        [Theory]
        [InlineData("V", 5)]
        [InlineData("X", 10)]
        [InlineData("III", 3)]
        public void FormRomanToNumnerTest(string romanNumber, int expected)
        {
            // Arrange
            var operations = new StringOperations();
            // Act
            var result = operations.FromRomanToNumber(romanNumber);
            // Assert
            Assert.Equal(expected, result); 
        }

        [Fact]
        public void CountOccurrencesTest()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<StringOperations>>();
            var operations = new StringOperations(mockLogger.Object);
            
            // Act
            var result = operations.CountOccurrences("Oscar Andres Ramos Lopez", 's');
            // Assert
            Assert.Equal(3, result);
        }


    }
}
