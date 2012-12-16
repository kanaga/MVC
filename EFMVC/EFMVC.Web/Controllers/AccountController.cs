using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EFMVC.Web.ViewModels;
using EFMVC.Domain.Commands;
using EFMVC.Web.Core.Models;
using EFMVC.CommandProcessor.Dispatcher;
using EFMVC.Data.Repositories;
using EFMVC.Core.Common;
using EFMVC.Web.Core.Extensions;
using EFMVC.Web.Core.Authentication;
using EFMVC.Model;
namespace EFMVC.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICommandBus commandBus;
        private readonly IUserRepository userRepository;
        private readonly IFormsAuthentication formAuthentication;
    
        public AccountController(ICommandBus commandBus, IUserRepository userRepository, IFormsAuthentication formAuthentication)
        {
            this.commandBus = commandBus;
            this.userRepository = userRepository;
            this.formAuthentication = formAuthentication;
        }       

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnFormModel form, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = userRepository.Get(u => u.Email == form.UserName && u.Activated == true);
                if (user != null)
                {
                    if (ValidatePassword(user, form.Password))
                    {
                        formAuthentication.SetAuthCookie(this.HttpContext,
                                                                 UserAuthenticationTicketBuilder.CreateAuthenticationTicket(
                                                                     user));
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }                        
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(form);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            formAuthentication.Signout();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(UserFormModel form)
        {
            if (ModelState.IsValid)
            {
                var command = new UserRegisterCommand
                {
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    Email=form.Email,
                    Password = form.Password,
                    Activated = true,
                    RoleId = (Int32)UserRoles.User
                };
                IEnumerable<ValidationResult> errors = commandBus.Validate(command);               
                ModelState.AddModelErrors(errors);            
                if (ModelState.IsValid)
                {
                    var result = commandBus.Submit(command);
                    if (result.Success)
                    {
                        User user = userRepository.Get(u => u.Email == form.Email);
                        formAuthentication.SetAuthCookie(this.HttpContext,
                                                          UserAuthenticationTicketBuilder.CreateAuthenticationTicket(
                                                              user));
                        return RedirectToAction("Index", "Home");
                    }
                } 
            }
            // If fail
            return View(form);
        }
        private bool ValidatePassword(User user, string password)
        {
            var encoded = Md5Encrypt.Md5EncryptPassword(password);
            return user.PasswordHash.Equals(encoded);
        }
    }
}
