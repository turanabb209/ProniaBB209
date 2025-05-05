using System.ComponentModel.DataAnnotations;

namespace ProniaBB209.Models
{
    public class Category:BaseEntity
    {
        [MinLength(3, ErrorMessage ="3-den qisa ola bilmez")]
        [MaxLength(30,ErrorMessage ="30-dan uzun ola bilmez")]

        public string Name { get; set; }
        public List<Product>? Products { get; set; }


    }
}
