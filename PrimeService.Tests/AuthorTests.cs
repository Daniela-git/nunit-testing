using System.Net;
using FluentAssertions;
using RestSharp;
using PrimeService.DataModels;
using Newtonsoft.Json;
using Allure.NUnit;
using Allure.NUnit.Attributes;

namespace PrimeService.Tests;

[AllureNUnit]
[AllureSuite("Authors")]
[TestFixture]
public class AuthorTests
{
    private APIService _apIService;

    [SetUp]
    public void Setup()
    {
        _apIService = new APIService();
    }

    [Test(Description = "Validate search authors returns 200")]
    public void AuthorScenario1()
    {
        RestResponse result = _apIService.SearchAuthors();
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test(Description = "Validate search authors returns a not null array of authors")]
    public void AuthorScenario2() 
    {
        RestResponse result = _apIService.SearchAuthors();
        result.Should().NotBeNull();
        List<Author> authors = JsonConvert.DeserializeObject<List<Author>>(result.Content);
        authors.Should().NotBeEmpty();
    }
}
