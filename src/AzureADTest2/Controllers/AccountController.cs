﻿using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Http.Authentication;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Security.OpenIdConnect;

namespace AzureADTest2.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            if (Context.User == null || !Context.User.Identity.IsAuthenticated)
                return new ChallengeResult(OpenIdConnectAuthenticationDefaults.AuthenticationType, new AuthenticationProperties { RedirectUri = "/" });
            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/LogOff
        [HttpGet]
        public IActionResult LogOff()
        {
            if (Context.User.Identity.IsAuthenticated)
                Context.Response.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return RedirectToAction("Index", "Home");
        }
    }
}