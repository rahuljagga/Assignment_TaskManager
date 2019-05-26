using ClientTaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace ClientTaskManager.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            List<TaskViewModel> resultData = new List<TaskViewModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52838/api/");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                //PutAsync to send a PUT request  
                var responseTask = client.GetAsync("TaskDbModels");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<TaskViewModel>>();
                    readTask.Wait();

                    resultData = readTask.Result.ToList();
                }
                else
                {
                    //Error response received   
                    resultData = Enumerable.Empty<TaskViewModel>().ToList();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(resultData);
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            TaskViewModel resultDataForEdit = new TaskViewModel();
            resultDataForEdit = GetDataFromAPI(id);
            return View(resultDataForEdit);
        }

        // POST: Task/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            TaskViewModel resultDataForDelete = new TaskViewModel();
            resultDataForDelete = GetDataFromAPI(id);
            return View(resultDataForDelete);
        }

        // POST: Task/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        private TaskViewModel GetDataFromAPI(int? id)
        {
            //Function created for fetching TaskWise data to display
            TaskViewModel resultData = new TaskViewModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52838/api/");

                var responseTask = client.GetAsync("TaskDbModels");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<TaskViewModel>>();
                    readTask.Wait();
                    resultData = readTask.Result.Where(m => m.TaskID == id).FirstOrDefault();

                }
                else
                {
                    //Error response received   
                    resultData = null;
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }

            return resultData;
        }


    }
}
