using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SearchServiceLSM.Controllers;
using SearchServiceLSM.Models;
using SearchServiceLSM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchServiceTest.Controller
{
    internal class SearchControllerTests
    {
        private Mock<ISearchService> searchServiceMock;

        [Test]
        public async Task SearchController_Search_ShouldBeSuccessFul()
        {
            searchServiceMock = new Mock<ISearchService>();

            searchServiceMock.Setup(x => x.Search(It.IsAny<string>())).ReturnsAsync("1");

            var controller = new SearchController(searchServiceMock.Object);

            var result = (await controller.Search("entry")) as OkObjectResult;

            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            Assert.AreEqual("1", result.Value.ToString());
        }
    }
}
