using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RpgSystem.ViewModel.Login;
using RpgSystem.Models;


namespace Aplicacao.Controllers
{
    public class LoginController : Controller
    {
        DataEntities1 bd = new DataEntities1();
        public ActionResult Index()
        {
            return View();
        }


        //public ActionResult RelembrarSenha()
        //{
        //    return View();
        //}



        [HttpPost]
        public ActionResult Index(User model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string username = (model.nick == null ? "" : model.nick);
                string hashSenha = (model.password == null ? "" : model.password);

                User userValid = (from u in bd.Players
                                  where u.usernick == username && u.password == hashSenha
                                  select new User
                               {
                                   idPlayer = u.Id,
                                   nick = u.usernick,
                                   password = u.password,
                                   master = u.master,

                               }).FirstOrDefault();

                if (userValid != null && !string.IsNullOrEmpty(userValid.nick))
                {
                    FormsAuthentication.SetAuthCookie(userValid.nick.ToString(), false);
                    Session["CodUsuarioLogado"] = userValid.idPlayer;
                    Session["NomeUsuario"] = userValid.nick;
                    if (userValid.master == true)
                    {
                        return RedirectToAction("Index", "Master");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Player");
                    }


                }
                else
                {

                    SaveTempData("MensagemErro", "Wrong User.");
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Authentication");
        }

        //#region Recuperação de senha
        //[HttpPost]
        //[AllowAnonymous]
        //public ActionResult LembrarSenha(Usuario user)
        //{
        //    if (user != null && !String.IsNullOrEmpty(user.Email))
        //    {
        //        try
        //        {
        //            var db = new Dell_Governo_DevEntities();
        //            verifica se o domínio existe
        //            string mailUsuario = "@" + user.Email.Split('@')[1];

        //            var usuario = (from u in db.Usuarios
        //                           where u.Email == user.Email && u.Ativo == true
        //                           select u).FirstOrDefault();

        //            if (usuario != null)
        //            {
        //                var sender = new EmailSender();


        //                var mail = new MailModel
        //                {
        //                    Destinatarios = new List<string> { usuario.Email },
        //                    Assunto = ">Portal Dell - Recuperação de Senha",
        //                    Mensagem = TemplatesEmail.RecuperacaoSenha.Replace("{Param:Login}", usuario.Login)
        //                                                              .Replace("{Param:Senha}", usuario.Senha)
        //                                                              .Replace("{Param:Url}", "http://" + Request.Url.Authority)
        //                };

        //                try
        //                {
        //                    sender.EnviarEmail(mail);
        //                    SaveTempData("Mensagem", "E-mail enviado!");
        //                    return RedirectToAction("RelembrarSenha");
        //                }
        //                catch (Exception ex)
        //                {
        //                    SaveTempData("MensagemErro", "Houve um problema ao enviar e-mail");
        //                    return RedirectToAction("RelembrarSenha");
        //                }
        //            }
        //            else
        //            {
        //                SaveTempData("MensagemErro", "E-mail não cadastrado no portal.");
        //                return RedirectToAction("");
        //                return View("Index");

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            SaveTempData("MensagemErro", "E-mail inválido.");
        //        }
        //    }
        //    else
        //    {
        //        SaveTempData("MensagemErro", "O campo E-mail é obrigatório.");
        //        ViewBag.Mensagem = "O campo E-mail é obrigatório.";
        //    }

        //    return RedirectToAction("RelembrarSenha");
        //}

        //private string GeraSenha()
        //{
        //    string guid = Guid.NewGuid().ToString().Replace("-", "");

        //    Random clsRan = new Random();
        //    Int32 tamanhoSenha = clsRan.Next(6, 18);

        //    string senha = "";
        //    for (Int32 i = 0; i <= tamanhoSenha; i++)
        //    {
        //        senha += guid.Substring(clsRan.Next(1, guid.Length), 1);
        //    }

        //    return senha;
        //}

        protected void SaveTempData(string key, object data)
        {
            if (TempData.ContainsKey(key))
            {
                TempData.Remove(key);
            }

            TempData[key] = data;
        }

        //#endregion
    }
}
