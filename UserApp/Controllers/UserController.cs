using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserApp.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;


namespace UserApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserDataAccessLayer _userDataAccessLayer;

        public UserController(IUserDataAccessLayer userDataAccessLayer)
        {
            _userDataAccessLayer = userDataAccessLayer;
        }

        public IActionResult Index()
        {
            //return View();
            return RedirectToAction("Create");
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]         //NEED TO ASYNC
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] User user)
        {
            if (ModelState.IsValid)
            {
                _userDataAccessLayer.AddUser(user.Email, user.Password);

               return RedirectToAction("Index");
            }
            return View();
        }


    }
}