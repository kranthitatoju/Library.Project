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
    public class AuthorController : ApiController
    {
        private AuthorActions AuthorApiActions;

        public AuthorController()
        {
            AuthorApiActions = new AuthorActions();
        }
        public IEnumerable<AuthorModel> Get()
        {
            return AuthorApiActions.GetAllAuthors();
        }
        public AuthorModel Get(string Id)
        {
           
            return AuthorApiActions.GetAuthorByName(Id);
        }

        public void Post([FromBody]AuthorModel _Author)
        {

           AuthorApiActions.AddAuthor(_Author);
        }
        [System.Web.Http.HttpPut]
        public void Put(int Id,[FromBody]AuthorModel _Author)
        {

            AuthorApiActions.UpdateAuthor(Id,_Author);
        }

        public void Delete(int id)
        {
            AuthorApiActions.RemoveAuthorById(id);
        }
    }
}
