using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using ContosoPizza.Services;


namespace ContosoPizza.Controllers;

[ApiController]

//Defines a mapping to this class. Because this controller class is named PizzaController,
//this controller handles requests to https://localhost:{PORT}/pizza
// ("[controller]") says chop the controller substring from the PizzaController class name.
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        Pizza? pizza = PizzaService.Get(id);
        if(pizza is null) return NotFound();

        return pizza;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    // PUT action
    [HttpPut("{id}")] //Don't forget, this id comes from the URL. 
                     // ASP.NET Then places this id into the int id parameter.
    public IActionResult Update(int id, Pizza pizza)
    {
        //Ensure that the pizza id matches our URL.
        if(id != pizza.Id) return BadRequest(); // (400 code)

        //If the pizza we are looking for is null, return not found status code.
        Pizza? existingPizza = PizzaService.Get(id);
        if(existingPizza is null) return NotFound(); // (404 code)

        //Other wise update the pizza, then return NoContent. (204 code)
        PizzaService.Update(pizza);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Pizza? pizza = PizzaService.Get(id);

        if(pizza is null) return NotFound(); // (404) code

        PizzaService.Delete(id);

        return NoContent(); // (204) code
    }

}