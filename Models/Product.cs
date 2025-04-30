namespace ProniaBB209.Models
{
    public class Product:BaseEntity
    {
       // public List<string> Image { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }

        //relational propertiler
        public int CategoryId { get; set; }
        public Category Category { get; set; } //sorgu atanda daha rahat idare ede biecem bunun vasitesile

        public List<ProductImage> ProductImages { get; set; }
    }
}
