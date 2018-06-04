

using System.Collections.Generic;
namespace Model
{
    public class Author{
        public int id {get;set;}

        public string Name{get;set;}
        public string FirstName{get;set;}
        public ICollection<Book> Books {get;set;}



    }
}