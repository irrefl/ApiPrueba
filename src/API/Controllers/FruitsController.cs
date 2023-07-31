
using API.Models;
using BusinessLogic.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitsController : ControllerBase
    {
        IServiceWrapper _serviceWrapper;
        public FruitsController(IServiceWrapper service)
        {
            _serviceWrapper = service;
        }

        [HttpGet]
        public async Task<ActionResult> FindAllFruits()
        {
            var fruits = await _serviceWrapper.Fruits.GetAll();
            var fruitDTOs = fruits.Select(f => new FruitDTO
            {
                FruitId = f.FruitId,
                Name = f.Name,
                Description = f.Description
            }).ToList();

            return Ok(fruitDTOs);
        }

        [HttpGet("FindAllFruitsTypes")]
        public async Task<ActionResult> FindAllFruitsTypes()
        {
            var fruits = await _serviceWrapper.FruitTypes.GetAll();
            var fruitDTOs = fruits.Select(f => new FruitTypeDTO
            {
                FruitTypeId = f.FruitTypeId,
                Name = f.Name,
                Description = "no description"

            }).ToList();

            return Ok(fruitDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> FindFruitById(string id)
        {
            try
            {
                var fruit = await _serviceWrapper.Fruits.GetByIdAsync(id);
                var fruitDTO = new FruitDTO
                {
                    FruitId = fruit.FruitId,
                    Name = fruit.Name,
                    Description = fruit.Description
                };
                return Ok(fruitDTO);
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine(ex);
                return NotFound(new
                {
                    status = 404,
                    msg = "Fruit not found",
                    date = DateTime.UtcNow
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult> SaveFruit([FromBody] FruitDTO fruitDTO)
        {
           
            Fruit fruit = new Fruit
            {
                FruitId = fruitDTO.FruitId,
                Name = fruitDTO.Name ?? "no data",
                FruitType = new FruitType
                {
                    FruitTypeId = 1,
                    Name = "Vegetable"
                },
                Description = fruitDTO.Description ?? "no Description"
            };

            await _serviceWrapper.Fruits.CreateAsync(fruit);

            FruitDTO fruitCreated = new FruitDTO
            {
                FruitId = fruit.FruitId,
                Name = fruit.Name,
                Description = fruit.Description
            };

            return CreatedAtAction(nameof(FindFruitById), new { id = fruitCreated.FruitId }, fruitCreated);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFruit(string id, [FromBody] FruitDTO fruitDTO)
        {
            var fruit = new Fruit
            {
                Id = id,
                Name = fruitDTO.Name ?? "no Name",
                FruitType = new FruitType(),
                Description = fruitDTO.Description ?? "No Description"
            };
            await _serviceWrapper.Fruits.UpdateAsync(fruit);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFruit(string id)
        {
            try
            {
                await _serviceWrapper.Fruits.DeleteAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine(ex);
                return NotFound(new
                {
                    status = 404,
                    msg = "Fruit not found",
                    date = DateTime.UtcNow
                });
            }
        }
    }

}
