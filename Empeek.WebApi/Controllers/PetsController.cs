using Empeek.Domain.Abstract;
using Empeek.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace Empeek.WebApi.Controllers
{
    public class PetsController : ApiController
    {
        IOwnerRepository repository;

        public PetsController(IOwnerRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(repository.Users.FirstOrDefault(u => u.Id == id));
        }

        [HttpPost]
        public HttpResponseMessage Post(Pet pet)
        {
            Pet existedPet = repository.Pets.FirstOrDefault(
                 p => p.Name == pet.Name && p.UserId == pet.UserId);
            if (ModelState.IsValid && existedPet == null)
            {
                repository.AddPet(pet);
                return Request.CreateResponse(HttpStatusCode.OK, pet);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Pet pet = repository.Pets.FirstOrDefault(u => u.Id == id);
            if (pet == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            repository.DeletePet(pet);
            return Request.CreateResponse(HttpStatusCode.OK, pet);
        }
    }
}
