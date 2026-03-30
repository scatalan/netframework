using Microsoft.VisualStudio.TestTools.UnitTesting;
using net48.Services;

namespace UnitTestProject
{
    [TestClass]
    public class CalculatorServiceTests
    {
        [TestMethod]
        public void Sumar_DosNumeros_RetornaSumaCorrecta()
        {
            // Arrange
            var calculator = new CalculatorService();

            // Act
            int resultado = calculator.Sumar(2, 3);

            // Assert
            Assert.AreEqual(7, resultado);
        }

        [TestMethod]
        public void Restar_DosNumeros_RetornaRestaCorrecta()
        {
            // Arrange
            var calculator = new CalculatorService();

            // Act
            int resultado = calculator.Restar(10, 4);

            // Assert
            Assert.AreEqual(6, resultado);
        }
    }
}