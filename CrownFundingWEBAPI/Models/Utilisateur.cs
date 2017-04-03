using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrownFundingWEBAPI.Models
{
    public class Utilisateur
    {
        private int _Id, _Ad_Numero;
        private string _Nom, _Prenom, _Pseudo, _Password, _Pays, _Email, _Compte_bancaire, _Ad_Rue,_Ad_Ville, _Ad_Code_Post;
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

        public int Ad_Numero
        {
            get
            {
                return _Ad_Numero;
            }

            set
            {
                _Ad_Numero = value;
            }
        }

        public string Ad_Rue
        {
            get
            {
                return _Ad_Rue;
            }

            set
            {
                _Ad_Rue = value;
            }
        }

        public string Ad_Ville
        {
            get
            {
                return _Ad_Ville;
            }

            set
            {
                _Ad_Ville = value;
            }
        }

        public string Ad_Code_Post
        {
            get
            {
                return _Ad_Code_Post;
            }

            set
            {
                _Ad_Code_Post = value;
            }
        }

        public Utilisateur(int Id, string Nom, string Prenom, string Pseudo, string Password, string Ad_Rue,string Ad_Ville, string Ad_Code_Post, int Ad_Numero, string Pays, string Email, string Compte_bancaire)
        {
            this.Id = Id;
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Pseudo = Pseudo;
            this.Password = Password;
            this.Ad_Rue = Ad_Rue;
            this.Ad_Ville = Ad_Ville;
            this.Ad_Code_Post = Ad_Code_Post;
            this.Ad_Numero = Ad_Numero;
            this.Pays = Pays;
            this.Email = Email;
            this.Compte_bancaire = Compte_bancaire;
            
        }
       
    }
}