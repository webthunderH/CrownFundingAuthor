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

namespace CrownFundingEdition.Administrateur.MVVM.Categorie
{
    public class OneCategorieVM : ViewModelBase<C.Categorie>
    {
        private ServiceCategorie _Service;
        private RelayCommand _Update;
        private int _Id;
        private string _Nom, _Restriction, _Description;
        #region Value getter/setter
        public string Description
        {
            get
            {
                return _Description;
            }

            set
            {
                _Description = value;
            }
        }

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

        public string Restriction
        {
            get
            {
                return _Restriction;
            }

            set
            {
                _Restriction = value;
            }
        }
        #endregion

        public OneCategorieVM(C.Categorie Entity,string Nom, string Restriction, string Description):this(Entity)
        {
            this.Description = Description;
            this.Nom = Nom;
            this.Restriction = Restriction;
        }
        public OneCategorieVM(C.Categorie Entity) : base(Entity)
        {
            this.Id = Entity.Id;
        }
        public ServiceCategorie Service
        {
            get
            {
                return _Service ?? (_Service = new ServiceCategorie());
            }
        }   
        public void Update()
        {
            Entity.Nom = Nom;
            Entity.Description = Description;
            Entity.Restriction = Restriction;
            C.Categorie User = Service.GetOne(Entity);
            if (User != null)
            {
                foreach (PropertyInfo item in User.GetType().GetProperties())
                {
                    if (Entity.GetType().GetProperty(item.Name).GetValue(Entity) != item.GetValue(item))
                    {
                        User.GetType().GetProperty(item.Name).SetValue(User, item.GetValue(item));
                    }
                }
                Service.Update(User);
            }

        }
        public bool CanUpdate()
        {
            return !string.IsNullOrWhiteSpace(Nom) &&
                   !string.IsNullOrWhiteSpace(Description) &&
                   !string.IsNullOrWhiteSpace(Restriction)&&
                   !(Nom !=Entity.Nom && Description != Entity.Description && Restriction != Entity.Restriction );
        }
    }
}
