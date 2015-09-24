using MyDemoApp.Models.Views;
using MyDemoApp.Logic.Models;
using MyDemoApp.Logic.Services;
using MyDemoApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyDemoApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IServiceFactory _factory = null;
        private readonly Func<DepartmentViewModel, DepartmentModel> _toBusinessModel = null;
        private readonly Func<DepartmentModel, DepartmentViewModel> _toViewModel = null;

        public DepartmentController(IServiceFactory factory)
        {
            this._factory = factory;

            this._toViewModel = x => new DepartmentViewModel
            {
                Id = x.Id,
                Name = x.Name,
            };

            this._toBusinessModel = x => new DepartmentModel
            {
                Id = x.Id,
                Name = x.Name,
            };
        }

        //
        // GET: /Department/Create
        public ActionResult Create()
        {
            return View(new DepartmentViewModel());
        }

        //
        // POST: /Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                DepartmentService service = new DepartmentService(db);
                service.Add(this._toBusinessModel(viewModel));
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Department/Delete
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var viewModel = new DepartmentViewModel();

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                DepartmentService service = new DepartmentService(db);
                var model = service.GetObjectList(x => x.Id == id).FirstOrDefault();

                if (model == null)
                {
                    return RedirectToAction("Index");
                }

                viewModel = this._toViewModel(model);
            }

            return View(viewModel);
        }

        //
        // POST: /Department/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DepartmentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                DepartmentService service = new DepartmentService(db);
                var model = service.GetObjectList(x => x.Id == viewModel.Id).FirstOrDefault();

                if (model == null)
                {
                    return RedirectToAction("Index");
                }

                service.Delete(this._toBusinessModel(viewModel));

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Department/Details
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var viewModel = new DepartmentViewModel();

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                DepartmentService service = new DepartmentService(db);
                var model = service.GetObjectList(x => x.Id == id).FirstOrDefault();

                if (model == null)
                {
                    return RedirectToAction("Index");
                }

                viewModel = this._toViewModel(model);
            }

            return View(viewModel);
        }

        //
        // GET: /Department/Edit
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var viewModel = new DepartmentViewModel();

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                DepartmentService service = new DepartmentService(db);
                var model = service.GetObjectList(x => x.Id == id).FirstOrDefault();

                if (model == null)
                {
                    return RedirectToAction("Index");
                }

                viewModel = this._toViewModel(model);
            }

            return View(viewModel);
        }

        //
        // POST: /Department/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                DepartmentService service = new DepartmentService(db);
                var model = service.GetObjectList(x => x.Id == viewModel.Id).FirstOrDefault();

                if (model == null)
                {
                    return RedirectToAction("Index");
                }

                service.Update(this._toBusinessModel(viewModel));

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Department/
        public ActionResult Index()
        {
            var modelList = new List<DepartmentViewModel>();

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                DepartmentService service = new DepartmentService(db);

                foreach (var model in service.GetObjectList())
                {
                    modelList.Add(this._toViewModel(model));
                }
            }

            return View(modelList);
        }
    }
}