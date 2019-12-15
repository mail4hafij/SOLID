using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRC.HelloWorld.Data.Model
{
    public class Cat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CatId { get; set; }

        public string Color { get; set; }
    }
}
