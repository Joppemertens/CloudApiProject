using System.Collections.Generic;
using System.Linq;

namespace Model

{
    public class DBinitializer
    {
        public static void Initialize(LibraryContext  context){

            //CREATE DB if not created
            context.Database.EnsureCreated();

            if(!context.Car.Any())
            {
                //creat book

                var car = new Car()
                {
                    Model="micra",
                    Manufacturer={
                        id=1,
                        Brandname="Nissan"
                        
                    },
                    Horsepower=70
                };
                context.Car.Add(car);
                context.SaveChanges();
                
                
            }
        }
    }
}