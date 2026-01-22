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
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        // This code will update the pizza and return a result.
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        // This code will delete the pizza and return a result.
    }

}