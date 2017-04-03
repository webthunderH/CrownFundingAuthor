using Repository.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class ServiceNewsLetter
    {
        
        public IEnumerable<NewsLetter> GetAll()
        {
            using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
            {
                List<NewsLetter> Selection = Context.NewsLetter.ToList();
                if (Selection.First() != null)
                {
                    return Selection;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("La variable selection ne contient aucun Utilisateur");
                }
            }
        }
        
        public void insert(NewsLetter Entity)
        {
            if (Entity != null)
            {
                using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
                {
                    Context.NewsLetter.Add(Entity);
                    Context.SaveChanges();
                    
                }
            }
            else
            {
                throw new ArgumentException("La méthode Inser n'a pas fonctionné");
            }
        }
       
        public void delete()
        {

            using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
            {
                Context.NewsLetter.RemoveRange(Context.NewsLetter.ToList());
                Context.SaveChanges();
                
            }
        }
        
        public IEnumerable<VUtilNewsLetter> AllEmail()
        {
            using (Crownfunding_EditionEntities Context = new Crownfunding_EditionEntities())
            {
                List<VUtilNewsLetter> Selection = Context.VUtilNewsLetter.ToList();
                if (Selection.First() != null)
                {
                    return Selection;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("La variable selection ne contient aucun Utilisateur");
                }
            }
        }
    }
}
