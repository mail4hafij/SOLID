﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SRC.HelloWorld.Repository.Dog
{
    public class DogRepository : HelloWorldBaseRepository, IDogRepository
    {
        public DogRepository(IHelloWorldUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public List<SRC.HelloWorld.Data.Model.Dog> LoadAll()
        {
            return _unitOfWork.Context.Dogs.ToList<Data.Model.Dog>();
        }
    }
}