using SDW.WebServiceJogo.MVC.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogoAPI.Models
{
    public class JogoContextInitializer : DropCreateDatabaseIfModelChanges<JogoContext>
    {
        protected override void Seed(JogoContext context)
        {
            // Use the context to seed the db.
        }
    }
}