using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrownFundingWEBAPI.Models
{
    public class TypeDeProjet
    {
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

        public int Page_Max
        {
            get
            {
                return _Page_Max;
            }

            set
            {
                _Page_Max = value;
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
            }
        }
        public TypeDeProjet(string Nom, int Page_Max, int Page_Min)
        {
            this.Nom = Nom;
            this.Page_Max = Page_Max;
            this.Page_Min = Page_Min;
        }
        public TypeDeProjet(int Id, string Nom, int Page_Max, int Page_Min) : this(Nom, Page_Max, Page_Min)
        {
            this.Id = Id;
        }
    }
}