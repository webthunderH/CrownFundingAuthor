using CrownFundingWEBAPI.Models;
using Gl = Repository.Global;
using Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace CrownFundingWEBAPI.Controllers
{
    public class CategorieController : ApiController
    {

        private ServiceCategorie _Sc;

        public ServiceCategorie Sc
        {
            get
            {
                return _Sc??(_Sc=new ServiceCategorie());
            }
        }

        [Route("api/categorie/getone")]
        public Categorie GetOne(Categorie Entity)
        {
            Gl.CategorieDeProjet CProj =Sc.GetOne(Mappers<Categorie, Gl.CategorieDeProjet>.VueToEntities(Entity));
            return Mappers<Gl.CategorieDeProjet, Categorie>.VueToEntities(CProj);

        }
        [Route("api/categorie/getall")]
        public IEnumerable<Categorie> GetAll()
        {
            List<Categorie> Selection = new List<Categorie>();
            foreach (Gl.CategorieDeProjet item in Sc.GetAll())
            {
                Selection.Add(Mappers<Gl.CategorieDeProjet, Categorie>.VueToEntities(item));
            }
            return Selection;
        }
        [Route("api/categorie/update")]
        public void Update(Categorie Entity)
        {
            Sc.Update(Mappers<Categorie, Gl.CategorieDeProjet>.VueToEntities(Entity));
        }
        [Route("api/categorie/insert")]
        public Categorie Insert(Categorie Entity)
        {
            Gl.CategorieDeProjet CProj = Sc.Insert(Mappers<Categorie, Gl.CategorieDeProjet>.VueToEntities(Entity));
            return Mappers<Gl.CategorieDeProjet, Categorie>.VueToEntities(CProj);
        }
        [Route("api/categorie/delete")]
        public void delete(Categorie Entity)
        {
            Sc.delete(Mappers<Categorie, Gl.CategorieDeProjet>.VueToEntities(Entity));
        }
    }
}
