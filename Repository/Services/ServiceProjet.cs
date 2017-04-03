using Repository.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class ServiceProjet
    {
        
        public void Delete(Projet Entity)
        {
            if (Entity != null)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {
                    Projet Proj = Context.Projet.Find(Entity.Id);
                    Context.PSPassageProjetHisto(Proj.Id);
                    Context.SaveChanges();
                }

            }
            else
            {
                throw new ArgumentException("La méthode delete n'a pas pu fonctionné");
            }
        }
        
        public VAll_Projet GetOne(Projet Entity)
        {
            if (Entity != null && Entity.Id != 0)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {
                    return Context.VAll_Projet.Find(Mappers<Projet,VAll_Projet>.VueToEntities(Entity).Id);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Le projet n'existe pas");
            }
        }
        
        public Projet Insert(Projet Entity, CategorieDeProjet CategoriePrin, CategorieDeProjet CategorieSec, Utilisateur Auteur, TypeDeContrat Contrat, List<Montant> Montants)
        {
            // Insertion de projet ce fait par cette méthode uniquement qui appelle la première méthode insert privée pour récupéré le dernier projet inséré afin de récupéré son ID//
            if (Entity != null)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {
                    Projet LastInsertProjet = Insert(Entity);

                    DataTable dt = new DataTable();
                    dt.Columns.AddRange((new DataColumn[2] { new DataColumn("Prix", typeof(int)),
                    new DataColumn("[Description]", typeof(string))}));

                    foreach (Montant M in Montants)
                    {
                        DataRow LigneMontant = dt.NewRow();
                        LigneMontant["Prix"] = M.Prix;
                        LigneMontant["[Description]"] = M.Description;
                        dt.Rows.Add(LigneMontant);
                    }
                    ObjectParameter MesMontant = new ObjectParameter("Montant", dt);
                    //Création des parametre sql//
                    ObjectParameter IdProjet = new ObjectParameter("AutoIncrementP", LastInsertProjet.Id);
                    ObjectParameter IdCatPrin = new ObjectParameter("CatPrinc", CategoriePrin.Id);
                    ObjectParameter IdCatSec = new ObjectParameter("CatSec", CategorieSec.Id);
                    ObjectParameter IdUtilisateur = new ObjectParameter("IdUtilisteur", Auteur.Id);
                    ObjectParameter IdContrat = new ObjectParameter("IdContrat", Contrat.Id);
                    Context.Database.ExecuteSqlCommand("Exec PSNouveauProjetInfoSup @AutoIncrementP,@IdUtilisateur,@CatPrinc,@CatSec,@IdContrat,@Montant",
                        IdProjet, IdCatPrin, IdCatSec, IdUtilisateur, IdContrat, MesMontant);
                    return LastInsertProjet;
                }

            }
            else
            {
                throw new ArgumentNullException("Le projet n'a pas été enregistré");
            }
        }
       
        private Projet Insert(Projet Entity)
        {
            if (Entity != null)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {
                    Context.Projet.Add(Entity);
                    Context.SaveChanges();
                    return Context.Projet.Last();
                }
            }
            else
            {
                throw new ArgumentNullException("Le projet n'a pas été enregistré");
            }
        }
        
        public void Update(Projet Entity)
        {
            if (Entity != null)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {
                    Projet Modifie = new Projet();
                    Projet AUpdate = Context.Projet.Find(Entity.Id);
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

        
        public IEnumerable<VAll_Projet> GetAllByType(TypeDeProjet Entity)
        {
            using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
            {
                List<VAll_Projet> Selection = new List<VAll_Projet>();
                foreach (PSListeProjetByType_Result item in Context.PSListeProjetByType(Entity.Id).ToList())
                {
                    Selection.Add(Mappers<PSListeProjetByType_Result, VAll_Projet>.StoredProcedureToVue(item));
                }
                if (Selection.First() != null)
                {
                    return Selection;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("La variable selection ne contient aucun projet");
                }
            }

        }
        
        public IEnumerable<VAll_Projet> GetAllByCategorie(CategorieDeProjet Entity)
        {
            using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
            {
                List<VAll_Projet> Selection = new List<VAll_Projet>();
                foreach (PSListAuteurByCategoryPrincAndSec_Result item in Context.PSListAuteurByCategoryPrincAndSec(Entity.Id).ToList())
                {
                    Selection.Add(Mappers<PSListAuteurByCategoryPrincAndSec_Result, VAll_Projet>.StoredProcedureToVue(item));
                }
                if (Selection.First() != null)
                {
                    return Selection;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("La variable selection ne contient aucun projet");
                }
            }
        }
        
        public IEnumerable<VAll_Projet> ProjetByAuteur(Utilisateur Entity)
        {
            using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
            {
                List<VAll_Projet> Selection = new List<VAll_Projet>();
                foreach (PSListeProjetByAuteur_Result item in Context.PSListeProjetByAuteur(Entity.Id).ToList())
                {
                    Selection.Add(Mappers<PSListeProjetByAuteur_Result, VAll_Projet>.StoredProcedureToVue(item));
                }
                if (Selection.First() != null)
                {
                    return Selection;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("La variable selection ne contient aucun projet");
                }
            }
        }
        
        public IEnumerable<VAll_Projet> ProjetHist(TypeDeProjet Entity)
        {
            using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
            {
                List<VAll_Projet> Selection = new List<VAll_Projet>();
                foreach (PSListeProjetByType_Result item in Context.PSListeProjetByType(Entity.Id).ToList())
                {
                    if (item.Historique != null)
                    {
                        Selection.Add(Mappers<PSListeProjetByType_Result, VAll_Projet>.StoredProcedureToVue(item));
                    }
                }
                if (Selection.First() != null)
                {
                    return Selection;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("La variable selection ne contient aucun projet");
                }
            }
        }
        
        public IEnumerable<VAll_Projet> ProjetHist(CategorieDeProjet Entity)
        {
            using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
            {
                List<VAll_Projet> Selection = new List<VAll_Projet>();
                foreach (PSListeProjetByCategory_Result item in Context.PSListeProjetByCategory(Entity.Id).ToList())
                {
                    if (item.Historique != null)
                    {
                        Selection.Add(Mappers<PSListeProjetByCategory_Result, VAll_Projet>.StoredProcedureToVue(item));
                    }

                }
                if (Selection.First() != null)
                {
                    return Selection;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("La variable selection ne contient aucun projet");
                }
            }
        }
    }
}
