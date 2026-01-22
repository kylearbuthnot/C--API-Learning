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

    // PUT action

    // DELETE action

}