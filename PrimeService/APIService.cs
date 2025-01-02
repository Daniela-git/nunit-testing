using RestSharp;
using PrimeService.DataModels;

namespace PrimeService
{  
    public class APIService
    {
        private string baseUrl = "https://fakerestapi.azurewebsites.net";
        private RestClient client = new RestClient();

        public RestResponse GetFakeApiResponse()
        {
            RestRequest request = new RestRequest(baseUrl, Method.Get);
            RestResponse response = client.Execute(request);
            return response;
        }

        public RestResponse SearchBooks()
        {
            RestRequest request = new RestRequest($"{baseUrl}/api/v1/Books", Method.Get);
            RestResponse response = client.Execute(request);
            return response;
        }

        public RestResponse AddABook()
        {
            RestRequest request = new RestRequest($"{baseUrl}/api/v1/Books", Method.Post);
            var body = BuildBookBodyRequest();
            request.AddBody(body, ContentType.Json);
            RestResponse response = client.Execute(request);
            return response;
        }

        public RestResponse SearchAuthors()
        {
            RestRequest request = new RestRequest($"{baseUrl}/api/v1/Authors", Method.Get);
            RestResponse response = client.Execute(request);
            return response;
        }

        public RestResponse AddAuthor()
        {
            RestRequest request = new RestRequest($"{baseUrl}/api/v1/Authors", Method.Post);
            var body = BuildAuthorBodyRequest();
            request.AddBody(body, ContentType.Json);
            RestResponse response = client.Execute(request);
            return response;
        }

        public Book BuildBookBodyRequest()
        {
            return new Book
            {
                id = 100,
                title = "Test Book",
                description = "Mussum Ipsum, cacilds vidis litro abertis.  Quem num gosta di mim que vai caçá sua turmis!",
                excerpt = "uem num gosta di mim que vai caçá sua turmis!",
                pageCount = 100,
                publishDate = "2023-09-03T13:50:32.6884665+00:00"
            };
        }

        public Author BuildAuthorBodyRequest()
        {
            return new Author
            {
                id = 100,
                idBook = 200,
                firstName = "John",
                lastName = "Smith",
            };
        }

    }
}
