using Repository.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class ServiceUtilisateur
    {
        public void Delete(Utilisateur Entity)
        {
            if (Entity != null)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {
                    Utilisateur Utili = Context.Utilisateur.Find(Entity.Id);
                    Context.Utilisateur.Remove(Utili);
                    Context.SaveChanges();
                }
            }
            else
            {
                throw new ArgumentException("L'api delete n'a pas fonctionné");
            }

        }
        
        public void Insert(Utilisateur Entity)
        {
            if (Entity != null)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {
                    Context.PSNouveauUtilisateur(Entity.Nom, Entity.Prenom, Entity.Pseudo, Entity.DateDeNaissance, Entity.Email, Entity.Password, Entity.Pays, Entity.Compte_bancaire, Entity.Ad_Rue, Entity.Ad_Ville, Entity.Ad_Code_Post, Entity.Ad_Numero, Entity.NewsLetter,Entity.SecretKey);
                    Context.SaveChanges();

                }
            }
            else
            {
                throw new ArgumentException("L'api Insert à eu un problème");
            }
        }
       
        public IEnumerable<VAllUtilisateur> GetAll()
        {

            using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
            {
                List<VAllUtilisateur> Selection = Context.VAllUtilisateur.ToList();
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
        
        public VAllUtilisateur GetOne(Utilisateur Entity)
        {
            if (Entity != null)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {

                    VAllUtilisateur MonUtilisateur = Context.VAllUtilisateur.Find(Entity.Id);
                    return MonUtilisateur;
                }

            }
            else
            {
                throw new ArgumentOutOfRangeException("L'utilisateur n'existe pas");
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
                throw new ArgumentException("L'api a eu un problème");
            }
        }
    }
}
