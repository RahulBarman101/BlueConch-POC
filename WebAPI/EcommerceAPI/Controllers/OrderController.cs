using AutoMapper;
using EcommerceAPI.DTOs;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
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
    public class OrderController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public OrderController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id}",Name = "getOrders")]
        public async Task<ActionResult<List<UserDTO>>> Get(int id)
        {
            var orders = await context.tblOrder.Where(x => x.order_id == id).ToListAsync();
            if(orders == null)
            {
                return NotFound();
            }

            return mapper.Map<List<UserDTO>>(orders);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OrderCreationDTO orderCreationDTO)
        {
            var order = mapper.Map<Order>(orderCreationDTO);
            if(order == null)
            {
                return BadRequest();
            }
            order.userid = context.tblOrder.Max(x => x.userid) + 1;
            context.Add(order);
            await context.SaveChangesAsync();
            var orderDTO = mapper.Map<OrderDTO>(order);
            return new CreatedAtRouteResult("getOrder", new { id = orderDTO.order_id }, orderDTO);
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id,[FromBody] JsonPatchDocument<OrderPatchDTO> patchDocument)
		{
            if(patchDocument == null)
			{
                return BadRequest();
			}
            var entity = await context.tblOrder.FirstOrDefaultAsync(x => x.order_id == id);
            if(entity == null)
			{
                return NotFound();
			}
            var entityDTO = mapper.Map<OrderPatchDTO>(entity);
            patchDocument.ApplyTo(entityDTO, ModelState);
            var isValid = TryValidateModel(entityDTO);
            if(!isValid)
			{
                return BadRequest(ModelState);
			}
            mapper.Map(entityDTO,entity);
            await context.SaveChangesAsync();
            return NoContent();
		}
    }
}
