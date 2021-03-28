using AutoMapper;
using EcommerceAPI.DTOs;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    [ApiController]
    [Route("api/item")]
    public class ItemController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ItemController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemDTO>>> Get()
        {
            var items = await context.tblItem.ToListAsync();
            return mapper.Map<List<ItemDTO>>(items);
        }

        [HttpGet("{id}", Name = "getItem")]
        public ActionResult<ItemDTO> Get(int id)
        {
            var item = context.tblItem.FirstOrDefault(x => x.itemid == id);
            if (item == null)
            {
                return NotFound();
            }

            return mapper.Map<ItemDTO>(item);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ItemCreationDTO itemCreationDTO)
        {
            var item = mapper.Map<Item>(itemCreationDTO);
            if (item == null)
            {
                return BadRequest();
            }
            item.itemid = context.tblItem.Select(x => x.itemid).Max() + 1;
            context.Add(item);
            await context.SaveChangesAsync();
            var itemDTO = mapper.Map<ItemDTO>(item);
            return new CreatedAtRouteResult("getItem", new { id = itemDTO.itemid }, itemDTO);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<ItemPatchDTO> patchDocument)
		{
            if(patchDocument == null)
			{
                return BadRequest();
			}
            var entity = await context.tblItem.FirstOrDefaultAsync(x => x.itemid == id);
            if(entity == null)
			{
                return NotFound();
			}
            var entityDTO = mapper.Map<ItemPatchDTO>(entity);
            patchDocument.ApplyTo(entityDTO,ModelState);
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

