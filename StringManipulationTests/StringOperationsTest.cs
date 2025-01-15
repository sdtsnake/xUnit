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
        public void IsPalindromeTest(string word, bool validareTure)
        {
            // Arrange
            var operations = new StringOperations();

            // Act
            var result = operations.IsPalindrome(word);

            // Assert            
            if (validareTure)
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
        public void GetStringLengthExceptionTest()
        {
            // Arrange
            var operations = new StringOperations();
            // Assert
            Assert.Throws<ArgumentNullException>(() => operations.GetStringLength(null));
        }

        [Theory]
        [InlineData("V", 5)]
        [InlineData("X", 10)]
        [InlineData("III", 3)]
        public void FromRomanToNumberTest(string romanNumber, int expected)
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

        [Fact]
        public void ReadFileTest()
        {
            // Arrange
            var operations = new StringOperations();
            var mockFile = new Mock<IFileReaderConector>();

            /*
             * con esta hacemos la consulta por un parametro en especifico.
             */
            //mockFile.Setup(f => f.ReadString("texto.txt")).Returns("Lectura con exito");

            /*
             * aqui lo que estamos diciendo no importa el parametro el metodo siempre nos regresara "Lectura con exito"
             */
            mockFile.Setup(f => f.ReadString(It.IsAny<string>())).Returns("Lectura con exito");

            // Act
            var result = operations.ReadFile(mockFile.Object, "texto.txt");

            // Assert
            Assert.Equal("Lectura con exito", result);
        }

        [Fact]
        public void RemoveWhitespaceTest()
        {
            // Arrange
            var operations = new StringOperations();
            // Act
            var result = operations.RemoveWhitespace("La familia de Oscar");
            // Assert
            Assert.Equal("LafamiliadeOscar", result);
        }

        [Fact]
        public void ReverseStringTest()
        {
            // Arrange
            var operations = new StringOperations();
            // Act
            var result = operations.ReverseString("Otorralingoro");
            // Assert
            Assert.Equal("orognilarrotO", result);
        }

        [Fact]
        public void TruncateStringTest()
        {
            // Arrange
            var operations = new StringOperations();
            // Act
            var result = operations.TruncateString("Sebastian Ramos Nuñez", 5);
            // Assert
            Assert.Equal("Sebas", result);
        }

        [Fact]
        public void TruncateStringInvalidLengthTest()
        {
            // Arrange
            var operations = new StringOperations();
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => operations.TruncateString("Test", -1));
        }
    }
}
