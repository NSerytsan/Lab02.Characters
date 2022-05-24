using Lab02.Characters.API.Controllers;
using Lab02.Characters.API.Data;
using Lab02.Characters.API.Entities;
using Lab02.Characters.Models.Dtos.WeaponType;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Lab02.Characters.Test
{
    public class WeaponTypeControllerTests
    {
        [Fact]
        public async Task Test_GET_GetWeaponType_Ok()
        {
            string testName = "Test Weapon Type 1";
            int testId = 1;

            var weaponType = new WeaponType()
            {
                Id = testId,
                Name = testName,
                Weapons = new HashSet<Weapon>()
            };

            var mockRepo = new Mock<IWeaponTypeRepository>();
            mockRepo.Setup(repo => repo.GetAsync(It.IsAny<int>())).ReturnsAsync(weaponType);
            var controller = new WeaponTypeController(mockRepo.Object);

            var result = await controller.GetWeaponType(testId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(200, okResult.StatusCode);
            var weaponTypeDto = Assert.IsType<WeaponTypeDto>(okResult.Value);
            Assert.NotNull(weaponTypeDto);
            Assert.Equal(weaponTypeDto.Id, testId);
            Assert.Equal(weaponTypeDto.Name, testName);
        }

        [Fact]
        public async Task Test_GET_GetWeponType_NotFound()
        {
            int testId = 1;
            WeaponType? weaponType = null;

            var mockRepo = new Mock<IWeaponTypeRepository>();
            mockRepo.Setup(repo => repo.GetAsync(It.IsAny<int>())).ReturnsAsync(weaponType);
            var controller = new WeaponTypeController(mockRepo.Object);

            var result = await controller.GetWeaponType(testId);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Test_GET_GetWeaponTypes()
        {
            var mockRepo = new Mock<IWeaponTypeRepository>();
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(Multiple());
            var controller = new WeaponTypeController(mockRepo.Object);

            var result = await controller.GetWeaponTypes();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var weaponTypes = Assert.IsAssignableFrom<IEnumerable<WeaponTypeDto>>(okResult.Value);
            Assert.Equal(3, weaponTypes.Count());
        }

        private static IEnumerable<WeaponType> Multiple()
        {
            var weaponTypes = new List<WeaponType>
            {
                new WeaponType() { Id = 1, Name = "Weapon Type 1", Weapons = new HashSet<Weapon>() },
                new WeaponType() { Id = 2, Name = "Weapon Type 2", Weapons = new HashSet<Weapon>() },
                new WeaponType() { Id = 3, Name = "Weapon Type 3", Weapons = new HashSet<Weapon>() }
            };

            return weaponTypes;
        }

        [Fact]
        public async Task Test_POST_PostWeaponType()
        {
            string testName = "Weapon Name 1";
            int testId = 1;
            var mockWeaponType = new WeaponType()
            {
                Id = testId,
                Name = testName,
                Weapons = new HashSet<Weapon>()
            };
            var newWeaponType = new CreateWeaponTypeDto()
            {
                Name = testName
            };
            var mockRepo = new Mock<IWeaponTypeRepository>();
            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<WeaponType>())).ReturnsAsync(mockWeaponType);
            var controller = new WeaponTypeController(mockRepo.Object);

            var result = await controller.PostWeaponType(newWeaponType);
            var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var weaponTypeDto = Assert.IsType<WeaponTypeDto>(actionResult.Value);
            Assert.Equal(testId, weaponTypeDto.Id);
            Assert.Equal(testName, weaponTypeDto.Name);
        }

        [Fact]
        public async Task Test_PUT_PutWeaponType_Ok()
        {
            string testName = "Weapon Name 1";
            int testId = 1;
            var mockWeaponType = new WeaponType()
            {
                Id = testId,
                Name = testName,
                Weapons = new HashSet<Weapon>()
            };
            var weaponType = new UpdateWeaponTypeDto()
            {
                Id = testId,
                Name = testName
            };
            var mockRepo = new Mock<IWeaponTypeRepository>();
            mockRepo.Setup(repo => repo.GetAsync(It.IsAny<int>())).ReturnsAsync(mockWeaponType);
            mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<WeaponType>()));
            var controller = new WeaponTypeController(mockRepo.Object);

            var result = await controller.PutWeaponType(testId, weaponType);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Test_PUT_PutWeaponType_BadRequest()
        {
            string testName = "Weapon Name 1";
            int testId = 1;
            int wrongId = 123;
            var mockWeaponType = new WeaponType()
            {
                Id = testId,
                Name = testName,
                Weapons = new HashSet<Weapon>()
            };
            var weaponType = new UpdateWeaponTypeDto()
            {
                Id = testId,
                Name = testName
            };
            var mockRepo = new Mock<IWeaponTypeRepository>();
            mockRepo.Setup(repo => repo.GetAsync(It.IsAny<int>())).ReturnsAsync(mockWeaponType);
            mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<WeaponType>()));
            var controller = new WeaponTypeController(mockRepo.Object);

            var result = await controller.PutWeaponType(wrongId, weaponType);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Test_DELETE_DeleteWeaponType()
        {
            int testId = 1;
            var mockRepo = new Mock<IWeaponTypeRepository>();
            mockRepo.Setup(repo => repo.DeleteAsync(It.IsAny<int>())).Verifiable();
            var controller = new WeaponTypeController(mockRepo.Object);

            await controller.DeleteWeaponType(testId);

            mockRepo.Verify();
        }
    }
}