using ContosoPizza.Models;

namespace ContosoPizza.Services;

public static class PizzaService
{
    static List<Pizza> Pizzas { get; }
    static int nextId = 3;
    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza {Id = 1, Name = "Classic Italian", IsGlutenFree = false},
            new Pizza {Id = 2, Name = "Veggie", IsGlutenFree = true}
        };

    }

    public static List<Pizza> GetAll() => Pizzas;
    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Delete(int id)
    {
        //Tutorial had var but I went with Pizza nullable for better readability.
        Pizza? pizza = Get(id);
        if(pizza is null) return;

        //If the pizza is found, remove it from the list.
        Pizzas.Remove(pizza);
    }

    //If we find the pizza in the list, update it.
    public static void Update(Pizza pizza)
    {
        //The tutorial had var but I like strongly typed variables so I put int.
        int index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if(index == -1) return;

        Pizzas[index] = pizza;
    }

    //Testing Lambda functions
    public static void RemoveAll(bool statusType)
    {
        Pizzas.RemoveAll(pizza => pizza.IsGlutenFree == statusType);
    }
}