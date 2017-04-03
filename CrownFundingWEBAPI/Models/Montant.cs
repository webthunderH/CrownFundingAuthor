using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrownFundingWEBAPI.Models
{
    public class Montant
    {
        private int _Id, _Prix, _IdProjet;
        private string _Description;

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

        public int Prix
        {
            get
            {
                return _Prix;
            }

            set
            {
                _Prix = value;
            }
        }

        public int IdProjet
        {
            get
            {
                return _IdProjet;
            }

            set
            {
                _IdProjet = value;
            }
        }

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
        public Montant(int Prix, int IdProjet, string description)
        {
            this.Prix = Prix;
            this.IdProjet = IdProjet;
            this.Description = Description;

        }
        public Montant(Montant Entity) : this(Entity.Prix,Entity.IdProjet, Entity.Description)
        {
            this.Id = Entity.Id;
        }
    }
}