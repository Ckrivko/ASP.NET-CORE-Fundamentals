using System.ComponentModel.DataAnnotations;

namespace TextSpliter.Models
{
    public class TextSplitViewModel
    {
        [StringLength(30,MinimumLength =2)]
        public string Text { get; set; }  = null!;


        public string? SplitText { get; set; } 

    }
}
