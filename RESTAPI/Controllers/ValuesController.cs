using API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private IAnimalService _animalService;

        public ValuesController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            var catColor = _animalService.GetCat(new API.Contracts.Cat.Messaging.GetCatReq()).Cat.Color;
            var dogColor = _animalService.GetDog(new API.Contracts.Dog.Messaging.GetDogReq()).Dog.Color;
            var tigerColor = _animalService.GetTiger(new API.Contracts.Tiger.Messaging.GetTigerReq()).Tiger.Color;

            return new string[] { catColor, dogColor, tigerColor };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
