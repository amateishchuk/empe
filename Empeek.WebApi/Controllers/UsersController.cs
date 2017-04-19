using Empeek.Domain.Abstract;
using Empeek.Domain.Entities;
using Empeek.WebApi.Models;
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
        int size = 3;

        public UsersController(IOwnerRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public HttpResponseMessage Get(int page = 1, bool sortReverse = false)
        {
            var queryResult =
                repository.Users.Select(u => new
                {
                    Id = u.Id,
                    Name = u.Name,
                    PetsCount = u.Pets.Count
                });

            queryResult = sortReverse ? queryResult
            .OrderByDescending(u => u.Name)
            .ThenByDescending(u => u.PetsCount) :

            queryResult
            .OrderBy(u => u.Name)
            .ThenByDescending(u => u.PetsCount);

            queryResult = queryResult.Skip((page - 1) * size)
                .Take(size);

            var users = new UsersListViewModel
            {
                UsersCount = repository.Users.Count(),
                UsersArray = queryResult,
                ItemsPerPage = size,
                SortReverse = sortReverse
            };
            

            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpGet]
        public HttpResponseMessage Get(int id, int page = 1, bool sortReverse = false)
        {
            try
            {
                var user = repository.Users.Where(u => u.Id == id).Select(uvm => new UserViewModel
                {
                    Id = uvm.Id,
                    Name = uvm.Name,
                    ItemsPerPage = size,
                    SortReverse = sortReverse,
                    PetsCount = uvm.Pets.Count,
                    Pets = uvm.Pets.Select(p => new PetViewModel
                    {
                        Id = p.Id,
                        Name = p.Name
                    })
                }).Single();

                user.Pets = user.SortReverse ?
                    user.Pets.OrderByDescending(p => p.Id) :
                    user.Pets = user.Pets.OrderBy(p => p.Id);

                user.Pets = user.Pets.Skip((page - 1) * size).Take(size);

                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, e.Message);
            }
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
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            repository.DeleteUser(user);
            return Request.CreateResponse(HttpStatusCode.Gone, user);
        }
    }
}
