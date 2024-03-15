using Microsoft.AspNetCore.Mvc;
using Sanity.Linq;

namespace dotnet_astro.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Post> Get()
    {
        //todo: SOLID principles
        var options = new SanityOptions
        {
            ProjectId = "w9laq4b2",
            Dataset = "production",
            Token =
                "sk08qVijzkKHhLNzdvspk0fXM5fsH5UH1qdtQpmWx90fIsrJouQyYrtFOHVZpzZtHoEXuRbTxL3h6W22JrGv0ZK6q3Ed2bUziQqZhvmJ6pyuB0ThxGWOuDGlas1oVIuYJXrCvKYFqfWX5IDqNWYNed4wLymQnzFfczNfADQUu5p8xJEqKilE",
            UseCdn = false,
            ApiVersion = "v1"
        };

        var sanity = new SanityDataContext(options);
  
        var posts = sanity.DocumentSet<Post>().ToList();

        return posts.ToList();
    }
}
