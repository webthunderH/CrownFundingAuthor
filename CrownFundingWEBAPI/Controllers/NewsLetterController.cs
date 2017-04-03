using CrownFundingWEBAPI.Models;
using Gl = Repository.Global;
using Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace CrownFundingWEBAPI.Controllers
{
    public class NewsLetterController : ApiController
    {
        private ServiceNewsLetter _Sn;

        public ServiceNewsLetter Sn
        {
            get
            {
                return _Sn??(_Sn=new ServiceNewsLetter());
            }
        }

        [Route("api/newsletter/getall")]
        public IEnumerable<NewsLetter> GetAll()
        {
            List<NewsLetter> Selection = new List<NewsLetter>();
            foreach (Gl.NewsLetter item in Sn.GetAll())
            {
                Selection.Add(Mappers<Gl.NewsLetter, NewsLetter>.VueToEntities(item));
            }
            return Selection;

        }
        [Route("api/newsletter/insert")]
        public void insert(NewsLetter Entity)
        {
            Sn.insert(Mappers<NewsLetter, Gl.NewsLetter>.VueToEntities(Entity));

        }
        [Route("api/newsletter/delete")]
        public void delete()
        {
            // rajouter un delete all ! fait

            Sn.delete();
        }
        [Route("api/newsletter/listeemail")]
        public IEnumerable<EmailNew> AllEmail()
        {
            List<EmailNew> Selection = new List<EmailNew>();
            foreach  (Gl.VUtilNewsLetter item in Sn.AllEmail())
            {
                Selection.Add(Mappers<Gl.VUtilNewsLetter, EmailNew>.VueToEntities(item));
            }
            return Selection;
        }
    }
}
