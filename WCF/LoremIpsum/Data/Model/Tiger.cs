using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WCF.LoremIpsum.Data.Model
{
    public class Tiger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TigerId { get; set; }

        public string Color { get; set; }
    }
}
