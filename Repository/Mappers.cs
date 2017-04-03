using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal static class Mappers<TEntity, TRetour>
    {
            internal static TRetour StoredProcedureToVue(TEntity Entity)
            {
                TRetour Monchangement = Activator.CreateInstance<TRetour>();
                foreach (PropertyInfo item in Entity.GetType().GetProperties())
                {
                    var EntityValue = Entity.GetType().GetProperty(item.Name).GetValue(Entity);

                    Monchangement.GetType().GetProperty(item.Name).SetValue(Monchangement, EntityValue);

                }
                return Monchangement;
            }
            internal static TRetour VueToEntities(TEntity Entity)
            {
                TRetour Monchangement = Activator.CreateInstance<TRetour>();
                foreach (PropertyInfo item in Entity.GetType().GetProperties())
                {
                    var EntityValue = Entity.GetType().GetProperty(item.Name).GetValue(Entity);

                    Monchangement.GetType().GetProperty(item.Name).SetValue(Monchangement, EntityValue);

                }
                return Monchangement;
            }
        }
}

