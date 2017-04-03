using CrownFundingEdition.Administrateur.Client.Services;
using CrownFundingEdition.Administrateur.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Mediator;
using C=CrownFundingEdition.Administrateur.Windows;

namespace CrownFundingEdition.Administrateur
{
    public class WindowManager
    {
        public WindowManager()
        {
            Mediator<VMWindow.WindowsType>.Register(Changementfenetre);
        }

        private void Changementfenetre(object arg1, WindowsType arg2)
        {
            switch(arg2)
            {
                case VMWindow.WindowsType.MenuWindow: MainWindow XE = new MainWindow();
                    XE.ShowDialog();
                    break;
                case VMWindow.WindowsType.DataGridWindowUtilisateur: C.Utilisateur E = new C.Utilisateur();
                    E.ShowDialog();
                    break;
            }
        }
    }
}
