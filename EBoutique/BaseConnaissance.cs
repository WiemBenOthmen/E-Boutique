using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Syn.Bot.Oscova;
using Syn.Bot.Oscova.Attributes;
namespace EBoutique
{
    public class BaseConnaissance:Dialog
    {
        [Expression("Quelle sont les prix des @Categorie?")]
        [Expression(@"[A-Za-z,.!?\s]+ prix @Categorie?")]
        public void RecupererRobe(Context c,Result r)
        { String cc = r.Entities.OfType("Categorie").Value;
            var v = c.SharedData.OfType<ConnectionavecBase>();
            //methode de la base
            String res = v.retourType(cc);
            Response resp = new Response();
            resp.Text = res;
            r.SendResponse(resp);
       

        }
       
    }
}