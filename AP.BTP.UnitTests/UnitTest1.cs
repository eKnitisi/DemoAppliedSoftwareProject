using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AP.BTP.Application.CQRS;
using AP.BTP.Application.Interfaces;
using FluentValidation.TestHelper;
using AP.BTP.Domain;

namespace AP.BTP.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IUnitOfWork> mockUow;
        private Mock<ICityRepository> mockCityRepo;
        private Mock<ICountryRepository> mockCountryRepo;

        [TestInitialize]
        public void Setup()
        {
            mockUow = new Mock<IUnitOfWork>();
            mockCityRepo = new Mock<ICityRepository>();
            mockCountryRepo = new Mock<ICountryRepository>();

            mockUow.Setup(u => u.CityRepository).Returns(mockCityRepo.Object);
            mockUow.Setup(u => u.CountryRepository).Returns(mockCountryRepo.Object);
        }

        [TestMethod]
        public async Task AddCommand_Should_Fail_When_Name_Is_Null()
        {
            var validator = new AddCommandValidator(mockUow.Object);
            var command = new AddCommand
            {
                City = new CityCreateDTO { Name = null, Population = 1000, CountryName = "Belgium" }
            };

            var result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(c => c.City.Name);
        }

        [TestMethod]
        public async Task AddCommand_Should_Fail_When_Population_Too_Large()
        {
            var validator = new AddCommandValidator(mockUow.Object);
            var command = new AddCommand
            {
                City = new CityCreateDTO { Name = "TestCity", Population = 10000000000, CountryName = "Belgium" }
            };

            var result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(c => c.City.Population);
        }

        [TestMethod]
        public async Task AddCommand_Should_Fail_When_Country_Is_Null()
        {
            var validator = new AddCommandValidator(mockUow.Object);
            var command = new AddCommand
            {
                City = new CityCreateDTO { Name = "TestCity", Population = 5000, CountryName = null }
            };

            var result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(c => c.City.CountryName);
        }


        [TestMethod]
        public async Task UpdateCommand_Should_Fail_When_Name_Is_Null()
        {
            var validator = new UpdateCityCommandValidator(mockUow.Object);
            var command = new UpdateCityCommand
            {
                Id = 1,
                Name = null,
                Population = 5000,
                CountryId = 1
            };

            var result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(c => c.Name);
        }

        [TestMethod]
        public async Task UpdateCommand_Should_Fail_When_Population_Too_Large()
        {
            var validator = new UpdateCityCommandValidator(mockUow.Object);
            var command = new UpdateCityCommand
            {
                Id = 1,
                Name = "TestCity",
                Population = 10000000000,
                CountryId = 1
            };

            var result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(c => c.Population);
        }

        [TestMethod]
        public async Task UpdateCommand_Should_Fail_When_Name_Already_Exists_In_Other_City()
        {
            var validator = new UpdateCityCommandValidator(mockUow.Object);

            mockCityRepo.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<City, bool>>>()))
                .ReturnsAsync(new City { Id = 2, Name = "DuplicateCity" }); // simulate existing city with same name

            var command = new UpdateCityCommand
            {
                Id = 1,
                Name = "DuplicateCity",
                Population = 3000,
                CountryId = 1
            };

            var result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(c => c.Name);
        }

    }
}
