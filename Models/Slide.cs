using Microsoft.Data.SqlClient;
using ProniaBB209.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProniaBB209.Models
{
    public class Slide:BaseEntity
    {
        [MaxLength (175,ErrorMessage ="Slide title must be less than 175 characters")]
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Describtion { get; set; }
        public string Image { get; set; }

        //Order vasitesile siralayacam
        public int Order { get; set; }
        //SQle cevirmemek ucun Notmappedden istifade olunur, yeni ancaq c# terefde olsun deye
        [NotMapped]
        public IFormFile Photo { get; set; }
      

    }
}
