using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrownFundingWEBAPI.Models
{
    public class Projet
    {
        private int _Id, _IdTypeProjet, _IdUtilisateur, _RecolteDesire;
        private string _Titre, _Resume, _Sous_Titre;
        private byte[] _Fichier, _Image;
        private DateTime _DateDebut, _DateFin;    
        private bool _Historique;

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

        public int IdTypeProjet
        {
            get
            {
                return _IdTypeProjet;
            }

            set
            {
                _IdTypeProjet = value;
            }
        }

        public int IdUtilisateur
        {
            get
            {
                return _IdUtilisateur;
            }

            set
            {
                _IdUtilisateur = value;
            }
        }

        public int RecolteDesire
        {
            get
            {
                return _RecolteDesire;
            }

            set
            {
                _RecolteDesire = value;
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

        public string Resume
        {
            get
            {
                return _Resume;
            }

            set
            {
                _Resume = value;
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

        public byte[] Fichier
        {
            get
            {
                return _Fichier;
            }

            set
            {
                _Fichier = value;
            }
        }

        public byte[] Image
        {
            get
            {
                return _Image;
            }

            set
            {
                _Image = value;
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
        public Projet(int IdTypeProjet, int IdUtilisateur, int RecolteDesire, string Titre, string Sous_Titre,string Resume,byte[] Fichier,byte[] Image, DateTime DateDebut,DateTime DateFin,bool Historique)
        {
            this.IdTypeProjet = IdTypeProjet;
            this.IdUtilisateur = IdUtilisateur;
            this.RecolteDesire = RecolteDesire;
            this.Titre = Titre;
            this.Sous_Titre = Sous_Titre;
            this.Resume = Resume;
            this.Fichier = Fichier;
            this.Image = Image;
            this.DateDebut = DateDebut;
            this.DateFin = DateFin;
            this.Historique = Historique;
        }
        public Projet(Projet Entity) : this (Entity.IdTypeProjet,Entity.IdUtilisateur,Entity.RecolteDesire, Entity.Titre,Entity.Sous_Titre,Entity.Resume, Entity.Fichier,Entity.Image,Entity.DateDebut,Entity.DateFin,Entity.Historique)
        {
            this.Id = Entity.Id;
        }
    }
}