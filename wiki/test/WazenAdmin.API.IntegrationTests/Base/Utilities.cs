using System;
using WazenAdmin.Persistence;

namespace WazenAdmin.API.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(ApplicationDbContext context)
        {
            

            context.SaveChanges();
        }
    }
}
