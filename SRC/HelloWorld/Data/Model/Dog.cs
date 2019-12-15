using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRC.HelloWorld.Data.Model
{
    public class Dog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DogId { get; set; }

        public string Color { get; set; }
    }
}
