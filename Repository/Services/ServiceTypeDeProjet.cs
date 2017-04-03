using Repository.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class ServiceTypeDeProjet
    {
        
        public TypeDeProjet GetOne(TypeDeProjet Entity)
        {
            if (Entity != null)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {
                    return Context.TypeDeProjet.Find(Entity.Id);
                }
            }
            else
            {
                throw new ArgumentException("Il n'y a pas de type de ce projet");
            }
        }
       
        public IEnumerable<TypeDeProjet> GetAll()
        {
            using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
            {
                List<TypeDeProjet> Selection = Context.TypeDeProjet.ToList();
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
       
        public void Update(TypeDeProjet Entity)
        {
            if (Entity != null)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {
                    TypeDeProjet Modifie = new TypeDeProjet();
                    TypeDeProjet AUpdate = Context.TypeDeProjet.Find(Entity.Id);
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
                throw new ArgumentException("La méthode update n'a pas fonctionné");
            }
        }
       
        public TypeDeProjet Insert(TypeDeProjet Entity)
        {
            if (Entity != null)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {
                    Context.TypeDeProjet.Add(Entity);
                    Context.SaveChanges();
                    return Context.TypeDeProjet.LastOrDefault();
                }
            }
            else
            {
                throw new ArgumentNullException("Le projet n'a pas été enregistré");
            }
        }
        
        public void delete(TypeDeProjet Entity)
        {
            if (Entity != null)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {
                    Context.TypeDeProjet.Remove(Entity);
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
