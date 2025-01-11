using StringManipulation;

namespace StringManipulationTests
{
    public class StringOperationsTest
    {
        [Fact]
        public void ConcatenateStringsTest()
        {
            // Arrange
            var operations =  new StringOperations();
            // Act
            var result = operations.ConcatenateStrings("Cadena1", "Cadena2");
            // Assert
            Assert.NotNull(result); 
            Assert.NotEmpty(result);    
            Assert.Equal("Cadena1 Cadena2", result); 
        }

        [Fact]
        public void IsPalindromoTrueTest()
        {
            // Arrange
            var operations = new StringOperations();
            // Act
            var result = operations.IsPalindrome("reconocer");
            // Assert            
            Assert.True(result);

        }

        [Fact]
        public void IsPalindromoFalseTest()
        {
            // Arrange
            var operations = new StringOperations();
            // Act
            var result = operations.IsPalindrome("conocimiento");
            // Assert            
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

    }
}
