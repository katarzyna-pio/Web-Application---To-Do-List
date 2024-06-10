using System;
using Microsoft.AspNetCore.Mvc;
using nowa_aplikacja.Models;
using nowa_aplikacja.Repositories;

namespace nowa_aplikacja.Controllers
{
    public class ValuesController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public ValuesController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IActionResult Index(string location)
        {
            ViewBag.Location = location ?? "Warsaw"; // Domyślna lokalizacja
            var tasks = _taskRepository.GetAllActive();
            return View(tasks);
        }

        // Inne metody pozostają bez zmian

        public ActionResult Details(int id)
        {
            return View(_taskRepository.Get(id));
        }

        public ActionResult Create()
        {
            return View(new TaskModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel taskModel)
        {
            _taskRepository.Add(taskModel);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            return View(_taskRepository.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel taskModel)
        {
            _taskRepository.Update(id, taskModel);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            return View(_taskRepository.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taskModel)
        {
            _taskRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Done(int id)
        {
            TaskModel task = _taskRepository.Get(id);
            task.Done = true;
            _taskRepository.Update(id, task);
            return RedirectToAction(nameof(Index));
        }
    }
}
