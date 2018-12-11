using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Syn.Bot.Oscova;
namespace EBoutique
{
    public class ChatBotC
    {
        OscovaBot ob;
        public ChatBotC()
        {
          ob = new OscovaBot();
            //Ajouter dialogue (base de connaissane)
            ob.Dialogs.Add(new BaseConnaissance());
            //Connexion avec bd
            ConnectionavecBase conB = new ConnectionavecBase();
            ob.MainUser.Context.SharedData.Add(conB);
            ob.CreateRecognizer("Categorie", new[] { "T-Shirt", "Short", "Survêtement", "Gilet", "Jacket", "Veste", "Tops", "Robes", "Jupes", "Jeans", "Pantalons" });
            ob.Trainer.StartTraining();
        }
        public String reponseQuestion(String req)
        {
            EvaluationResult ev = ob.Evaluate(req);
            ev.Invoke();
            Response resp = ob.MainUser.Responses.First<Response>();
            return resp.Text;
        }
    }
}