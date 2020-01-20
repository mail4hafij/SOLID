using SRC.LoremIpsum.Data.Model;
using System.Collections.Generic;

namespace SRC.TEST.Data
{
    public class Tigers
    {
        public Tigers()
        {
            Yellow = new Tiger()
            {
                Color = "Yellow"
            };

        }

        public IList<Tiger> _All => new[]
        {
            Yellow
        };

        public Tiger Yellow { get; set; }
    }
}
