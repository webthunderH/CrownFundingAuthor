using Repository.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class ServiceCategorie
    {
        
        public CategorieDeProjet GetOne(CategorieDeProjet Entity)
        {
            if (Entity != null)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {
                    return Context.CategorieDeProjet.Find(Entity.Id);
                }
            }
            else
            {
                throw new ArgumentException("Il n'y a pas de type de ce projet");
            }
        }
        
        public IEnumerable<CategorieDeProjet> GetAll()
        {
            using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
            {
                List<CategorieDeProjet> Selection = Context.CategorieDeProjet.ToList();
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
        
        public void Update(CategorieDeProjet Entity)
        {
            if (Entity != null)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {
                    CategorieDeProjet Modifie = new CategorieDeProjet();
                    CategorieDeProjet AUpdate = Context.CategorieDeProjet.Find(Entity.Id);
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
                throw new ArgumentException("La méthode update a échoué");
            }
        }
        
        public CategorieDeProjet Insert(CategorieDeProjet Entity)
        {
            if (Entity != null)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {
                    Context.CategorieDeProjet.Add(Entity);
                    Context.SaveChanges();
                    return Context.CategorieDeProjet.LastOrDefault();
                }
            }
            else
            {
                throw new ArgumentNullException("Le projet n'a pas été enregistré");
            }
        }
        
        public void delete(CategorieDeProjet Entity)
        {
            if (Entity != null)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {
                    Context.CategorieDeProjet.Remove(Entity);
                    Context.SaveChanges();
                   
                }

            }
            else
            {
                throw new ArgumentException("La méthode delete n'a pas fonctionné");
            }
        }
    }
}
