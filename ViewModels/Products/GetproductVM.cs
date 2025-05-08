using ProniaBB209.Models;

namespace ProniaBB209.ViewModels.Products
{
    public class GetproductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
       

        //relational propertiler
       
        public string CategoryName { get; set; }
        public string MainImages { get; set; }
    }
}
