using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //create list of users
        private static List<User> users = new List<User>
                {
                    new User {
                        Id = 1,
                        Name = "Jeral Sandeeptha",
                        Email = "jeral.sandeeptha1@gmail.com",
                        Age = 23
                    },
                    new User {
                        Id = 2,
                        Name = "Yohan Sandeepa",
                        Email = "yohan.sandeepa@gmail.com",
                        Age = 23
                    }
                };

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            //create a response object
            var response = new {
                StatusCode = 200,
                Message = "Get all users query was successful",
                Data = users,
            };

            //return response object
            return Ok(response);
        }

        [HttpPost]
        public Task<IActionResult> CreateUser(User user)
        {
            //add new user to users list
            users.Add(user);

            //create a response object
            var response = new
            {
                StatusCode = 201,
                Message = "Create new user query was successful",
                Data = user,
            };

            return Task.FromResult<IActionResult>(Ok(response));
        }

        [HttpGet("{id}")]
        public IActionResult GetSingleUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);

            // create a response object
            var response = new
            {
                StatusCode = 200,
                Message = "Get single user query was successful",
                Data = user,
            };

            var notFoundResponse = new
            {
                StatusCode = 404,
                Message = "Get single user query was failed. User not found.",
            };

            if (user == null)
            {
                return NotFound(notFoundResponse);
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(User user)
        {
            var findUser = users.FirstOrDefault(u => u.Id == user.Id);
            findUser.Name = user.Name;
            findUser.Email = user.Email;
            findUser.Age = user.Age;
            // create a response object
            var response = new
            {
                StatusCode = 200,
                Message = "Update user query was successful",
                Data = findUser,
            };

            var notFoundResponse = new
            {
                StatusCode = 404,
                Message = "Updaye user query was failed. User not found.",
            };
            if (user == null)
            {
                return NotFound(notFoundResponse);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            users.Remove(user); 
            // create a response object
            var response = new
            {
                StatusCode = 200,
                Message = "Delete user query was successful",
                Data = user,
            };

            var notFoundResponse = new
            {
                StatusCode = 404,
                Message = "Delete query was failed. User not found.",
            };
            if (user == null)
            {
                return NotFound(notFoundResponse);
            }

            return Ok(response);
        }
    }
}
