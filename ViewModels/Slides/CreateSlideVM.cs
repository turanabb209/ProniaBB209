using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProniaBB209.ViewModels
{
    public class CreateSlideVM
    {
        [MaxLength(175, ErrorMessage = "Slide title must be less than 175 characters")]
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Describtion { get; set; }      
        public int Order { get; set; }
        public IFormFile Photo { get; set; }



    }
}
