using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrownFundingEdition.Administrateur.Client.Models
{
    public class HistoriqueProjet
    {
        private int _ID;
        private string _Titre,_Sous_Titre,_Nom,_Prenom,_Pseudo,_Statut;
        private DateTime _DateDebut,_DateFin;
        private bool _Historique;
        private int _J_aime,_Je_n_aime_Pas,_Total_Dons,_Total_Crownfunding;

        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        public string Titre
        {
            get
            {
                return _Titre;
            }

            set
            {
                _Titre = value;
            }
        }

        public string Sous_Titre
        {
            get
            {
                return _Sous_Titre;
            }

            set
            {
                _Sous_Titre = value;
            }
        }

        public string Nom
        {
            get
            {
                return _Nom;
            }

            set
            {
                _Nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return _Prenom;
            }

            set
            {
                _Prenom = value;
            }
        }

        public string Pseudo
        {
            get
            {
                return _Pseudo;
            }

            set
            {
                _Pseudo = value;
            }
        }

        public string Statut
        {
            get
            {
                return _Statut;
            }

            set
            {
                _Statut = value;
            }
        }

        public DateTime DateDebut
        {
            get
            {
                return _DateDebut;
            }

            set
            {
                _DateDebut = value;
            }
        }

        public DateTime DateFin
        {
            get
            {
                return _DateFin;
            }

            set
            {
                _DateFin = value;
            }
        }

        public bool Historique
        {
            get
            {
                return _Historique;
            }

            set
            {
                _Historique = value;
            }
        }

        public int J_aime
        {
            get
            {
                return _J_aime;
            }

            set
            {
                _J_aime = value;
            }
        }

        public int Je_n_aime_Pas
        {
            get
            {
                return _Je_n_aime_Pas;
            }

            set
            {
                _Je_n_aime_Pas = value;
            }
        }

        public int Total_Dons
        {
            get
            {
                return _Total_Dons;
            }

            set
            {
                _Total_Dons = value;
            }
        }

        public int Total_Crownfunding
        {
            get
            {
                return _Total_Crownfunding;
            }

            set
            {
                _Total_Crownfunding = value;
            }
        }
        
    }
}
