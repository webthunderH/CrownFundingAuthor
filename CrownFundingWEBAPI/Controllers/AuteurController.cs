using CrownFundingWEBAPI.Models;
using Repository.Services;
using Gl=Repository.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace CrownFundingWEBAPI.Controllers
{
    public class AuteurController : ApiController
    {
		// TODO add TRY Catch to use create LOG. 
        private ServiceAuteur _Sa;

        public ServiceAuteur Sa
        {
            get
            {
                return _Sa??(_Sa=new ServiceAuteur());
            } 
        }

        [Route("api/auteur/getone")]
        public Auteur GetOne(Utilisateur Entity)
        {
            Gl.VAll_Auteur Ut=Sa.GetOne(Mappers<Utilisateur, Gl.Utilisateur>.VueToEntities(Entity));
            return Mappers<Gl.VAll_Auteur, Auteur>.VueToEntities(Ut);
        }
        [Route("api/auteur/getall")]
        public IEnumerable<Auteur> GetAll()
        {
            List<Auteur> Selection = new List<Auteur>();
            foreach (Gl.VAll_Auteur item in Sa.GetAll())
            {
                Selection.Add(Mappers<Gl.VAll_Auteur, Auteur>.VueToEntities(item));
            }
            return Selection;
            
        }
        [Route("api/auteur/update")]
        public void Update(Utilisateur Entity)
        {
            Sa.Update(Mappers<Utilisateur, Gl.Utilisateur>.VueToEntities(Entity));
        }
        [Route("api/auteur/delete")]
        public void delete(Utilisateur Entity)
        {
            Sa.delete(Mappers<Utilisateur, Gl.Utilisateur>.VueToEntities(Entity));
        }
        [Route("api/auteur/bytype")]
        public IEnumerable<Auteur> ListeAuteurByType(TypeDeProjet Entity)
        {
            List<Auteur> Selection = new List<Auteur>();
            foreach (Gl.VAll_Auteur item in Sa.ListeAuteurByType(Mappers<TypeDeProjet, Gl.TypeDeProjet>.VueToEntities(Entity)))
            {
                Selection.Add(Mappers<Gl.VAll_Auteur, Auteur>.VueToEntities(item));
            }
            return Selection;
        }
        [Route("api/auteur/bycategory")]
        public IEnumerable<Auteur> ListeAuteurByCat(Categorie Entity)
        {
            List<Auteur> Selection = new List<Auteur>();
            foreach (Gl.VAll_Auteur item in Sa.ListeAuteurByCat(Mappers<Categorie,Gl.CategorieDeProjet>.VueToEntities(Entity)))
            {
                Selection.Add(Mappers<Gl.VAll_Auteur, Auteur>.VueToEntities(item));
            }
            return Selection;
        }
        
    }
}
