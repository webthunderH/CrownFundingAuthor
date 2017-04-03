using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrownFundingWEBAPI.Models
{
    public class Auteur
    {
        private int _Id;
        private string _Nom, _Prenom, _Pseudo, _Password, _Adresse, _Pays, _Email, _Compte_bancaire, _Statut;
        private DateTime _DateDeNaissance;

        public int Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
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

        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
            }
        }

        public string Adresse
        {
            get
            {
                return _Adresse;
            }

            set
            {
                _Adresse = value;
            }
        }

        public string Pays
        {
            get
            {
                return _Pays;
            }

            set
            {
                _Pays = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
            }
        }

        public string Compte_bancaire
        {
            get
            {
                return _Compte_bancaire;
            }

            set
            {
                _Compte_bancaire = value;
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

        public DateTime DateDeNaissance
        {
            get
            {
                return _DateDeNaissance;
            }

            set
            {
                _DateDeNaissance = value;
            }
        }
        public Auteur(int Id, string Nom, string Prenom, string Pseudo, string Password, string Adresse, string Pays, string Email, string Compte_bancaire, string Statut)
        {
            this.Id = Id;
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Pseudo = Pseudo;
            this.Password = Password;
            this.Adresse = Adresse;
            this.Pays = Pays;
            this.Email = Email;
            this.Compte_bancaire = Compte_bancaire;
            this.Statut = Statut;
        }
    }
}