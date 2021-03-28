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
    [Route("api/address")]
    public class AddressController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AddressController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id}",Name = "getAddress")]
        public async Task<ActionResult<List<AddressDTO>>> Get(int id)
        {
            //var address = await context.tblAddress.FirstOrDefaultAsync(x => x.addressid == id);
            var address = await context.tblAddress.Where(x => x.userid == id).ToListAsync();
            
            if(address == null)
            {
                return NotFound();
            }
            return mapper.Map<List<AddressDTO>>(address);
        }

        [HttpGet]
        public async Task<ActionResult<List<AddressDTO>>> Get()
        {
            //var address = await context.tblAddress.FirstOrDefaultAsync(x => x.addressid == id);
            var addresses = await context.tblAddress.ToListAsync();
            return mapper.Map<List<AddressDTO>>(addresses);
        }



        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddressCreationDTO addressCreationDTO)
        {
            var address = mapper.Map<Address>(addressCreationDTO);
            address.addressid = context.tblAddress.Select(x => x.addressid).DefaultIfEmpty(0).Max() + 1;
            
            address.created_on = DateTime.Now.Date;
            address.updated_on = DateTime.Now.Date;
            context.Add(address);
            await context.SaveChangesAsync();
            var addressDTO = mapper.Map<AddressDTO>(address);
            return new CreatedAtRouteResult("getAddress", new { addressDTO.addressid }, addressDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var address = await context.tblAddress.FirstOrDefaultAsync(x => x.addressid == id);
            if(address == null)
            {
                return NotFound();
            }
            context.Remove(address);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id,[FromBody] JsonPatchDocument<AddressPatchDTO> patchDocument)
		{
            if(patchDocument == null)
			{
                return BadRequest();
			}
            var entity = await context.tblAddress.FirstOrDefaultAsync(x => x.addressid == id);
            if(entity == null)
			{
                return NotFound();
			}
            var entityDTO = mapper.Map<AddressPatchDTO>(entity);
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
