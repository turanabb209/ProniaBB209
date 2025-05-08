using System.ComponentModel.DataAnnotations;

namespace ProniaBB209.ViewModels.Slides
{
    public class UpdateSlideVM
    {

        [MaxLength(175, ErrorMessage = "Slide title must be less than 175 characters")]
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Describtion { get; set; }
        public string? Image { get; set; }
        public int Order { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
