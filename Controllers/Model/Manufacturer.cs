
using System.Collections.Generic;
namespace Model
{
    public class Manufacturer{
        public int id {get;set;}

        public string Brandname{get;set;}
       
        public ICollection<Car> Cars {get;set;}



    }
}