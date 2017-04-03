using CrownFundingEdition.Administrateur.Client.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;
using ToolBox.MVVM.Commanding;
using ToolBox.MVVM.ViewModels;
using C = CrownFundingEdition.Administrateur.Client.Models;

namespace CrownFundingEdition.Administrateur.MVVM.Projet
{
    public class AllProjetVM : ViewModelCollectionBase<OneProjetVM>
    {
        private ServiceProjet _Service;
        private RelayCommand _DeleteCommand;
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
        protected override ObservableCollection<OneProjetVM> LoadItems()
        {
            ObservableCollection<OneProjetVM> Selection = new ObservableCollection<OneProjetVM>();
            foreach (C.Projet item in Service.GetAll())
            {
                Selection.Add(AutoMappers<C.Projet, OneProjetVM>.AutoMapper(item));
            }
            return Selection;
        }
        public ServiceProjet Service
        {
            get
            {
                return _Service ?? (_Service = new ServiceProjet());
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                return _DeleteCommand ?? (_DeleteCommand = new RelayCommand(Delete, CanDelete));
            }
        }

        
        public void Delete()
        {
            Service.Delete(AutoMappers<OneProjetVM, C.Projet>.AutoMapper(SelectedItem));
        }
        private bool CanDelete()
        {
            return SelectedItem != null;
        }
        public OneProjetVM GetFiche()
        {
            C.Projet User = Service.GetOne(AutoMappers<OneProjetVM, C.Projet>.AutoMapper(SelectedItem));
            // Utiliser un médiator pour pouvoir afficher la ressource nécéssaire (qui sera la même pour tous. Chaque information ^Doit obtenir toute ! les informations sur une utilisateur)//
            return AutoMappers<C.Projet, OneProjetVM>.AutoMapper(User);
        }
    }
}
