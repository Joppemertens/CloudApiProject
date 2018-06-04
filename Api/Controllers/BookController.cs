using Microsoft.AspNetCore.Mvc;
using Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[Route("api/v1/book")]

public class BooksControler2 :Controller
{
    private readonly LibraryContext context;
    public BooksControler2(LibraryContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public List<Book> GetAllBooks(string genre,string title, int? page,int length =4)
    {
        IQueryable<Book> query =context.Books;

        if(!string.IsNullOrWhiteSpace(genre))
        {
            query = query.Where(bk => bk.Genre == genre);

        }
        if (!string.IsNullOrWhiteSpace(title))
        {
            query =query.Where(bk => bk.Title ==title);
        }
        if(page.HasValue)
        {
            query =query.Skip(page.Value*length);

        }
        query=query.Take(length);

        return query.ToList();
    }

    [Route("{id}")]
    [HttpGet]
    public IActionResult GetBook(int id)
    {
        var book = context.Books        
                            .Include (bk => bk.Author)
                            .SingleOrDefault(bk => bk.Id ==id);

        if (book ==null)
        {
            return NotFound();

        }
        return Ok(book);
    }



    
    [HttpPost]

    public IActionResult CreateBook([FromBody] Book newBook)
    {
        context.Books.Add(newBook);
        context.SaveChanges();

        return Created("",newBook);
    }

    [Route("{id}")]
    [HttpDelete]

    public IActionResult DeleteBook(int id)
    {
        var book = context.Books.Find(id);
        if (book ==null)
        {
            return NotFound();
        }

        //delete
        context.Books.Remove(book);
        context.SaveChanges();
        //204 bij delete
        return NoContent();

    }

    [HttpPut]
    public IActionResult UpdateBook([FromBody] Book updateBook)
    {
        var originalBook = context.Books.Find(updateBook.Id);
        if (originalBook==null)
            return NotFound();

        originalBook.Title =updateBook.Title;
        originalBook.Pages =updateBook.Pages;
        originalBook.ISBN =updateBook.ISBN;
        originalBook.Genre =updateBook.Genre;

        context.SaveChanges();
        return Ok(originalBook);
    }


}