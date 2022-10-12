﻿using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient.Memcached;
using RestSharp;

namespace FinalWFMProject.Controllers
{
    public class ManagerController : Controller
    {

        // GET: ManagerController
        List<Manager> details = new List<Manager>();
        public ActionResult Index()
        {
            string Uri = string.Format("http://localhost:44586");
            RestRequest request = new RestRequest(Uri);
            var response = Client.ExecuteTaskAsync<List<Core.Models>>(request);
            details = response.Result;
            return View("Manager", details);
        }

        // GET: ManagerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManagerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerController/Edit/5
        public ActionResult Edit(int id)
        {
            Manager e = details.Where(x => x.LockId == id).SingleOrDefault();
            return View("EditManager");
        }

        // POST: ManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Manager details)
        {
            try
            {
                int id = details.LockId;
                string Uri = string.Format("http://localhost:44586");
                RestRequest request = new RestRequest(Uri);
                var response = client.ExecuteTaskAsync<List<Core.Models>>(request);
                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManagerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
