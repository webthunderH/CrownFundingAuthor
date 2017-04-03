using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrownFundingEdition.Administrateur.Client.Models;
using G = CrownFundingWEBAPI.Models;
using ToolBox.HttpRequest;

namespace CrownFundingEdition.Administrateur.Client.Services
{
    public class ServiceUtilisateur
    {
        private httpRequester _JsonRequest;
        private Uri _AdresseServeur;
        public Uri AdresseServeur
        {
            get
            {
                return _AdresseServeur??(_AdresseServeur=new Uri("http://localhost:53261/"));
            }

            
        }
        public httpRequester JsonRequest
        {
            get
            {
                return _JsonRequest??(_JsonRequest=new httpRequester(AdresseServeur));
            }
        }

        

        public string Delete (Utilisateur Entity)
        {
           string Coucou= JsonRequest.DeleteMethode<G.Utilisateur>("api/utilisateur/delete",Mappers<Utilisateur,G.Utilisateur>.AutoMapper(Entity));
           if(Coucou!=null)
            {
                return "L'objet a été delete";
            }
           else
            {
                throw new ArgumentException("Ca n'a pas foncionner");
            }
        }
       
        public string Update(Utilisateur Entity)
        {
           string Requete= JsonRequest.UpdateMethode<G.Utilisateur>("api/utilisateur/update", Mappers<Utilisateur, G.Utilisateur>.AutoMapper(Entity));
            if (Requete!=null)
            {
                return Requete;
            }
            else
            {
                throw new ArgumentException("La méthode Json n'a pas réussi");
            }
        }
        public IEnumerable<Utilisateur> GetAll ()
        {
            List<Utilisateur> ListeUtilisateur = new List<Utilisateur>();
            List<G.VUtilisateur> Liste = JsonRequest.RecuperationInfoListe<G.VUtilisateur>("api/utilisateur/getAll");
            if(Liste.First()!=null)
            {
                foreach (G.VUtilisateur item in Liste)
                {
                ListeUtilisateur.Add(Mappers<G.VUtilisateur, Utilisateur>.AutoMapper(item));
                }
                return ListeUtilisateur;
            }
            else
            {
                throw new ArgumentException("Methode Json n'a pas fonctionné");
            }
         }
        public Utilisateur GetOne(Utilisateur Entity)
        {
            G.VUtilisateur MonUtilisateur = JsonRequest.RecuperationUneInfo<G.VUtilisateur>("api/utilisateur/getone", Mappers<Utilisateur, G.VUtilisateur>.AutoMapper(Entity));
            if (MonUtilisateur!=null)
            {
                return Mappers<G.VUtilisateur, Utilisateur>.AutoMapper(MonUtilisateur);
            }
            else
            {
                throw new ArgumentException("Méthode Json n'a pas fonctionné");
            }
        }
    }
}
