﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repository.Global
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Crownfunding_EditionEntities : DbContext
    {
        public Crownfunding_EditionEntities()
            : base("name=Crownfunding_EditionEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CategorieDeProjet> CategorieDeProjet { get; set; }
        public virtual DbSet<Contrat_Utilisateur> Contrat_Utilisateur { get; set; }
        public virtual DbSet<Dons> Dons { get; set; }
        public virtual DbSet<Montant> Montant { get; set; }
        public virtual DbSet<NewsLetter> NewsLetter { get; set; }
        public virtual DbSet<Notation> Notation { get; set; }
        public virtual DbSet<Participations> Participations { get; set; }
        public virtual DbSet<Projet> Projet { get; set; }
        public virtual DbSet<ReponseSondage> ReponseSondage { get; set; }
        public virtual DbSet<Sondage> Sondage { get; set; }
        public virtual DbSet<Specialisation_ProjetPrincipal> Specialisation_ProjetPrincipal { get; set; }
        public virtual DbSet<Specialisation_ProjetSecondaire> Specialisation_ProjetSecondaire { get; set; }
        public virtual DbSet<TypeDeContrat> TypeDeContrat { get; set; }
        public virtual DbSet<TypeDeProjet> TypeDeProjet { get; set; }
        public virtual DbSet<Utilisateur> Utilisateur { get; set; }
        public virtual DbSet<V_AllCrown> V_AllCrown { get; set; }
        public virtual DbSet<VAll_Auteur> VAll_Auteur { get; set; }
        public virtual DbSet<VAll_Projet> VAll_Projet { get; set; }
        public virtual DbSet<VAllUtilisateur> VAllUtilisateur { get; set; }
        public virtual DbSet<VAuteurOrUtil> VAuteurOrUtil { get; set; }
        public virtual DbSet<VQuesAuteur> VQuesAuteur { get; set; }
        public virtual DbSet<VTotalByProjet> VTotalByProjet { get; set; }
        public virtual DbSet<VTotalCrownByProject> VTotalCrownByProject { get; set; }
        public virtual DbSet<VTotalDonByProject> VTotalDonByProject { get; set; }
        public virtual DbSet<VUtilNewsLetter> VUtilNewsLetter { get; set; }
    
        public virtual ObjectResult<PSListAuteurByCategoryPrincAndSec_Result> PSListAuteurByCategoryPrincAndSec(Nullable<int> idCategory)
        {
            var idCategoryParameter = idCategory.HasValue ?
                new ObjectParameter("IdCategory", idCategory) :
                new ObjectParameter("IdCategory", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PSListAuteurByCategoryPrincAndSec_Result>("PSListAuteurByCategoryPrincAndSec", idCategoryParameter);
        }
    
        public virtual ObjectResult<PSListAuteurByType_Result> PSListAuteurByType(Nullable<int> idType)
        {
            var idTypeParameter = idType.HasValue ?
                new ObjectParameter("IdType", idType) :
                new ObjectParameter("IdType", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PSListAuteurByType_Result>("PSListAuteurByType", idTypeParameter);
        }
    
        public virtual ObjectResult<PSListeProjetByAuteur_Result> PSListeProjetByAuteur(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PSListeProjetByAuteur_Result>("PSListeProjetByAuteur", idParameter);
        }
    
        public virtual ObjectResult<PSListeProjetByCategory_Result> PSListeProjetByCategory(Nullable<int> idCategory)
        {
            var idCategoryParameter = idCategory.HasValue ?
                new ObjectParameter("IdCategory", idCategory) :
                new ObjectParameter("IdCategory", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PSListeProjetByCategory_Result>("PSListeProjetByCategory", idCategoryParameter);
        }
    
        public virtual ObjectResult<PSListeProjetByType_Result> PSListeProjetByType(Nullable<int> idType)
        {
            var idTypeParameter = idType.HasValue ?
                new ObjectParameter("IdType", idType) :
                new ObjectParameter("IdType", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PSListeProjetByType_Result>("PSListeProjetByType", idTypeParameter);
        }
    
        public virtual int PSNotation(Nullable<int> idUtili, Nullable<int> idProjet, Nullable<bool> note)
        {
            var idUtiliParameter = idUtili.HasValue ?
                new ObjectParameter("IdUtili", idUtili) :
                new ObjectParameter("IdUtili", typeof(int));
    
            var idProjetParameter = idProjet.HasValue ?
                new ObjectParameter("IdProjet", idProjet) :
                new ObjectParameter("IdProjet", typeof(int));
    
            var noteParameter = note.HasValue ?
                new ObjectParameter("Note", note) :
                new ObjectParameter("Note", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PSNotation", idUtiliParameter, idProjetParameter, noteParameter);
        }
    
        public virtual int PSNouveauDon(Nullable<int> idUtilisateur, Nullable<int> idProjet, Nullable<System.DateTime> dateDons, Nullable<int> montant, string communication)
        {
            var idUtilisateurParameter = idUtilisateur.HasValue ?
                new ObjectParameter("IdUtilisateur", idUtilisateur) :
                new ObjectParameter("IdUtilisateur", typeof(int));
    
            var idProjetParameter = idProjet.HasValue ?
                new ObjectParameter("IdProjet", idProjet) :
                new ObjectParameter("IdProjet", typeof(int));
    
            var dateDonsParameter = dateDons.HasValue ?
                new ObjectParameter("DateDons", dateDons) :
                new ObjectParameter("DateDons", typeof(System.DateTime));
    
            var montantParameter = montant.HasValue ?
                new ObjectParameter("Montant", montant) :
                new ObjectParameter("Montant", typeof(int));
    
            var communicationParameter = communication != null ?
                new ObjectParameter("Communication", communication) :
                new ObjectParameter("Communication", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PSNouveauDon", idUtilisateurParameter, idProjetParameter, dateDonsParameter, montantParameter, communicationParameter);
        }
    
        public virtual int PSNouveauProjetInfoSup(Nullable<int> autoIncrementP, Nullable<int> idUtilisateur, Nullable<int> catPrinc, Nullable<int> catSec, Nullable<int> idContrat)
        {
            var autoIncrementPParameter = autoIncrementP.HasValue ?
                new ObjectParameter("AutoIncrementP", autoIncrementP) :
                new ObjectParameter("AutoIncrementP", typeof(int));
    
            var idUtilisateurParameter = idUtilisateur.HasValue ?
                new ObjectParameter("IdUtilisateur", idUtilisateur) :
                new ObjectParameter("IdUtilisateur", typeof(int));
    
            var catPrincParameter = catPrinc.HasValue ?
                new ObjectParameter("CatPrinc", catPrinc) :
                new ObjectParameter("CatPrinc", typeof(int));
    
            var catSecParameter = catSec.HasValue ?
                new ObjectParameter("CatSec", catSec) :
                new ObjectParameter("CatSec", typeof(int));
    
            var idContratParameter = idContrat.HasValue ?
                new ObjectParameter("IdContrat", idContrat) :
                new ObjectParameter("IdContrat", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PSNouveauProjetInfoSup", autoIncrementPParameter, idUtilisateurParameter, catPrincParameter, catSecParameter, idContratParameter);
        }
    
        public virtual int PSNouveauSondage(string nom)
        {
            var nomParameter = nom != null ?
                new ObjectParameter("Nom", nom) :
                new ObjectParameter("Nom", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PSNouveauSondage", nomParameter);
        }
    
        public virtual int PSNouveauType(string nom, Nullable<int> pageMin, Nullable<int> pageMax)
        {
            var nomParameter = nom != null ?
                new ObjectParameter("Nom", nom) :
                new ObjectParameter("Nom", typeof(string));
    
            var pageMinParameter = pageMin.HasValue ?
                new ObjectParameter("PageMin", pageMin) :
                new ObjectParameter("PageMin", typeof(int));
    
            var pageMaxParameter = pageMax.HasValue ?
                new ObjectParameter("PageMax", pageMax) :
                new ObjectParameter("PageMax", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PSNouveauType", nomParameter, pageMinParameter, pageMaxParameter);
        }
    
        public virtual int PSNouveauTypeContrat(string nom, Nullable<int> limiteProjet, Nullable<int> prix)
        {
            var nomParameter = nom != null ?
                new ObjectParameter("Nom", nom) :
                new ObjectParameter("Nom", typeof(string));
    
            var limiteProjetParameter = limiteProjet.HasValue ?
                new ObjectParameter("LimiteProjet", limiteProjet) :
                new ObjectParameter("LimiteProjet", typeof(int));
    
            var prixParameter = prix.HasValue ?
                new ObjectParameter("Prix", prix) :
                new ObjectParameter("Prix", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PSNouveauTypeContrat", nomParameter, limiteProjetParameter, prixParameter);
        }
    
        public virtual int PSNouveauUtilisateur(string nom, string prenom, string pseudo, Nullable<System.DateTime> dateDeNaissance, string email, string password, string pays, string compteBancaire, string ad_Rue, string ad_Ville, string ad_Code_Post, Nullable<int> ad_Numero, Nullable<bool> newsLetter, byte[] secretKey)
        {
            var nomParameter = nom != null ?
                new ObjectParameter("Nom", nom) :
                new ObjectParameter("Nom", typeof(string));
    
            var prenomParameter = prenom != null ?
                new ObjectParameter("Prenom", prenom) :
                new ObjectParameter("Prenom", typeof(string));
    
            var pseudoParameter = pseudo != null ?
                new ObjectParameter("Pseudo", pseudo) :
                new ObjectParameter("Pseudo", typeof(string));
    
            var dateDeNaissanceParameter = dateDeNaissance.HasValue ?
                new ObjectParameter("DateDeNaissance", dateDeNaissance) :
                new ObjectParameter("DateDeNaissance", typeof(System.DateTime));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var paysParameter = pays != null ?
                new ObjectParameter("Pays", pays) :
                new ObjectParameter("Pays", typeof(string));
    
            var compteBancaireParameter = compteBancaire != null ?
                new ObjectParameter("CompteBancaire", compteBancaire) :
                new ObjectParameter("CompteBancaire", typeof(string));
    
            var ad_RueParameter = ad_Rue != null ?
                new ObjectParameter("Ad_Rue", ad_Rue) :
                new ObjectParameter("Ad_Rue", typeof(string));
    
            var ad_VilleParameter = ad_Ville != null ?
                new ObjectParameter("Ad_Ville", ad_Ville) :
                new ObjectParameter("Ad_Ville", typeof(string));
    
            var ad_Code_PostParameter = ad_Code_Post != null ?
                new ObjectParameter("Ad_Code_Post", ad_Code_Post) :
                new ObjectParameter("Ad_Code_Post", typeof(string));
    
            var ad_NumeroParameter = ad_Numero.HasValue ?
                new ObjectParameter("Ad_Numero", ad_Numero) :
                new ObjectParameter("Ad_Numero", typeof(int));
    
            var newsLetterParameter = newsLetter.HasValue ?
                new ObjectParameter("NewsLetter", newsLetter) :
                new ObjectParameter("NewsLetter", typeof(bool));
    
            var secretKeyParameter = secretKey != null ?
                new ObjectParameter("SecretKey", secretKey) :
                new ObjectParameter("SecretKey", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PSNouveauUtilisateur", nomParameter, prenomParameter, pseudoParameter, dateDeNaissanceParameter, emailParameter, passwordParameter, paysParameter, compteBancaireParameter, ad_RueParameter, ad_VilleParameter, ad_Code_PostParameter, ad_NumeroParameter, newsLetterParameter, secretKeyParameter);
        }
    
        public virtual int PSNouvelleCategorie(string nom, string restriction, string description)
        {
            var nomParameter = nom != null ?
                new ObjectParameter("Nom", nom) :
                new ObjectParameter("Nom", typeof(string));
    
            var restrictionParameter = restriction != null ?
                new ObjectParameter("Restriction", restriction) :
                new ObjectParameter("Restriction", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PSNouvelleCategorie", nomParameter, restrictionParameter, descriptionParameter);
        }
    
        public virtual int PSNouvelleParticipation(Nullable<int> idUtilisateur, Nullable<int> idMontant, Nullable<System.DateTime> dateParticipation, string communication)
        {
            var idUtilisateurParameter = idUtilisateur.HasValue ?
                new ObjectParameter("IdUtilisateur", idUtilisateur) :
                new ObjectParameter("IdUtilisateur", typeof(int));
    
            var idMontantParameter = idMontant.HasValue ?
                new ObjectParameter("IdMontant", idMontant) :
                new ObjectParameter("IdMontant", typeof(int));
    
            var dateParticipationParameter = dateParticipation.HasValue ?
                new ObjectParameter("DateParticipation", dateParticipation) :
                new ObjectParameter("DateParticipation", typeof(System.DateTime));
    
            var communicationParameter = communication != null ?
                new ObjectParameter("Communication", communication) :
                new ObjectParameter("Communication", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PSNouvelleParticipation", idUtilisateurParameter, idMontantParameter, dateParticipationParameter, communicationParameter);
        }
    
        public virtual int PSPassageProjetHisto(Nullable<int> idProjet)
        {
            var idProjetParameter = idProjet.HasValue ?
                new ObjectParameter("IdProjet", idProjet) :
                new ObjectParameter("IdProjet", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PSPassageProjetHisto", idProjetParameter);
        }
    
        public virtual int PSReponseSondage(Nullable<int> idSondage, Nullable<int> idUtilisateur, Nullable<bool> reponse)
        {
            var idSondageParameter = idSondage.HasValue ?
                new ObjectParameter("IdSondage", idSondage) :
                new ObjectParameter("IdSondage", typeof(int));
    
            var idUtilisateurParameter = idUtilisateur.HasValue ?
                new ObjectParameter("IdUtilisateur", idUtilisateur) :
                new ObjectParameter("IdUtilisateur", typeof(int));
    
            var reponseParameter = reponse.HasValue ?
                new ObjectParameter("Reponse", reponse) :
                new ObjectParameter("Reponse", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PSReponseSondage", idSondageParameter, idUtilisateurParameter, reponseParameter);
        }
    
        public virtual int PSDeleteAuteur(Nullable<int> idUtilisateur)
        {
            var idUtilisateurParameter = idUtilisateur.HasValue ?
                new ObjectParameter("IdUtilisateur", idUtilisateur) :
                new ObjectParameter("IdUtilisateur", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PSDeleteAuteur", idUtilisateurParameter);
        }
    }
}
