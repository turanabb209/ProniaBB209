using Microsoft.Data.SqlClient;
using ProniaBB209.Models;

namespace ProniaBB209.Models
{
    public class Slide:BaseEntity
    {
       
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Describtion { get; set; }
        public string Image { get; set; }

        //Order vasitesile siralayacam
        public int Order { get; set; }
      

    }
}
