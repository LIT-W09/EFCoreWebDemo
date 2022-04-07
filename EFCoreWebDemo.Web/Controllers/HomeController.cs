using EFCoreWebDemo.Data;
using EFCoreWebDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreWebDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var connectionString = _configuration.GetConnectionString("ConStr");
            var repo = new PeopleRepository(connectionString);
            var vm = new HomePageViewModel
            {
                People = repo.GetAll()
            };
            return View(vm);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Person person)
        {
            var connectionString = _configuration.GetConnectionString("ConStr");
            var repo = new PeopleRepository(connectionString);
            repo.Add(person);
            return Redirect("/home/index");
        }

        public IActionResult Edit(int id)
        {
            var connectionString = _configuration.GetConnectionString("ConStr");
            var repo = new PeopleRepository(connectionString);
            Person person = repo.GetById(id);
            if (person == null)
            {
                return Redirect("/home/index");
            }

            EditPageViewModel vm = new EditPageViewModel
            {
                Person = person
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Update(Person person)
        {
            var connectionString = _configuration.GetConnectionString("ConStr");
            var repo = new PeopleRepository(connectionString);
            repo.Update(person);

            return Redirect("/home/index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var connectionString = _configuration.GetConnectionString("ConStr");
            var repo = new PeopleRepository(connectionString);
            repo.Delete(id);
            return Redirect("/home/index");
        }

    }
}
