using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrownFundingEdition.Administrateur.Client
{
    internal static class Mappers<TEntityEnvoi,TEntityRetour>
    {
        internal static TEntityRetour AutoMapper(TEntityEnvoi Entity)
        {
            TEntityRetour Monchangement = Activator.CreateInstance<TEntityRetour>();
            foreach (PropertyInfo item in Entity.GetType().GetProperties())
            {
                if (Entity.GetType().GetProperty(item.Name)== Monchangement.GetType().GetProperty(item.Name))
                {
                var EntityValue = Entity.GetType().GetProperty(item.Name).GetValue(Entity);
                Monchangement.GetType().GetProperty(item.Name).SetValue(Monchangement, EntityValue);
                }
            }
            return Monchangement;
        }
    }
}
