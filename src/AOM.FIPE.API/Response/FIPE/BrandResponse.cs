using Refit;

namespace AOM.FIPE.API.Response.FIPE
{
    public class BrandResponse
    {
        public List<Brand>  Brands { get; set; }
    }

    public class Brand 
    {
        [AliasAs("codigo")]
        public string Codigo { get; set; }

        [AliasAs("nome")]
        public string Nome { get; set; }
    }
}
