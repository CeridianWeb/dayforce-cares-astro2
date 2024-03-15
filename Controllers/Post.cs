using Newtonsoft.Json;
using Sanity.Linq;
using Sanity.Linq.CommonTypes;

namespace dotnet_astro.Controllers;

public class Post
{
    [JsonProperty("_id")]
    public required string _id { get; set; }

    [JsonProperty("_type")]
    public string DocumentType => "post";

    public required string Title { get; set; }

    public required SanityReference<Author> Author { get; set; }
    public required object[] Body { get; set; }
    public required SanitySlug Slug { get; set; }
}

public class Author
{
    [JsonProperty("_id")]
    public required string _id { get; set; }

    [JsonProperty("_type")]
    public string DocumentType => "author";
    public required string Name { get; set; }

    public required SanitySlug Slug { get; set; }

    [Include]
    public required List<SanityReference<Category>> FavoriteCategories { get; set; }

    [Include]
    public required SanityImage[] Images { get; set; }

    public required object[] Bio { get; set; }
}

public class Category
{
           /// <summary>
        /// Use of JsonProperty to serialize to Sanity _id field.
        /// A alternative to inheriting SanityDocument class
        /// </summary>
        [JsonProperty("_id")]
        public required string CategoryId { get; set; }

        /// <summary>
        /// Type field is also required
        /// </summary>
        [JsonProperty("_type")]
        public string DocumentType => "category";

        public int InternalId { get; set; }

        public required string Title { get; set; }

        public required string Description { get; set; }

        public string[] Tags { get; set; } = new string[0];

        public int[] Numbers { get; set; } = new int[0];

        public required List<Category> SubCategories { get; set; }

        [Include]
        public required SanityImage MainImage { get; set; }
}