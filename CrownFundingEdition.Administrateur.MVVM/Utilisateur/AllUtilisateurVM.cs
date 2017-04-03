using CrownFundingEdition.Administrateur.Client.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.MVVM.ViewModels;
using C = CrownFundingEdition.Administrateur.Client.Models;
using ToolBox.MVVM.Commanding;
using ToolBox;

namespace CrownFundingEdition.Administrateur.MVVM.Utilisateur
{
    public class AllUtilisateurVM : ViewModelCollectionBase<OneUtilisateurVM>
    {
        private ServiceUtilisateur _Service;
        private RelayCommand _DeleteCommand;
        private int _ID;
        private string _Nom, _Prenom, _Pseudo, _Password, _Adresse, _Pays, _Email, _Compte_bancaire, _Statut;
        private DateTime _DateDeNaissance;
  

        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;

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

        public string Prenom
        {
            get
            {
                return _Prenom;
            }

            set
            {
                _Prenom = value;
                RaisePropertyChanged("Prenom");
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
                RaisePropertyChanged("Pseudo");
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
                RaisePropertyChanged("Password");
            }
        }

        public string Adresse
        {
            get
            {
                return _Adresse;
            }

            set
            {
                _Adresse = value;
                RaisePropertyChanged("Adresse");
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
                RaisePropertyChanged("Pays");
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
                RaisePropertyChanged("Email");
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
                RaisePropertyChanged("Compte_bancaire");
            }
        }

        public string Statut
        {
            get
            {
                return _Statut;
            }

            set
            {
                _Statut = value;
                RaisePropertyChanged("Statut");
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
                RaisePropertyChanged("DateDeNaissance");
            }
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
                return _DeleteCommand??(_DeleteCommand=new RelayCommand(Delete,CanDelete));
            }
        }  

        protected override ObservableCollection<OneUtilisateurVM> LoadItems()
        { 
            ObservableCollection<OneUtilisateurVM> ListeMembre = new ObservableCollection<OneUtilisateurVM>();
            foreach (C.Utilisateur User in Service.GetAll())
            {
                OneUtilisateurVM OneUser = new OneUtilisateurVM(User);
                ListeMembre.Add(OneUser);
            }
            return ListeMembre;
        }
        public void Delete()
        {  
            Service.Delete(AutoMappers<OneUtilisateurVM,C.Utilisateur>.AutoMapper(SelectedItem));
        }
        private bool CanDelete()
        {
            return SelectedItem != null;
        }
        public OneUtilisateurVM GetFiche()
        {
            C.Utilisateur User =Service.GetOne(AutoMappers < OneUtilisateurVM, C.Utilisateur >.AutoMapper(SelectedItem));
            // Utiliser un médiator pour pouvoir afficher la ressource nécéssaire (qui sera la même pour tous. Chaque information ^Doit obtenir toute ! les informations sur une utilisateur)//
            return AutoMappers<C.Utilisateur,OneUtilisateurVM>.AutoMapper(User);
        }

    }
}
