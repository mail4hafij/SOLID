using System.ComponentModel.DataAnnotations;

namespace WEB.Models.Animal
{
    public class AddAnimalForm
    {
        [Required(ErrorMessage = @"missing")]
        public string CatColor { get; set; }

        [Required(ErrorMessage = @"missing")]
        public string DogColor { get; set; }

        [Required(ErrorMessage = @"missing")]
        public string TigerColor { get; set; }
    }
}