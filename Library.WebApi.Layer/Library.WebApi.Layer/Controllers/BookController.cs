using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Library.BLogic.Layer;
using Library.BLogic.Layer.Models;
namespace Library.WebApi.Layer.Controllers
{
    public class BookController : ApiController
    {
        private BookActions BookApiActions;

        public BookController()
        {
            BookApiActions = new BookActions();
        }
        public IEnumerable<BookModel> Get()
        {

            return BookApiActions.GetAllBooks();
        }

        public BookModel Get(string id)
        {

            return BookApiActions.GetBookByAuthorName(id);
        }
    }
}
