using Microsoft.AspNetCore.Mvc;
using TibaSchool.BL.Helper;
using TibaSchool.BL.VModels;

namespace TibaSchool.PL.Controllers
{
    public class ContactController : Controller
    {
        #region Actions

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(MailVM mail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["Msg"] = MailSender.SendMail(mail);
                    return RedirectToAction("Contact");
                }
                return View();
            }
            catch (Exception ex)
            {
               TempData["Msg"] = "Faild";
               return View();
            }

        }
        #endregion
    }
}
