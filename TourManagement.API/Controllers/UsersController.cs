
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManagement.API.Entities;
using TourManagement.API.Helpers;

namespace TourManagement.API.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        IUsersRepository _UsersRepository;
        ILogger _Logger;

        public UsersController(IUsersRepository usersRepo, ILoggerFactory loggerFactory) {
            _UsersRepository = usersRepo;
            _Logger = loggerFactory.CreateLogger(nameof(UsersController));
        }

        // GET api/users
        [HttpGet(Name = "GetUsers")]
        //[NoCache]
        //[ProducesResponseType(typeof(List<User>), 200)]
        //[ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> GetUsers(UserResourceParameters usersResourceParameters)
        {
            try
            {
                var users =  await _UsersRepository.GetUsersAsync(usersResourceParameters);
                return Ok(users);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }


        // GET api/users?firstname=xx
        [HttpGet("{id}", Name = "GetUserRoute")]
        [NoCache]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> Users(int id)
        {
            try
            {
                var user = await _UsersRepository.GetUserAsync(id);
                return Ok(user);

            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        // POST api/users
        [HttpPost]
     //   [ValidateAntiForgeryToken]
        [ProducesResponseType(typeof(ApiResponse), 201)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> CreateUser([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse { Status = false, ModelState = ModelState });
            }

            try
            {
                var newUser = await _UsersRepository.InsertUserAsync(user);
                if (newUser == null)
                {
                    return BadRequest(new ApiResponse { Status = false });
                }
                return CreatedAtRoute("GetUserRoute", new { id = newUser.Id },
                        new ApiResponse { Status = true });
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        // PUT api/users/5
        [HttpPut("{id}")]
    //    [ValidateAntiForgeryToken]
        ////[ProducesResponseType(typeof(ApiResponse), 200)]
        ////[ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> UpdateUser(int id, [FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse { Status = false, ModelState = ModelState });
            }

            try
            {
                var status = await _UsersRepository.UpdateUserAsync(user);
                if (!status)
                {
                    return BadRequest(new ApiResponse { Status = false });
                }
                return Ok(new ApiResponse { Status = true });//, User = user });
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var status = await _UsersRepository.DeleteUserAsync(id);
                if (!status)
                {
                    return BadRequest(new ApiResponse { Status = false });
                }
                return Ok(new ApiResponse { Status = true });
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

    }
}
