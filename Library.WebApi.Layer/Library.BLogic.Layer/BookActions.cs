using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DB.Layer;
using System.Data;
using Library.BLogic.Layer.Models;
using AutoMapper;

namespace Library.BLogic.Layer
{
    public class BookActions
    {
        private libraryEntities LbEntity;
        private BookModel BookBl;
        private List<BookModel> listBookBl;
        private List<Book> listBook;
        private Book BookDl;
        public BookActions()
        {
            LbEntity = new libraryEntities();
        }
        public IEnumerable<BookModel> GetAllBooks()
        {
            listBook = LbEntity.Books.ToList();
            Mapper.Initialize(MapAuth => {MapAuth.CreateMap<Book, BookModel>(); });
            listBookBl = Mapper.Map<List<BookModel>>(listBook);
            return listBookBl;
        }
        public BookModel GetBookByAuthorName(string _Name)
        {
            AuthorActions AuthAction = new AuthorActions();
            int id = AuthAction.GetAuthorByName(_Name).Id;
            var Book = LbEntity.Books.FirstOrDefault(books => books.AuthorId == id);
            Mapper.Initialize(mapAuth => { mapAuth.CreateMap<Book, BookModel>(); });
            BookBl = Mapper.Map<BookModel>(Book);
            return BookBl;

        }
    }
}
