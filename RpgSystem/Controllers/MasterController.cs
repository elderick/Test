using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace RpgSystem.Controllers
{
    public class MasterController : Controller
    {
        //
        // GET: /Master/

        public ActionResult Index()
        {
            return View();
        }

        public int RollDice(int dicenumber)
        {
            Random dice = new Random();
            var result = dice.Next(1, dicenumber);
            return result;
        }
        public string VampireTest(int atributepoints, int difficult)
        {
            //TODO: transformar o resultado em HTML
            string text = "Resultado dos dados:";
            int sucess = 0;

            for (int i = 0; i < atributepoints; i++)
            {
                var result = RollDice(10);
                text = text + " " + result;
                if (result >= difficult)
                {
                    sucess++;
                }
                else if (result == 1)
                {
                    sucess--;
                }
                else
                {
                    continue;
                }

            }
            text = text + "Numero de acertos: " + sucess + "";

            return text;
        }
        public void discordSendMessage(string text)
        {
        }
    }
}
