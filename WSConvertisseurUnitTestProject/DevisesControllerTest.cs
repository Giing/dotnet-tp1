using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Controllers;
using WSConvertisseur.Models;

namespace WSConvertisseurUnitTestProject
{
    [TestClass]
    public class DevisesControllerTest
    {
        private DevisesController devisesController;
        public DevisesControllerTest()
        {
            devisesController = new DevisesController();
        }

        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsOkObjectResult()
        {
            // Act
            var result = devisesController.GetById(1);
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult), "Pas un OkObjectResult");
        }

        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Act
            var result = devisesController.GetById(1) as OkObjectResult;
            // Assert
            Assert.IsInstanceOfType(result.Value, typeof(Devise), "Pas une Devise");
            Assert.AreEqual(new Devise(1, "Dollar", 1.08), (Devise?)result.Value, "Devises pas identiques");
        }

        [TestMethod]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var result = devisesController.GetById(20);
            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult), "Pas un NotFoundResult");
        }

        [TestMethod]
        public void GetAll_ReturnsNotNull()
        {
            // Act
            var result = devisesController.GetAll() as OkObjectResult;
            // Assert
            Assert.IsNotNull(result.Value);
        }
    }
}