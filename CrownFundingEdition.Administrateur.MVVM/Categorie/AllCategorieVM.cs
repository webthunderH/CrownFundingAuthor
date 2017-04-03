using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.MVVM.ViewModels;

namespace CrownFundingEdition.Administrateur.MVVM.Categorie
{
    public class AllCategorieVM : ViewModelCollectionBase<OneCategorieVM>
    {
        protected override ObservableCollection<OneCategorieVM> LoadItems()
        {
            throw new NotImplementedException();
        }
        public ServiceUtilisateur Service
        {
            get
            {
                return _Service ?? (_Service = new ServiceUtilisateur());
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
        public OneUtilisateurVM GetFiche()
        {
            C.Utilisateur User = Service.GetOne(AutoMappers<OneUtilisateurVM, C.Utilisateur>.AutoMapper(SelectedItem));
            // Utiliser un médiator pour pouvoir afficher la ressource nécéssaire (qui sera la même pour tous. Chaque information ^Doit obtenir toute ! les informations sur une utilisateur)//
            return AutoMappers<C.Utilisateur, OneUtilisateurVM>.AutoMapper(User);
        }
    }
}
