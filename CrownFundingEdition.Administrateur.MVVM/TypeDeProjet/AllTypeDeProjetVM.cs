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

namespace CrownFundingEdition.Administrateur.MVVM.TypeDeProjet
{
    public class AllTypeDeProjetVM : ViewModelCollectionBase<OneTypeDeProjetVM>
    {
        private RelayCommand _DeleteCommand, _InsertCommand;
        private ServiceTypeDeProjet _Service;
        private int _Id, _Page_Min, _Page_Max;
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
                RaisePropertyChanged("Id");
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

        public int Page_Max
        {
            get
            {
                return _Page_Max;
            }

            set
            {
                _Page_Max = value;
                RaisePropertyChanged("Page_Max");
            }
        }

        public int Page_Min
        {
            get
            {
                return _Page_Min;
            }

            set
            {
                _Page_Min = value;
                RaisePropertyChanged("Page_Min");
            }
        }
        protected override ObservableCollection<OneTypeDeProjetVM> LoadItems()
        {
           ObservableCollection<OneTypeDeProjetVM> Selection = new ObservableCollection<OneTypeDeProjetVM>();
            foreach (C.TypeDeProjet item in Service.GetAll())
            {
                Selection.Add(AutoMappers<C.TypeDeProjet, OneTypeDeProjetVM>.AutoMapper(item));
            }
            return Selection;
        }
        public ServiceTypeDeProjet Service
        {
            get
            {
                return _Service ?? (_Service = new ServiceTypeDeProjet());
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
            Service.Delete(AutoMappers<OneUtilisateurVM, C.Utilisateur>.AutoMapper(SelectedItem));
        }
        private bool CanDelete()
        {
            return SelectedItem != null;
        }
        public OneTypeDeProjetVM GetFiche()
        {
            C.Utilisateur User = Service.GetOne(AutoMappers<OneUtilisateurVM, C.Utilisateur>.AutoMapper(SelectedItem));
            // Utiliser un médiator pour pouvoir afficher la ressource nécéssaire (qui sera la même pour tous. Chaque information ^Doit obtenir toute ! les informations sur une utilisateur)//
            return AutoMappers<C.Utilisateur, OneUtilisateurVM>.AutoMapper(User);
        }
    }
}
