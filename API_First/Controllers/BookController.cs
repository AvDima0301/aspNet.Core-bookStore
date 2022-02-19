using API_First.Dto;
using API_First.Entities;
using API_First.Entities.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_First.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookContext context;

        public BookController(BookContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return context.Books.Include(x => x.Author).ToList();
        }

        [HttpPost]
        [Route("AddBook")]
        public ActionResult AddBook(AddBookDto book)
        {
            if (book != null)
            {
                Book bk = new Book() { Title = book.Title, Description = book.Description, Image = book.Image, Year = book.Year, Author = context.Authors.FirstOrDefault(x => x.FullName == book.AuthorName) };
                context.Books.Add(bk);

                context.SaveChanges();
                return new OkResult();
            }
            return new BadRequestResult();
        }

        [HttpDelete]
        [Route("DeleteBook/{id}")]
        public ActionResult DeleteBook([FromRoute] int id)
        {
            if (id != 0 && id > 0)
            {
                context.Books.Remove(context.Books.FirstOrDefault(x => x.Id == id));

                context.SaveChanges();
                return new OkResult();
            }
            return new BadRequestResult();
        }

        [HttpPost]
        [Route("EditBook")]
        public ActionResult EditBook([FromBody] EditBookDto book)
        {
            if(book != null)
            {
                Book bk = new Book() {Id = book.Id, Title = book.Title, Description = book.Description, Image = book.Image, Year = book.Year, Author = context.Authors.FirstOrDefault(x => x.FullName == book.AuthorName) };

                context.Books.Update(bk);
                context.SaveChanges();
                return new OkResult();
            }
            return new BadRequestResult();
        }


        [HttpGet]
        [Route("getSingleBook/{id}")]
        public Book getSingleBook([FromRoute] int id)
        {
            if(id != 0)
            {
                return context.Books.FirstOrDefault(x => x.Id == id);
            }

            return null;
        }
    }

    
}
