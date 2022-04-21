using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.Models;
using UsersApi.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userServices;
        public UsersController(IUserRepository userServices) =>
            _userServices = userServices;
        
        /// <summary>
        /// Get all records 
        /// </summary>
        
        [HttpGet]
        public ActionResult<List<User>> GetAllUserDetails()
        {
            return _userServices.GetAllUser();
        }


        /// <summary>
        ///  Get method to get record on the basis of id
        /// </summary>
       
       

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var user = _userServices.GetUser(id);
            if(user == null)
            {
                return NotFound();
            }
            //return user;
            return Ok(user);
        }

        /// <summary>
        ///  Create method to insert enities to collection 
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody]User user)
        {
            var user1=_userServices.Create(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id}, user);
            //return Ok(user1);

        }

        /// <summary>
        ///    Update method to Update record on the basis of id
        /// </summary>
        
        [HttpPut("{id}")]
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
        
        [HttpDelete("{id}")]
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