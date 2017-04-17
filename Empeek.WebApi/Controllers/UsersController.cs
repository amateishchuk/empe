using Empeek.Domain.Abstract;
using Empeek.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Empeek.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        IOwnerRepository repository;
        public UsersController(IOwnerRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            var users = repository.Users.Select(u => new
            {
                Id = u.Id,
                Name = u.Name,
                PetsCount = u.Pets.Count
            }).OrderBy(u => u.Name).ThenBy(u => u.PetsCount).ToList();

            return users;
        }

        [HttpGet]
        public User Get(int id)
        {
            return repository.Users.FirstOrDefault(u => u.Id == id);
        }

        [HttpPost]
        public HttpResponseMessage Post(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.AddUser(user);
                    return Request.CreateResponse(HttpStatusCode.Created, user);
                }
                catch (Exception)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "The user with current name is exist");
                    return response;
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            User user = repository.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            repository.DeleteUser(user);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
    }
}
