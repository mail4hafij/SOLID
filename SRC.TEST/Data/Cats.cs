using SRC.HelloWorld.Data.Model;
using System.Collections.Generic;

namespace SRC.TEST.Data
{
    public class Cats
    {
        public Cats()
        {
            White = new Cat()
            {
                Color = "White"
            };

        }

        public IList<Cat> _All => new[]
        {
            White
        };

        public Cat White { get; set; }
    }
}
