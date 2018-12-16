using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWEB_M3.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Components.Any())
            {
                return;   // DB has been seeded
            }

            var components = new Component[]
            {
                new Component
                {
                    AdminComment = "asdas",
                    ComponentNumber = 123,
                    SerialNo = "dasdsadas",
                    Status = ComponentTypeStatus.Available,
                    UserComment = "asdsadsada"
                },
                new Component
                {
                    AdminComment = "asdasdasda",
                    ComponentNumber = 321,
                    SerialNo = "asdasd",
                    Status = ComponentTypeStatus.Defect,
                    UserComment = "sadsadsadsa"
                },

            };

            foreach (Component s in components)
            {
                context.Components.Add(s);
            }

            context.SaveChanges();
        }
    }
}
