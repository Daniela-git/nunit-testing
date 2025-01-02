using System.Net;
using FluentAssertions;
using RestSharp;
using PrimeService.DataModels;
using Newtonsoft.Json;
using Allure.NUnit;
using Allure.NUnit.Attributes;

namespace PrimeService.Tests;

[AllureNUnit]
[AllureSuite("Books")]
[TestFixture]
public class BookTests
{
    private APIService _apIService;
    
    [SetUp]
    public void Setup()
    {
        _apIService = new APIService();
    }

    [Test(Description = "Validate search books returns 200")]
    public void BooksScenario1()
    {
        RestResponse result = _apIService.SearchBooks();
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test(Description = "Validate search authors returns a not empty array")]
    public void BooksScenario2()
    {
        RestResponse result = _apIService.SearchBooks();
        result.Should().NotBeNull();
        List<Book> books = JsonConvert.DeserializeObject<List<Book>>(result.Content);
        books.Should().NotBeEmpty();
    }

    [Test(Description = "Validate it is possible to add a new book")]
    public void BooksScenario3()
    {
        RestResponse result = _apIService.AddABook();
        result.Should().NotBeNull();
        Book book = JsonConvert.DeserializeObject<Book>(result.Content);
        Book expected = _apIService.BuildBookBodyRequest();
        Assert.That(book, Is.Not.Null);
        Assert.That(book.id, Is.EqualTo(expected.id));
        Assert.That(book.title, Is.EqualTo(expected.title));
        Assert.That(book.description, Is.EqualTo(expected.description));
        Assert.That(book.pageCount, Is.EqualTo(expected.pageCount));
        Assert.That(book.excerpt, Is.EqualTo(expected.excerpt));
        Assert.That(book.publishDate, Is.EqualTo(expected.publishDate));
    }
}
