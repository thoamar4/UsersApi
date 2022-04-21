using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UsersApi.Models;
using UsersApi.Services;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UsersController(IUserServices userServices) =>
            _userServices = userServices;

        /// <summary>
        /// Get All User Details
        /// </summary>
        /// <returns>List of Users</returns>        
        [HttpGet("GetAllUserDetails")]
        public ActionResult<List<User>> GetAllUserDetails()
        {
            return _userServices.GetAllUser();
        }


        /// <summary>
        /// Get method to get record on the basis of id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User basis on id</returns>

        [HttpGet("GetUser/{id}")]
         public IActionResult GetUser(int id)
        {
            var user = _userServices.GetUser(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /// <summary>
        /// Create method to insert enities to collection
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Added User</returns>
        

        [HttpPost("AddUser")]
        public IActionResult Create([FromBody]User user)
        {
            var user1=_userServices.Create(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id}, user);
           
        }

        /// <summary>
        /// Update method to Update record on the basis of id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="UserIn"></param>
        /// <returns>Update the User basis on id</returns>

        [HttpPut("UpdateUser/{id}")]
        public IActionResult Update(int id, User UserIn)
        {
            var user = _userServices.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            UserIn._Id = user._Id;
            _userServices.Update(id, UserIn);
            return NoContent();
        }

        /// <summary>
        /// delete method to delete record on the basis of id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete the User</returns>

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userServices.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            _userServices.Remove(user);
            return NoContent();
        }
        
    }
}