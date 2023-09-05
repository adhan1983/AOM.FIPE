namespace AOM.FIPE.WebApp.Models.Brand
{
    public class BrandResponseViewModel
    {
        public List<BrandViewModel> Brands { get; set; } = new List<BrandViewModel>();
        public int Total { get; set; }
    }

    public class BrandViewModel 
    {       
        public string Codigo { get; set; }        
        public string Nome { get; set; }
    }
}
