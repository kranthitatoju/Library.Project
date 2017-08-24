using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BLogic.Layer.Models;
using Library.DB.Layer;
using System.Data;
using AutoMapper;

namespace Library.BLogic.Layer
{
    public class AuthorActions
    {
         private libraryEntities LbEntity;
         private AuthorModel AuthorBl;
         private List<AuthorModel> listAuthorBl;
         private List<Author> listAuthor;
         private Author AuthorDl;
        public AuthorActions()
        {
            LbEntity = new libraryEntities();
        }
        public IEnumerable<AuthorModel> GetAllAuthors()
        {
            listAuthor =  LbEntity.Authors.ToList();
            Mapper.Initialize(MapAuth => { MapAuth.CreateMap<Author, AuthorModel>(); });
            listAuthorBl = Mapper.Map<List<AuthorModel>>(listAuthor);
            return listAuthorBl; 
        }
        public AuthorModel GetAuthorByName(string _Name)
        {
            var author = LbEntity.Authors.FirstOrDefault(auths => auths.Name == _Name);
            Mapper.Initialize(mapAuth => { mapAuth.CreateMap<Author, AuthorModel>(); });
            AuthorBl = Mapper.Map<AuthorModel>(author);
            return AuthorBl;

        }
        public void AddAuthor(AuthorModel _Author)
        {
             Mapper.Initialize(map => { map.CreateMap<AuthorModel, Author>(); });
             AuthorDl = Mapper.Map<Author>(_Author);
             LbEntity.Authors.Add(AuthorDl);
             LbEntity.SaveChanges();
        }
        public void RemoveAuthorById(int _Id)
        {
            AuthorDl = new Author();
            AuthorDl = LbEntity.Authors.FirstOrDefault(auths => auths.Id == _Id);
            LbEntity.Authors.Remove(AuthorDl);
            LbEntity.SaveChanges();
        }
        public void UpdateAuthor(int Id,AuthorModel _Author)
        {
            AuthorDl = new Author();
            Mapper.Initialize(map => { map.CreateMap<AuthorModel, Author>(); });
            AuthorDl = Mapper.Map<Author>(_Author);
            var AuthorDl2 = LbEntity.Authors.FirstOrDefault(auths => auths.Id == Id);
            LbEntity.Entry(AuthorDl2).CurrentValues.SetValues(AuthorDl);
            LbEntity.SaveChanges();
        }
        
    }
}

