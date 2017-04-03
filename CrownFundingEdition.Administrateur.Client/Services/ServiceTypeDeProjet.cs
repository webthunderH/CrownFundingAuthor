using CrownFundingEdition.Administrateur.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.HttpRequest;
using G = CrownFundingWEBAPI.Models;

namespace CrownFundingEdition.Administrateur.Client.Services
{
    public class ServiceTypeDeProjet
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

        public TypeDeProjet Insert (TypeDeProjet Entity)
        {
            if (Entity != null)
            {
                G.TypeDeProjet MyPro =JsonRequest.PostMethode<G.TypeDeProjet>("api/tprojet/insert", Mappers<TypeDeProjet, G.TypeDeProjet>.AutoMapper(Entity), "api/tprojet/getall");
                return Mappers<G.TypeDeProjet, TypeDeProjet>.AutoMapper(MyPro);
            }
                
            else
                throw new ArgumentException("L'entity était null");
        }

        public string Delete(TypeDeProjet Entity)
        {
            string Coucou = JsonRequest.DeleteMethode<G.TypeDeProjet>("api/tprojet/delete", Mappers<TypeDeProjet, G.TypeDeProjet>.AutoMapper(Entity));
            if (Coucou != null)
            {
                return "L'objet a été delete";
            }
            else
            {
                throw new ArgumentException("Ca n'a pas foncionner");
            }
        }

        public string Update(TypeDeProjet Entity)
        {
            string Requete = JsonRequest.UpdateMethode<G.TypeDeProjet>("api/tprojet/update", Mappers<TypeDeProjet, G.TypeDeProjet>.AutoMapper(Entity));
            if (Requete != null)
            {
                return Requete;
            }
            else
            {
                throw new ArgumentException("La méthode Json n'a pas réussi");
            }
        }
        public IEnumerable<TypeDeProjet> GetAll()
        {
            List<TypeDeProjet> ListeTypeDeProjet = new List<TypeDeProjet>();
            List<G.TypeDeProjet> Liste = JsonRequest.RecuperationInfoListe<G.TypeDeProjet>("api/tprojet/getall");
            if (Liste.First() != null)
            {
                foreach (G.TypeDeProjet item in Liste)
                {
                    ListeTypeDeProjet.Add(Mappers<G.TypeDeProjet, TypeDeProjet>.AutoMapper(item));
                }
                return ListeTypeDeProjet;
            }
            else
            {
                throw new ArgumentException("Methode Json n'a pas fonctionné");
            }
        }
        public TypeDeProjet GetOne(TypeDeProjet Entity)
        {
            G.TypeDeProjet MonTypeDeProjet = JsonRequest.RecuperationUneInfo<G.TypeDeProjet>("api/tprojet/getone", Mappers<TypeDeProjet, G.TypeDeProjet>.AutoMapper(Entity));
            if (MonTypeDeProjet != null)
            {
                return Mappers<G.TypeDeProjet, TypeDeProjet>.AutoMapper(MonTypeDeProjet);
            }
            else
            {
                throw new ArgumentException("Méthode Json n'a pas fonctionné");
            }
        }
    }
}
