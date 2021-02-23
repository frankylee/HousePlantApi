using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HousePlantApi.Models;

namespace HousePlantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousePlantsController : ControllerBase
    {
        private readonly HousePlantContext _context;

        public HousePlantsController(HousePlantContext context)
        {
            _context = context;
        }

        // GET: api/HousePlants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HousePlantItemDTO>>> GetHousePlantItems()
        {
            return await _context.HousePlantItems.Select(x => ItemToDTO(x)).ToListAsync();
        }

        // GET: api/HousePlants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HousePlantItemDTO>> GetHousePlantItem(long id)
        {
            var housePlantItem = await _context.HousePlantItems.FindAsync(id);

            if (housePlantItem == null)
            {
                return NotFound();
            }

            return ItemToDTO(housePlantItem);
        }

        // PUT: api/HousePlants/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHousePlantItem(long id, HousePlantItemDTO housePlantItemDTO)
        {
            if (id != housePlantItemDTO.ID)
            {
                return BadRequest();
            }

            // The following was created on initial scaffold before modifying to use DTO
            //_context.Entry(housePlantItemDTO).State = EntityState.Modified;

            // Create a new housePlantItem with values from DTO
            var housePlantItem = await _context.HousePlantItems.FindAsync(id);
            if (housePlantItem == null)
            {
                return NotFound();
            }
            housePlantItem.CommonName = housePlantItemDTO.CommonName;
            housePlantItem.IsWatered = housePlantItemDTO.IsWatered;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HousePlantItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HousePlants
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HousePlantItemDTO>> PostHousePlantItem(HousePlantItemDTO housePlantItemDTO)
        {
            // Create new housePlantItem with values from DTO
            var housePlantItem = new HousePlantItem
            {
                CommonName = housePlantItemDTO.CommonName,
                IsWatered = housePlantItemDTO.IsWatered
            };

            _context.HousePlantItems.Add(housePlantItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHousePlantItem", new { id = housePlantItem.ID }, ItemToDTO(housePlantItem));
        }

        // DELETE: api/HousePlants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHousePlantItem(long id)
        {
            var housePlantItem = await _context.HousePlantItems.FindAsync(id);
            if (housePlantItem == null)
            {
                return NotFound();
            }

            _context.HousePlantItems.Remove(housePlantItem);
            await _context.SaveChangesAsync();

            // The following was created on initial scaffold before modifying to use DTO
            //return housePlantItem;

            return NoContent();
        }

        private bool HousePlantItemExists(long id)
        {
            return _context.HousePlantItems.Any(e => e.ID == id);
        }

        private static HousePlantItemDTO ItemToDTO(HousePlantItem plantItem) =>
        new HousePlantItemDTO
        {
            ID = plantItem.ID,
            CommonName = plantItem.CommonName,
            IsWatered = plantItem.IsWatered
        };
    }
}
