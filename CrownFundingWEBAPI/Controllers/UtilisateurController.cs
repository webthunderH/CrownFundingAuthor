using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrownFundingWEBAPI.Models;
using System.Reflection;
using G = Repository.Services;
using Gl = Repository.Global;
using CrownFundingWEBAPI.Infrastructure;

namespace CrownFundingWEBAPI.Controllers
{
    public class UtilisateurController : ApiController
    {

        private G.ServiceUtilisateur _Se;

        public G.ServiceUtilisateur Se
        {
            get
            {
                return _Se??(_Se=new G.ServiceUtilisateur());
            }
        }

        // Code qui seront récupéré par les programme pour définir si l'action à bien été effectuée.//
        //Le Code 505 équivaut aux succès de la demande // Le Code 666 équivaut à une erreur//


        [Route("api/utilisateur/delete")]
        public void Delete(Utilisateur Entity)
        {
            Se.Delete(Mappers<Utilisateur, Gl.Utilisateur>.VueToEntities(Entity));                 
        }
        [Route("api/utilisateur/insert")]
        public void Insert(Utilisateur Entity)
        {
            Se.Insert(Mappers<Utilisateur, Gl.Utilisateur>.VueToEntities(Entity));
        }
        [Route("api/utilisateur/getAll")]
        public IEnumerable<VUtilisateur> GetAll()
        {
            List<VUtilisateur> Selection = new List<VUtilisateur>();
            foreach (Gl.VAllUtilisateur item in Se.GetAll())
            {
                Selection.Add(Mappers<Gl.VAllUtilisateur,VUtilisateur>.VueToEntities(item));
            }
            return Selection;
        }
        [Route("api/utilisateur/getone")]
        public VUtilisateur GetOne(VUtilisateur Entity)
        {
            
            return Mappers<Gl.VAllUtilisateur,VUtilisateur>.VueToEntities(Se.GetOne(Mappers<VUtilisateur, Gl.Utilisateur>.VueToEntities(Entity)));
        }
        [HMACAuthentificationAttribute]
        [Route("api/utilisateur/update")]
        public void Update(Utilisateur Entity)
        {
            Se.Update(Mappers<Utilisateur, Gl.Utilisateur>.VueToEntities(Entity));
        }

    }
}

