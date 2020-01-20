using SRC.HelloWorld.Data.Model;
using System.Collections.Generic;

namespace SRC.TEST.Data
{
    public class Dogs
    {
        public Dogs()
        {
            Black = new Dog()
            {
                Color = "Black"
            };

        }

        public IList<Dog> _All => new[]
        {
            Black
        };

        public Dog Black { get; set; }
    }
}
