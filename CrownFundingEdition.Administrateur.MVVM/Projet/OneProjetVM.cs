using CrownFundingEdition.Administrateur.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToolBox.MVVM.Commanding;
using ToolBox.MVVM.ViewModels;
using C = CrownFundingEdition.Administrateur.Client.Models;

namespace CrownFundingEdition.Administrateur.MVVM.Projet
{
    public class OneProjetVM : ViewModelBase<C.Projet>
    {
        private ServiceProjet _Service;
        private RelayCommand _Upadte;
        private int _ID;
        private string _Titre, _Sous_Titre, _Nom;
        private DateTime _DateDebut, _DateFin;
        private bool _Historique;
        private int _J_aime, _Je_n_aime_Pas, _Total_Dons, _Total_Crownfunding;
        #region Getter Setter
        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
                RaisePropertyChanged("ID");
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
                RaisePropertyChanged("Titre");
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
                RaisePropertyChanged("Sous_Titre");
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
                RaisePropertyChanged("Nom");
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
                RaisePropertyChanged("DateDebut");
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
                RaisePropertyChanged("DateFin");
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
                RaisePropertyChanged("Historique");
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
                RaisePropertyChanged("J_aime");
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
                RaisePropertyChanged("Je_n_aime_Pas");
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
                RaisePropertyChanged("_Total_Dons");
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
                RaisePropertyChanged("_Total_CrownFunding");
            }
        }
        #endregion

        public OneProjetVM(C.Projet Entity) : base(Entity)
        {
            this.ID = Entity.ID;
        }
        public ServiceProjet Service
        {
            get
            {
                return _Service ?? (_Service = new ServiceProjet());
            }
        }

        public OneProjetVM(C.Projet Entity, int Id, string Titre, string Sous_Titre, string Nom, DateTime DateDeDebut, DateTime DateFin, int J_aime, int Je_n_aime_Pas, int Total_Dons, int Total_CrownFunding) : this(Entity)
        {
            
            this.Nom = Nom;
            this.Titre = Titre;
            this.Sous_Titre = Sous_Titre;
            this.Nom = Nom;
            this.DateDebut = DateDebut;
            this.DateFin = DateFin;
            this.J_aime = J_aime;
            this.Je_n_aime_Pas = Je_n_aime_Pas;
            this.Total_Dons = Total_Dons;
            this.Total_Crownfunding = Total_Crownfunding;
        }
        
        public void Update()
        {
            DateFin = Entity.DateFin;

            C.Projet Projet = Service.GetOne(Entity);
            if (Projet != null)
            {
                foreach (PropertyInfo item in Projet.GetType().GetProperties())
                {
                    if (Entity.GetType().GetProperty(item.Name).GetValue(Entity) != item.GetValue(item))
                    {
                        Projet.GetType().GetProperty(item.Name).SetValue(Projet, item.GetValue(item));
                    }
                }
                Service.Update(Projet);
            }

        }
        public bool CanUpdate()
        {
            if (DateFin != Entity.DateFin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
