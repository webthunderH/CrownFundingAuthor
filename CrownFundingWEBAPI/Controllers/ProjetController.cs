using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrownFundingWEBAPI.Models;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Reflection;
using Repository.Services;
using Gl=Repository.Global;

namespace CrownFundingWEBAPI.Controllers
{
    public class ProjetController : ApiController
    {
        private ServiceProjet _Sp;

        public ServiceProjet Sp
        {
            get
            {
                return _Sp??(_Sp=new ServiceProjet());
            }
        }

        [Route("api/projet/delete")]
        public void Delete(Projet Entity)
        {
            Sp.Delete(Mappers<Projet, Gl.Projet>.VueToEntities(Entity));
        }
        [Route("api/projet/ficheprojet")]
        public VProjet GetOne(Projet Entity)
        {
           Gl.VAll_Projet Proj= Sp.GetOne(Mappers<Projet, Gl.Projet>.VueToEntities(Entity));
            return Mappers<Gl.VAll_Projet, VProjet>.VueToEntities(Proj);
        }
        [Route("api/projet/insert")]
        public Projet Insert (Projet Entity, Categorie CategoriePrin, Categorie CategorieSec, Utilisateur Auteur, TypeDeContrat Contrat, List<Montant> Montants)
        {
            Gl.Projet GlPro = Mappers<Projet, Gl.Projet>.VueToEntities(Entity);
            Gl.CategorieDeProjet CatPrin = Mappers<Categorie, Gl.CategorieDeProjet>.VueToEntities(CategoriePrin);
            Gl.CategorieDeProjet CatSec = Mappers<Categorie, Gl.CategorieDeProjet>.VueToEntities(CategorieSec);
            Gl.Utilisateur GlUtilisateur = Mappers<Utilisateur, Gl.Utilisateur>.VueToEntities(Auteur);
            Gl.TypeDeContrat GlTContrat = Mappers<TypeDeContrat, Gl.TypeDeContrat>.VueToEntities(Contrat);
            List<Gl.Montant> ListeMontant = new List<Gl.Montant>();
            foreach (Montant item in Montants)
            {
                ListeMontant.Add(Mappers<Montant, Gl.Montant>.VueToEntities(item));
            }
            Gl.Projet LastProjet=  Sp.Insert(GlPro,CatPrin,CatSec,GlUtilisateur,GlTContrat, ListeMontant);
            return Mappers<Gl.Projet, Projet>.VueToEntities(LastProjet);
        }
       
        [Route("api/projet/update")]
        public void Update(Projet Entity)
        {
            Sp.Update(Mappers<Projet, Gl.Projet>.VueToEntities(Entity));
        }

        [Route("api/projet/projetbytype")]
        public IEnumerable<VProjet> GetAllByType(TypeDeProjet Entity)
        {

            List<VProjet> Selection = new List<VProjet>();
            foreach (Gl.VAll_Projet item in Sp.GetAllByType(Mappers<TypeDeProjet, Gl.TypeDeProjet>.VueToEntities(Entity)))
            {
                Selection.Add(Mappers<Gl.VAll_Projet, VProjet>.VueToEntities(item));
            }
            return Selection;

        }
        [Route("api/projet/projetbycategorie")]
        public IEnumerable<VProjet> GetAllByCategorie(Categorie Entity)
        {

            List<VProjet> Selection = new List<VProjet>();
            foreach (Gl.VAll_Projet item in Sp.GetAllByCategorie(Mappers<Categorie, Gl.CategorieDeProjet>.VueToEntities(Entity)))
            {
                Selection.Add(Mappers<Gl.VAll_Projet, VProjet>.VueToEntities(item));
            }
            return Selection;
        }
        [Route("api/projet/projetbyauteur")]
        public IEnumerable<VProjet> ProjetByAuteur(Utilisateur Entity)
        {

            List<VProjet> Selection = new List<VProjet>();
            foreach (Gl.VAll_Projet item in Sp.ProjetByAuteur(Mappers<Utilisateur,Gl.Utilisateur>.VueToEntities(Entity)))
            {
                Selection.Add(Mappers<Gl.VAll_Projet, VProjet>.VueToEntities(item));
            }
            return Selection;
        }
        [Route("api/projet/histobytypeprojet")]
        public IEnumerable<VProjet> ProjetHist(TypeDeProjet Entity)
        {

            List<VProjet> Selection = new List<VProjet>();
            foreach (Gl.VAll_Projet item in Sp.ProjetHist(Mappers<TypeDeProjet, Gl.TypeDeProjet>.VueToEntities(Entity)))
            {
                Selection.Add(Mappers<Gl.VAll_Projet, VProjet>.VueToEntities(item));
            }
            return Selection;
        }
        [Route("api/projet/histobycatprojet")]
        public IEnumerable<VProjet> ProjetHist(Categorie Entity)
        {
            List<VProjet> Selection = new List<VProjet>();
            foreach (Gl.VAll_Projet item in Sp.ProjetHist(Mappers<Categorie,Gl.CategorieDeProjet>.VueToEntities(Entity)))
            {
                Selection.Add(Mappers<Gl.VAll_Projet, VProjet>.VueToEntities(item));
            }
            return Selection;
        }
    }
}
