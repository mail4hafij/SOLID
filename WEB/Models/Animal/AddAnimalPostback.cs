using WEB.LIB;

namespace WEB.Models.Animal
{
    public class AddAnimalPostback : IPostback<AddAnimalForm>
    {
        public AddAnimalForm Form { get; set; }
    }
}