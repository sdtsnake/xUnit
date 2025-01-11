using StringManipulation;

namespace StringManipulationTests
{
    public class StringOperationsTest
    {
        [Fact]
        public void ConcatenateStringsTest()
        {
            var operations =  new StringOperations();
            var result = operations.ConcatenateStrings("Cadena1", "Cadena2");
            Assert.Equal("Cadena1 Cadena2", result); 

        }
    }
}
