using MyDemoApp.Core;
using MyDemoApp.Logic.Models;
using MyDemoApp.Logic.Services;
using MyDemoApp.Models.Views;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MyDemoApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IServiceFactory _factory = null;
        private readonly Func<EmployeeViewModel, EmployeeModel> _toBusinessModel = null;
        private readonly Func<EmployeeModel, EmployeeViewModel> _toViewModel = null;

        public EmployeeController(IServiceFactory factory)
        {
            this._factory = factory;

            this._toViewModel = x => new EmployeeViewModel
            {
                Id = x.Id,
                Name = x.Name,
                DepartmentId = x.DepartmentId,
            };

            this._toBusinessModel = x => new EmployeeModel
            {
                Id = x.Id,
                Name = x.Name,
                DepartmentId = x.DepartmentId,
            };
        }

        //
        // GET: /Employee/Create
        public ActionResult Create()
        {
            return View(new EmployeeViewModel());
        }

        //
        // POST: /Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                EmployeeService service = new EmployeeService(db);
                service.Add(this._toBusinessModel(viewModel));
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Employee/Delete
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var viewModel = new EmployeeViewModel();

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                EmployeeService service = new EmployeeService(db);
                var model = service.GetObject(x => x.id == id);

                if (model == null)
                {
                    return RedirectToAction("Index");
                }

                viewModel = this._toViewModel(model);
            }

            return View(viewModel);
        }

        //
        // POST: /Employee/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmployeeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                EmployeeService service = new EmployeeService(db);
                var model = service.GetObject(x => x.id == viewModel.Id);

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
        // GET: /Employee/Details
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var viewModel = new EmployeeViewModel();

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                EmployeeService service = new EmployeeService(db);
                var model = service.GetObject(x => x.id == id);

                if (model == null)
                {
                    return RedirectToAction("Index");
                }

                viewModel = this._toViewModel(model);
            }

            return View(viewModel);
        }

        //
        // GET: /Employee/Edit
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var viewModel = new EmployeeViewModel();

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                EmployeeService service = new EmployeeService(db);
                var model = service.GetObject(x => x.id == id);

                if (model == null)
                {
                    return RedirectToAction("Index");
                }

                viewModel = this._toViewModel(model);
            }

            return View(viewModel);
        }

        //
        // POST: /Employee/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                EmployeeService service = new EmployeeService(db);

                var model = service.GetObject(x => x.id == viewModel.Id);

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
        // GET: /Employee/
        //[OutputCache(CacheProfile = "Long", VaryByHeader = "X-Requested-With;Accept-Language", Location = OutputCacheLocation.Server)]
        public ActionResult Index(int? page = 1)
        {
            IPagedList<EmployeeViewModel> list = null;

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                EmployeeService service = new EmployeeService(db);
                list = service.GetPagedList(this._toViewModel, page ?? 1);
            }

            return View(list);
        }
    }
}