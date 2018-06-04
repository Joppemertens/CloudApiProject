using Microsoft.AspNetCore.Mvc;
using Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[Route("api/v1/car")]

public class CarController :Controller
{
    private readonly LibraryContext context;

    public CarController(LibraryContext context)
    {
        this.context =context;
    }

    [HttpGet]

    public List<Car> GetAllCars(string model,string type,int? horsepower,int? page,int length =4)
    {


        IQueryable<Car> query = context.Car;
        if (!string.IsNullOrWhiteSpace(model))
        {
            query = query.Where(car => car.Model == model);
        }
        if (!string.IsNullOrWhiteSpace(type))
        {
            query = query.Where(car => car.Type == type);
        }
        if (horsepower.HasValue)
        {
            query = query.Where(car => car.Horsepower == horsepower);
        }

        if (page.HasValue)
        {
            query =query.Skip(page.Value*length);
        }
        query = query.Take(length);
        return query.ToList();


    }

       
    

    //find on id
    [Route("{id}")]
            [HttpGet]

            public IActionResult getCar(int id)
            {
                var car =context.Car
                                .Include(cr =>cr.Model)
                                .Include(cr => cr.Manufacturer)
                                .SingleOrDefault(cr => cr.Id ==id);
                if (car==null)
                {
                    return NotFound();
                }
                return Ok(car);
            }

            [HttpPost]

            public IActionResult CreateCar([FromBody]Car newCar)
                    {
                         context.Car.Add(newCar);
                         context.SaveChanges();

                        return Created("",newCar);
                    }

            public IActionResult DeleteCar(int id)
            {
                var car =context.Car.Find(id);
                if (car==null){
                    return NotFound();

                }

                context.Car.Remove(car);
                context.SaveChanges();

                return NoContent();
            }

            [HttpPut]
            //pas car aan 
            public IActionResult UpdateCar([FromBody] Car updatedCar){
                
                var oldCar =context.Car.Find(updatedCar.Id);

                if (oldCar ==null)
                {
                    return NotFound();
                            }      
                oldCar.Model =updatedCar.Model;
                oldCar.Type =updatedCar.Type;
                oldCar.Horsepower =updatedCar.Horsepower;
                oldCar.Manufacturer =updatedCar.Manufacturer;

                context.SaveChanges();
                return Ok(oldCar);      
    }
    }
    
