
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Model;

public class BooksController :Controller{

    //this action is accesible via the url( route): localhost:5000/hi


    [Route("api/v1/books")]
    [HttpGet]

    public List<Book> GetBooks()
    {   
        var list = new List<Book>();
        list.Add(new Book()
        {
            Title ="samson en gert in de jungle",
            ISBN ="whatthefuckisisbn",
            Pages =12,
        }); 
        list.Add(new Book(){
            Title="suske en wiske",
            ISBN="keep it real please",
            Pages =30
        });
        return list;
    }
    [Route("{id}")]
    [HttpGet]
    public Book GetBook(int id){
        return new Book(){
            Id =id,
            Title="fakebook",
            
            Pages=0
        };
    }
    public void CreateBook(){

    }
    
}
