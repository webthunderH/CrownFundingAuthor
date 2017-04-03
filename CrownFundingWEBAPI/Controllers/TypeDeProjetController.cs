using CrownFundingWEBAPI.Models;
using Gl=Repository.Global;
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
    public class TypeDeProjetController : ApiController
    {
        private ServiceTypeDeProjet _Stp;

        public ServiceTypeDeProjet Stp
        {
            get
            {
                return _Stp??(_Stp=new ServiceTypeDeProjet());
            }
            
        }

        [Route("api/tprojet/getone")]
        public TypeDeProjet GetOne(TypeDeProjet Entity)
        {
            Gl.TypeDeProjet GlTp = Mappers<TypeDeProjet, Gl.TypeDeProjet>.StoredProcedureToVue(Entity);
            return Mappers<Gl.TypeDeProjet,TypeDeProjet>.VueToEntities(Stp.GetOne(GlTp));
        }
        [Route("api/tprojet/getall")]
        public IEnumerable<TypeDeProjet> GetAll()
        {
            List<TypeDeProjet> Selection = new List<TypeDeProjet>();
            foreach (Gl.TypeDeProjet item in Stp.GetAll())
            {
                Selection.Add(Mappers<Gl.TypeDeProjet, TypeDeProjet>.VueToEntities(item));
            }
            return Selection;
        } 
        [Route("api/tprojet/update")]
        public void Update(TypeDeProjet Entity)
        {
            Stp.Update(Mappers<TypeDeProjet, Gl.TypeDeProjet>.VueToEntities(Entity));
        }
        [Route("api/tprojet/insert")]
        public TypeDeProjet Insert(TypeDeProjet Entity)
        {
            Gl.TypeDeProjet Intermediaire = Stp.Insert(Mappers<TypeDeProjet, Gl.TypeDeProjet>.VueToEntities(Entity));
            return Mappers<Gl.TypeDeProjet, TypeDeProjet>.VueToEntities(Intermediaire);

        }
        [Route("api/tprojet/delete")]
        public void delete (TypeDeProjet Entity)
        {
            Stp.delete(Mappers<TypeDeProjet, Gl.TypeDeProjet>.VueToEntities(Entity));  
        }
    }
}
