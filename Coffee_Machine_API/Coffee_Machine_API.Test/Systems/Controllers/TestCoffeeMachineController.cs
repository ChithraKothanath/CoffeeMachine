using Coffee_Machine_API.Controllers;
using Coffee_Machine_API.Models;
using Coffee_Machine_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.CodeCoverage;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Coffee_Machine_API.Test.Systems.Controllers
{
    public class TestCoffeeMachineController
    {

        public TestCoffeeMachineController() { }

        [Fact]
        public void GetBrewCoffee_ShouldReturn200StatusOK()
        {
            ///Arrange
            var coffeeservice = new Mock<ICoffeeService>();
            coffeeservice.Setup(_ => _.GetBrewCoffeeCount()).Returns(1);
            var sut = new CoffeeMachineController(coffeeservice.Object);

            ///Act
            var result = sut.GetBrewCoffee();

            ///Assert
            result.GetType().Equals(typeof(OkObjectResult));
            ((OkObjectResult)result).Value.Should().BeOfType<BrewCoffee>();
            ((BrewCoffee)((OkObjectResult)result).Value).message.Equals("Your piping hot coffee is ready");
            var statuscode = (result as OkObjectResult).StatusCode;
            Assert.Equal(200, statuscode);
           
        }
        [Fact]
        public void GetBrewCoffee_ShouldReturn503Status()
        {
            ///Arrange
            var coffeeservice = new Mock<ICoffeeService>();
            coffeeservice.Setup(_ => _.IsResetCoffeeMachine()).Returns(true);
            var sut = new CoffeeMachineController(coffeeservice.Object);

            ///Act
            var result = sut.GetBrewCoffee();

            ///Assert
            var statuscode = (result as ObjectResult).StatusCode;
            Assert.Equal(503, statuscode);


        }
        [Fact]
        public void GetBrewCoffee_ShouldReturn418Status()
        {
            ///Arrange

            var coffeeservice = new Mock<ICoffeeService>();
            coffeeservice.Setup(_ => _.IsAprilFirst()).Returns(true);
            var sut = new CoffeeMachineController(coffeeservice.Object);

            ///Act
            var result = sut.GetBrewCoffee();


            ///Assert
            var statuscode = (result as ObjectResult).StatusCode;
            Assert.Equal(418, statuscode);

        }
    }
}
