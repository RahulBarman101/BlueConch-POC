using AutoMapper;
using EcommerceAPI.DTOs;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UserController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var users = await context.tblUser.ToListAsync();
            return mapper.Map<List<UserDTO>>(users);
        } 

        [HttpGet("{id}",Name = "getUser")]
        public ActionResult<UserDTO> Get(int id)
        {
            var user = context.tblUser.FirstOrDefault(x => x.userid == id);
            if(user == null)
            {
                return NotFound();
            }

            return mapper.Map<UserDTO>(user);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserCreationDTO userCreationDTO)
        {
            var user = mapper.Map<User>(userCreationDTO);
            if(user == null)
            {
                return BadRequest();
            }
            user.userid = context.tblUser.Max(x => x.userid) + 1;
            user.created_on = DateTime.Now.Date;
            user.updated_on = DateTime.Now.Date;
            context.Add(user);
            await context.SaveChangesAsync();
            var userDTO = mapper.Map<UserDTO>(user);
            return new CreatedAtRouteResult("getUser", new { id = userDTO.userid }, userDTO);
        }
    }
}
