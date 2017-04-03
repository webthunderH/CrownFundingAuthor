using Repository.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class ServiceAuteur
    {
       
        public VAll_Auteur GetOne(Utilisateur Entity)
        {
            if (Entity != null)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {
                    return Context.VAll_Auteur.Find(Entity.Id);
                }
            }
            else
            {
                throw new ArgumentException("Il n'y a pas de type de ce projet");
            }
        }
        
        public IEnumerable<VAll_Auteur> GetAll()
        {
            using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
            {
                List<VAll_Auteur> Selection = Context.VAll_Auteur.ToList();
                if (Selection.First() != null)
                {
                    return Selection;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("La variable selection ne contient aucun Utilisateur");
                }
            }
        }
        
        public void Update(Utilisateur Entity)
        {
            if (Entity != null)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {
                    Utilisateur Modifie = new Utilisateur();
                    Utilisateur AUpdate = Context.Utilisateur.Find(Entity.Id);
                    foreach (PropertyInfo item in AUpdate.GetType().GetProperties())
                    {
                        var EntityValue = Entity.GetType().GetProperty(item.Name).GetValue(Entity);
                        if (item.GetValue(AUpdate) != EntityValue)
                        {
                            Modifie.GetType().GetProperty(item.Name).SetValue(Modifie, EntityValue);
                        }
                        else
                        {
                            Modifie.GetType().GetProperty(item.Name).SetValue(Modifie, item.GetValue(AUpdate));
                        }
                    }
                    Context.Entry(AUpdate).CurrentValues.SetValues(Modifie);
                    Context.SaveChanges();

                }
            }
            else
            {
                throw new ArgumentException("La modification à échouée");
            }
        }
        
        public void delete(Utilisateur Entity)
        {
            if (Entity != null)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {
                    Context.PSDeleteAuteur(Entity.Id);
                    Context.SaveChanges();

                }
            }
            else
            {
                throw new ArgumentException("La suppression à échoué");
            }
        }
        
        public IEnumerable<VAll_Auteur> ListeAuteurByType(TypeDeProjet Entity)
        {
            using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
            {
                List<VAll_Auteur> Selection = new List<VAll_Auteur>();
                foreach (PSListAuteurByType_Result item in Context.PSListAuteurByType(Entity.Id).ToList())
                {
                    Selection.Add(Mappers<PSListAuteurByType_Result, VAll_Auteur>.StoredProcedureToVue(item));
                }
                if (Selection.First() != null)
                {
                    return Selection;
                }
                else
                {
                    throw new ArgumentException("Il n'y a pas d'auteur dans cette catégorie");
                }
            }
        }
        
        public IEnumerable<VAll_Auteur> ListeAuteurByCat(CategorieDeProjet Entity)
        {
            using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
            {
                List<VAll_Auteur> Selection = new List<VAll_Auteur>();
                foreach (PSListAuteurByCategoryPrincAndSec_Result item in Context.PSListAuteurByCategoryPrincAndSec(Entity.Id).ToList())
                {
                    Selection.Add(Mappers<PSListAuteurByCategoryPrincAndSec_Result, VAll_Auteur>.StoredProcedureToVue(item));
                }
                if (Selection.First() != null)
                {
                    return Selection;
                }
                else
                {
                    throw new ArgumentException("Il n'y a pas d'auteur dans cette catégorie");
                }
            }
        }
    }
}
