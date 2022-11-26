using Moq;
using SearchServiceLSM.Controllers;
using SearchServiceLSM.Models;
using SearchServiceLSM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchServiceTest.Service
{
    internal class SearchServiceTests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task SearchService_Search_ShouldBeSuccessful()
        {
            var searchService = new SearchService();

            var result = await searchService.Search("Head Office");

            Assert.IsNotEmpty(result);

        }
    }
}
