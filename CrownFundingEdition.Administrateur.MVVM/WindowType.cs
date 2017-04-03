using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.MVVM.Commanding;
using CrownFundingEdition.Administrateur.MVVM.Utilisateur;
using CrownFundingEdition.Administrateur.MVVM.Categorie;
using CrownFundingEdition.Administrateur.MVVM.TypeDeProjet;
using CrownFundingEdition.Administrateur.MVVM.Projet;
using ToolBox.Mediator;
using ToolBox;

namespace CrownFundingEdition.Administrateur.MVVM
{
    public class VMWindow
    {
        public enum WindowsType
        {
            MenuWindow,
            FicheWindowUtilisateur,
            FicheWindowProjet,
            FicheWindowTypeDeProjet,
            FicheWindowCategorie,
            DataGridWindowUtilisateur,
            DataGridWindowProjet,
            DataGridWindowTypeDeProjet,
            DataGridWindowCategorie,
            InsertionCategorie,
            InsertionTypeDeProjet
        }
        #region// Commande
        private RelayCommand _MainMenu, _FicheUtilisateur, _FicheProjet, _FicheTypeDeProjet, _FicheCategorie,
            _AllUtilisateur, _All_Projet, _All_TypeDeProjet, _All_Categorie, _InsertCategorie, _InsertTypeDeProjet;
        #region //MainMenu
        public RelayCommand MainMenu
        {
            get
            {
                return _MainMenu??(_MainMenu= new RelayCommand(AfficheMainMenu));
            }
        }

        private void AfficheMainMenu()
        {
			Mediator<VMWindow.WindowsType>.Send(WindowsType.MenuWindow);
        }
        #endregion
        #region FicheUtilisateur
        public RelayCommand FicheUtilisateur
        {
            get
            {
                return _FicheUtilisateur??(_FicheUtilisateur= new RelayCommand(AfficheFicheUtilisateur,CanAfficheU));
            }
        }

        private bool CanAfficheU()
        {
            AllUtilisateurVM A = new AllUtilisateurVM();
            return A.GetFiche()!=null;
        }

        private void AfficheFicheUtilisateur()
        {
			Mediator<VMWindow.WindowsType>.Send(WindowsType.FicheWindowUtilisateur);
        }
        #endregion
        #region FicheProjet
        public RelayCommand FicheProjet
        {
            get
            {
                return _FicheProjet??(_FicheProjet= new RelayCommand(AfficheFicheProjet,CanAfficheP));
            }
        }

        private void AfficheFicheProjet()
        {
            Mediator<VMWindow.WindowsType>.Send(WindowsType.FicheWindowProjet);
        }

        private bool CanAfficheP()
        {
            AllProjetVM P = new AllProjetVM();
            return P != null;
        }
        #endregion
        #region FicheTypeDeProjet
        public RelayCommand FicheTypeDeProjet
        {
            get
            {
                return _FicheTypeDeProjet??(_FicheTypeDeProjet= new RelayCommand(AfficheFicheTypeDeProjet,CanAfficheTP));
            }
        }

        private bool CanAfficheTP()
        {
            AllTypeDeProjetVM Tp = new AllTypeDeProjetVM();
            return Tp != null;
        }

        private void AfficheFicheTypeDeProjet()
        {
            Mediator<VMWindow.WindowsType>.Send(WindowsType.FicheWindowTypeDeProjet);
        }
        #endregion
        #region FicheCategorie
        public RelayCommand FicheCategorie
        {
            get
            {
                return _FicheCategorie??(_FicheCategorie= new RelayCommand(AfficheFicheCategorie,CanAfficheC));
            }
        }

        private bool CanAfficheC()
        {
            AllCategorieVM C = new AllCategorieVM();
            return C != null;
        }

        private void AfficheFicheCategorie()
        {
            Mediator<VMWindow.WindowsType>.Send(WindowsType.FicheWindowCategorie);
        }

        #endregion
        #region AllUtilisateur
        public RelayCommand AllUtilisateur
            {
                get
                {
                    return _AllUtilisateur??(_AllUtilisateur= new RelayCommand(AfficheToutUtili));
                }
            }


        private void AfficheToutUtili()
            {
                Mediator<WindowsType>.Send(WindowsType.DataGridWindowUtilisateur);
            }
        
        #endregion
        #region AllProjet
        public RelayCommand All_Projet
        {
            get
            {
                return _All_Projet ?? (_All_Projet= new RelayCommand(AfficheAllProjet));
            }
        }
        private void AfficheAllProjet()
        {
            Mediator<WindowsType>.Send(WindowsType.DataGridWindowProjet);
        }
        #endregion
        #region AllTypeDeProjet
        public RelayCommand AllTypeDeProjet
        {
            get
            {
                return _All_TypeDeProjet??(_All_TypeDeProjet= new RelayCommand(AfficheAllTypeProjet));
            }
        }
        private void AfficheAllTypeProjet()
        {
            Mediator<WindowsType>.Send(WindowsType.DataGridWindowTypeDeProjet);
        }
        #endregion
        #region AllCategorie
        public RelayCommand AllCategorie
        {
            get
            {
                return _All_Categorie??(_All_Categorie= new RelayCommand(AfficheAllCategorie));
            }
        } 
        private void AfficheAllCategorie()
        {
            Mediator<WindowsType>.Send(WindowsType.DataGridWindowCategorie);
        }
        #endregion
        #region InsertCategorie
        public RelayCommand InsertCategorie
        {
            get
            {
                return _InsertCategorie??(_InsertCategorie= new RelayCommand(AfficheFormulaireCat));
            }
        }

        private void AfficheFormulaireCat()
        {
            Mediator<WindowsType>.Send(WindowsType.InsertionCategorie);
        }
        #endregion
        #region InsertTypeDeProjet
        public RelayCommand InsertTypeDeProjet
        {
            get
            {
                return _InsertTypeDeProjet??(_InsertTypeDeProjet = new RelayCommand(AfficheFormulaireTypePro));
            }
        }

        private void AfficheFormulaireTypePro()
        {
            Mediator<WindowsType>.Send(WindowsType.InsertionTypeDeProjet);
        }
        #endregion

        #endregion
}
}




