using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrownFundingWEBAPI.Models
{
    public class TypeDeContrat
    {
        private int _Id, _Limite_Projet, _Prix;
        private string _Nom;

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

        public int Limite_Projet
        {
            get
            {
                return _Limite_Projet;
            }

            set
            {
                _Limite_Projet = value;
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
        public TypeDeContrat(int Limite_Projet, int Prix, string Nom)
        {
            this.Limite_Projet = Limite_Projet;
            this.Prix = Prix;
            this.Nom = Nom;
        }
        public TypeDeContrat(TypeDeContrat Entity) : this (Entity.Limite_Projet,Entity.Prix,Entity.Nom)
        {
            this.Id = Entity.Id;
        }
    }
}