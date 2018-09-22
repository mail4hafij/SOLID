using API.Contracts;
using System;
using API.Contracts.Models;

namespace SRC
{
    public class AnimalService : IAnimalService
    {
        public Cat GetCat()
        {
            return new Cat() { Color = "white" };
        }

        public Dog GetDog()
        {
            return new Dog() { Color = "black" };
        }
    }
}
