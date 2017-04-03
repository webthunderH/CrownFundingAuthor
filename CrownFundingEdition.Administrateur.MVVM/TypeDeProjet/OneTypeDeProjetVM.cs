using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.MVVM.ViewModels;
using C = CrownFundingEdition.Administrateur.Client.Models;
using CrownFundingEdition.Administrateur.Client.Services;
using System.Reflection;

namespace CrownFundingEdition.Administrateur.MVVM.TypeDeProjet
{
    public class OneTypeDeProjetVM : ViewModelBase<C.TypeDeProjet>
    {
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
        public OneTypeDeProjetVM(C.TypeDeProjet Entity) : base(Entity)
        {
            this.Id = Entity.Id;
        }
        public ServiceTypeDeProjet Service
        {
            get
            {
                return _Service ?? (_Service = new ServiceTypeDeProjet());
            }
        }

        public OneTypeDeProjetVM(C.TypeDeProjet Entity, string Nom, int Page_Max, int Page_Min ) : this(Entity)
        {
            this.Nom = Nom;
            this.Page_Min = Page_Min;
            this.Page_Max = Page_Max;
            
        }
       
        public void Update()
        {
            Entity.Nom = Nom;
            Entity.Page_Max = Page_Max;
            Entity.Page_Min = Page_Min;
            C.TypeDeProjet Type = Service.GetOne(Entity);

            if (Type != null)
            {
                foreach (PropertyInfo item in Type.GetType().GetProperties())
                {
                    if (Entity.GetType().GetProperty(item.Name).GetValue(Entity) != item.GetValue(item))
                    {
                        Type.GetType().GetProperty(item.Name).SetValue(Type, item.GetValue(item));
                    }
                }
                Service.Update(Type);
            }

        }
        public bool CanUpdate()
        {
            if(Nom!=null && Page_Max>Page_Min && Page_Min>0)
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
