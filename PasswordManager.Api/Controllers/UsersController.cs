using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Api.Repositories.Contracts;
using PasswordManager.Models.Dtos;
using PasswordManager.Api.Extensions;
using PasswordManager.Api.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PasswordManager.Api.Controllers
{
    /// <summary>
    /// API Controller class for User related actions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// The repository provider for the User.
        /// </summary>
        /// <value>is a IUserRepository</value>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// User Controller Constructor
        /// </summary>
        /// <param name="userRepository">Receive the userRepository by dependency injection</param>
        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// POST method to verify if the credentials are correct
        /// </summary>
        /// <param name="signInUserDto">The credentials for the user to be authenticaded</param>
        /// <returns>A NotFound response when there is no match for the given credentials or an OK Response containing a UserDto for the valid user or an Exception</returns>
        /// <exception cref="System.Exception">when Server is not available or an internal error happen</exception>
        [HttpPost]
        public async Task<ActionResult<UserDto>> SignInUser([FromBody] SignInUserDto signInUserDto)
        {
            try
            {
                var user = userRepository.SignInUser(signInUserDto);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(new UserDto
                    {
                        Id = user.Id,
                        Image = user.Image,
                        Name = user.Name,
                        Username = user.Username,
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

