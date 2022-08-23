using System;
using WazenIdentity.Persistence;

namespace WazenIdentity.API.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(ApplicationDbContext context)
        {
            
            context.SaveChanges();
        }
    }
}
