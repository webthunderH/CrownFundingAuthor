using G=CrownFundingWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.HttpRequest;
using CrownFundingEdition.Administrateur.Client.Models;

namespace CrownFundingEdition.Administrateur.Client.Services
{
    public class ServiceCategorie
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



        public string Delete(Categorie Entity)
        {
			string DeleteJson = JsonRequest.DeleteMethode<G.Categorie, Categorie>("api/Categorie/delete", Mappers<Categorie, G.Categorie>.AutoMapper(Entity));
            if (DeleteJson != null)
            {
                return "L'objet a été delete";
            }
            else
            {
                throw new ArgumentException("Ca n'a pas foncionner");
            }
        }

        public string Update(Categorie Entity)
        {
            string Request = JsonRequest.UpdateMethode<G.Categorie>("api/Categorie/update", Mappers<Categorie, G.Categorie>.AutoMapper(Entity));
            if (Request != null)
            {
                return Request;
            }
            else
            {
                throw new ArgumentException("La méthode Json n'a pas réussi");
            }
        }
        public IEnumerable<Categorie> GetAll()
        {
            List<Categorie> ListeCategorie = new List<Categorie>();
            List<G.Categorie> Liste = JsonRequest.RecuperationInfoListe<G.Categorie>("api/Categorie/getAll");
            if (Liste.First() != null)
            {
                foreach (G.Categorie item in Liste)
                {
                    ListeCategorie.Add(Mappers<G.Categorie, Categorie>.AutoMapper(item));
                }
                return ListeCategorie;
            }
            else
            {
                throw new ArgumentException("Methode Json n'a pas fonctionné");
            }
        }
        public Categorie GetOne(Categorie Entity)
        {
            G.Categorie MonCategorie = JsonRequest.RecuperationUneInfo<G.Categorie>("api/Categorie/getone", Mappers<Categorie, G.Categorie>.AutoMapper(Entity));
            if (MonCategorie != null)
            {
                return Mappers<G.Categorie, Categorie>.AutoMapper(MonCategorie);
            }
            else
            {
                throw new ArgumentException("Méthode Json n'a pas fonctionné");
            }
        }
    }
}
