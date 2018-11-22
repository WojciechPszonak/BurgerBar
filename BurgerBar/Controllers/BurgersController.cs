using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BurgerBar.Data;
using BurgerBar.Entities;
using BurgerBar.Services;
using AutoMapper;
using BurgerBar.ViewModels;

namespace BurgerBar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BurgersController : ControllerBase
    {
        private readonly IBurgersService _burgersService;
        private readonly IMapper _mapper;

        public BurgersController(IBurgersService burgersService, IMapper mapper)
        {
            _burgersService = burgersService;
            _mapper = mapper;
        }

        // GET: api/Burgers
        [HttpGet]
        public async Task<IEnumerable<BurgerDTO>> GetAllBurgersAsync()
        {
            var burgers = await _burgersService.GetAllAsync();
            var model = _mapper.Map<IEnumerable<BurgerDTO>>(burgers);
            return model;
        }

        // GET: api/Burgers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBurger([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var burger = await _burgersService.GetAsync(id);

            if (burger == null)
            {
                return NotFound();
            }

            return Ok(burger);
        }

        // PUT: api/Burgers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBurger([FromRoute] long id, [FromBody] Burger burger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != burger.Id)
            {
                return BadRequest();
            }

            burger = await _burgersService.UpdateAsync(id, burger);

            if (burger == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<BurgerDTO>(burger);

            return Ok(model);
        }

        // POST: api/Burgers
        [HttpPost]
        public async Task<IActionResult> PostBurger([FromBody] Burger burger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _burgersService.AddAsync(burger);
            var model = _mapper.Map<BurgerDTO>(burger);

            return CreatedAtAction("GetBurger", new { id = burger.Id }, model);
        }

        // DELETE: api/Burgers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBurger([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var burger = await _burgersService.DeleteAsync(id);
            if (burger == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<BurgerDTO>(burger);

            return Ok(model);
        }
    }
}