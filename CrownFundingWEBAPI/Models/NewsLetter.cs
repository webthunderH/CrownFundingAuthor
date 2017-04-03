using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrownFundingWEBAPI.Models
{
    public class NewsLetter
    {
        private int _Id;
        private DateTime _DateDeLinformation; 
        private string _TexteInformatif;

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

        public DateTime DateDeLinformation
        {
            get
            {
                return _DateDeLinformation;
            }

            set
            {
                _DateDeLinformation = value;
            }
        }

        public string TexteInformatif
        {
            get
            {
                return _TexteInformatif;
            }

            set
            {
                _TexteInformatif = value;
            }
        }
        public NewsLetter(DateTime DateDeLinformation, string TexteInformatif)
        {

        }
        public NewsLetter(NewsLetter Entity):this (Entity.DateDeLinformation, Entity.TexteInformatif)
        {
            this.Id = Entity.Id;
        }
    }
}