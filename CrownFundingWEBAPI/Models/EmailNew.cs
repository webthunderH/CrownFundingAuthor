using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrownFundingWEBAPI.Models
{
    public class EmailNew
    {
        private string _Email;
        private string _Nom;
        private string _Prenom;

       
        public EmailNew(string Nom, string Prenom, string Email)
        {
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Email = Email;
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
    }
}