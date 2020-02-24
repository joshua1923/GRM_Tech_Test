using Microsoft.VisualStudio.TestTools.UnitTesting;
using GRM.API.Controllers;
using Unity;
using GRM.Shared.Interfaces;
using Moq;
using GRM.Shared.Models;
using System.Linq;

namespace GRM.API.Tests.Controllers
{

    [TestClass]
    public class ContractsControllerTest
    {
        private Mock<IGenericRepository<Contracts>> mockContractsRepository { get; set; }
        private Mock<IGenericRepository<DistributionPartners>> mockPartnersRepository { get; set; }
        private Mock<IManager> mockManager { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            mockContractsRepository = new Mock<IGenericRepository<Contracts>>();
            mockPartnersRepository = new Mock<IGenericRepository<DistributionPartners>>();
            mockManager = new Mock<IManager>();
        }

        [TestMethod]
        public void PostContractFile_ExpectedStatusOk()
        {
            // Arrange
            var controller = new ContractsController(mockContractsRepository.Object, mockPartnersRepository.Object, mockManager.Object);
            var filePathContracts = @"contracts.txt";

            // Act
            var response = controller.PostContractFile(filePathContracts);

            // Assert
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public void PostPartnerFile_ExpectedStatusOk()
        {
            // Arrange
            var controller = new ContractsController(mockContractsRepository.Object, mockPartnersRepository.Object, mockManager.Object);
            var filePathPartners = @"partners.txt";

            // Act
            var response = controller.PostPartnerFile(filePathPartners);

            // Assert
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public void GetContractsByCriteria_Expected()
        {
            // Arrange
            var controller = new ContractsController(mockContractsRepository.Object, mockPartnersRepository.Object, mockManager.Object);
            var date = "1st feb 2012";
            var partner = "Itunes";

            // Act
            var response = controller.Get(date, partner);

            // Assert
            Assert.IsTrue(response.Any());
        }
    }
}
