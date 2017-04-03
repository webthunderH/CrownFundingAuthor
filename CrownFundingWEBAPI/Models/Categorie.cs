using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrownFundingWEBAPI.Models
{
    public class Categorie
    {
        private int _Id;
        private string _Nom, _Description, _Restriction;

        public string Description
        {
            get
            {
                return _Description;
            }

            set
            {
                _Description = value;
            }
        }

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

        public string Restriction
        {
            get
            {
                return _Restriction;
            }

            set
            {
                _Restriction = value;
            }
        }
        public Categorie(string Nom, string Description, string Restriction)
        {
            this.Nom = Nom;
            this.Description = Description;
            this.Restriction = Restriction;
        }
        public Categorie(int Id, string Nom, string Restriction, string Description) : this(Nom, Restriction, Description)
        {
            this.Id = Id;
        }
    }
}