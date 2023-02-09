using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductApp.Application.Controllers;
using ProductApp.Application.Interfaces.Services;
using ProductApp.Application.Models;
using ProductCrud.UnitTests.Fixtures;
using Xunit;

namespace ProductCrud.UnitTests.Application.Controllers
{
    public class PutProductController
    {
        [Fact]
        public void Put_OnSuccess_ReturnsStatusCode204()
        {
            //Arrange
            var dto = ProductFixtures.PutProductDTO();
            var mockProductService = new Mock<IProductService>();
            mockProductService
                .Setup(service => service.Edit(dto))
                .Returns(true);
            var controller = new ProductsController(mockProductService.Object);
            //Act
            var result = (NoContentResult)controller.Put(dto.Id, dto);
            //Assert
            result.StatusCode.Should().Be(204);
        }

        [Fact]
        public void Put_OnInvalidId_ReturnsStatusCode400()
        {
            //Arrange
            var dto = ProductFixtures.PutProductDTO();
            var mockProductService = new Mock<IProductService>();
            mockProductService
                .Setup(service => service.Edit(dto))
                .Returns(true);
            var controller = new ProductsController(mockProductService.Object);
            //Act
            var result = (BadRequestObjectResult)controller.Put(0, dto);
            //Assert
            result.StatusCode.Should().Be(400);
        }

        [Fact]
        public void Put_OnInvalidValidateDate_ReturnsStatusCode400()
        {
            //Arrange
            var dto = ProductFixtures.PutProductDTO();
            dto.ValidateDate = dto.ValidateDate.Value.AddYears(-2);
            var mockProductService = new Mock<IProductService>();
            mockProductService
                .Setup(service => service.Edit(dto))
                .Returns(true);
            var controller = new ProductsController(mockProductService.Object);
            //Act
            var result = (BadRequestObjectResult)controller.Put(dto.Id, dto);
            //Assert
            result.StatusCode.Should().Be(400);
        }

        [Fact]
        public void Put_OnEditFailure_ReturnsStatusCode400()
        {
            //Arrange
            var dto = ProductFixtures.PutProductDTO();
            var mockProductService = new Mock<IProductService>();
            mockProductService
                .Setup(service => service.Edit(dto))
                .Returns(false);
            var controller = new ProductsController(mockProductService.Object);
            //Act
            var result = (BadRequestObjectResult)controller.Put(dto.Id, dto);
            //Assert
            result.StatusCode.Should().Be(400);
        }
    }
}
