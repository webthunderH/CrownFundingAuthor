using G = CrownFundingWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.HttpRequest;
using CrownFundingEdition.Administrateur.Client.Models;

namespace CrownFundingEdition.Administrateur.Client.Services
{
    public class ServiceProjet
    {
        private httpRequester _JsonRequest;
        private Uri _AdresseServeur;
        public Uri AdresseServeur
        {
            get
            {
                return _AdresseServeur ?? (_AdresseServeur = new Uri("http://localhost:53261/"));
            }


        }
        public httpRequester JsonRequest
        {
            get
            {
                return _JsonRequest ?? (_JsonRequest = new httpRequester(AdresseServeur));
            }
        }



        public string Delete(Projet Entity)
        {
            string Coucou = JsonRequest.DeleteMethode<G.Projet>("api/Projet/delete", Mappers<Projet, G.Projet>.AutoMapper(Entity));
            if (Coucou != null)
            {
                return "L'objet a été delete";
            }
            else
            {
                throw new ArgumentException("Ca n'a pas foncionner");
            }
        }

        public string Update(Projet Entity)
        {
            string Requete = JsonRequest.UpdateMethode<G.Projet>("api/Projet/update", Mappers<Projet, G.Projet>.AutoMapper(Entity));
            if (Requete != null)
            {
                return Requete;
            }
            else
            {
                throw new ArgumentException("La méthode Json n'a pas réussi");
            }
        }
        public IEnumerable<Projet> GetAll()
        {
            List<Projet> ListeProjet = new List<Projet>();
            List<G.VProjet> Liste = JsonRequest.RecuperationInfoListe<G.VProjet>("api/Projet/getAll");
            if (Liste.First() != null)
            {
                foreach (G.VProjet item in Liste)
                {
                    ListeProjet.Add(Mappers<G.VProjet, Projet>.AutoMapper(item));
                }
                return ListeProjet;
            }
            else
            {
                throw new ArgumentException("Methode Json n'a pas fonctionné");
            }
        }
        public Projet GetOne(Projet Entity)
        {
            G.VProjet MonProjet = JsonRequest.RecuperationUneInfo<G.VProjet>("api/Projet/getone", Mappers<Projet, G.VProjet>.AutoMapper(Entity));
            if (MonProjet != null)
            {
                return Mappers<G.VProjet, Projet>.AutoMapper(MonProjet);
            }
            else
            {
                throw new ArgumentException("Méthode Json n'a pas fonctionné");
            }
        }
    }
}
