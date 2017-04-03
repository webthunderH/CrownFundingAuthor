using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.MVVM.ViewModels;
using ToolBox.MVVM.Commanding;
using C = CrownFundingEdition.Administrateur.Client.Models;
using CrownFundingEdition.Administrateur.Client.Services;
using System.Reflection;

namespace CrownFundingEdition.Administrateur.MVVM.Utilisateur
{
    public class OneUtilisateurVM : ViewModelBase<C.Utilisateur>
    {
        private int _ID;
        private string _Nom, _Prenom, _Pseudo, _Password, _Adresse, _Pays, _Email, _Compte_bancaire, _Statut;
        private DateTime _DateDeNaissance;
        private RelayCommand _UpdateCommand;


        private ServiceUtilisateur _Service;
        public RelayCommand UpdateCommand
        {
            get
            {
                return _UpdateCommand??(_UpdateCommand=new RelayCommand(Update,CanUpdate));
            }
        }

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
                return _Service??(_Service=new ServiceUtilisateur());
            }
        }

        public OneUtilisateurVM(C.Utilisateur Entity, int Id, string Nom, string Prenom, string Password, string Adresse, string Pays, string Email, string Compte_bancaire, string Statut, DateTime DateDeNaissance) : this(Entity)
        {
            this.ID = Id;
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Password = Password;
            this.Adresse = Adresse;
            this.Pays = Pays;
            this.Compte_bancaire = Compte_bancaire;
            this.Statut = Statut;
            this.DateDeNaissance = DateDeNaissance;
        }
        public OneUtilisateurVM(C.Utilisateur Entity) : base(Entity)
        {

        }
        public void Update()
        {
            Entity.Pseudo = Pseudo;
            Entity.Email = Email;
            Entity.Password = Password;
            C.Utilisateur User =Service.GetOne(Entity);
            if(User!=null)
            {
                foreach (PropertyInfo item in User.GetType().GetProperties())
                {
                    if (Entity.GetType().GetProperty(item.Name).GetValue(Entity)!=item.GetValue(item))
                    {
                        User.GetType().GetProperty(item.Name).SetValue(User, item.GetValue(item));
                    }
                }
                Service.Update(User);
            }

        }
        public bool CanUpdate()
        {
            return !string.IsNullOrWhiteSpace(Pseudo) &&
                   !string.IsNullOrWhiteSpace(Email) &&
                   !string.IsNullOrWhiteSpace(Password);
        }
    }
}
