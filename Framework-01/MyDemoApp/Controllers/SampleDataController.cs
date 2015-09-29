using MyDemoApp.Core;
using MyDemoApp.Logic.Models;
using MyDemoApp.Logic.Services;
using MyDemoApp.Models.Views;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MyDemoApp.Controllers
{
    public class SampleDataController : Controller
    {
        private readonly IServiceFactory _factory = null;
        private readonly Func<SampleDataViewModel, SampleDataModel> _toBusinessModel = null;
        private readonly Func<SampleDataModel, SampleDataViewModel> _toViewModel = null;

        public SampleDataController(IServiceFactory factory)
        {
            this._factory = factory;

            this._toViewModel = x => new SampleDataViewModel
            {
                Id = x.Id,
                Col01 = x.Col01,
                Col02 = x.Col02,
                Col03 = x.Col03,
                Col04 = x.Col04,
                Col05 = x.Col05,
                Col06 = x.Col06,
                Col07 = x.Col07,
                Col08 = x.Col08,
                Col09 = x.Col09,
                Col10 = x.Col10,
                Col11 = x.Col11,
                Col12 = x.Col12,
                Col13 = x.Col13,
                Col14 = x.Col14,
                Col15 = x.Col15,
                Col16 = x.Col16,
                Col17 = x.Col17,
                Col18 = x.Col18,
                Col19 = x.Col19,
                Col20 = x.Col20,
                Col21 = x.Col21,
                Col22 = x.Col22,
                Col23 = x.Col23,
                Col24 = x.Col24,
                Col25 = x.Col25,
                Col26 = x.Col26,
                Col27 = x.Col27,
                Col28 = x.Col28,
                Col29 = x.Col29,
                Col30 = x.Col30,
            };

            this._toBusinessModel = x => new SampleDataModel
            {
                Id = x.Id,
                Col01 = x.Col01,
                Col02 = x.Col02,
                Col03 = x.Col03,
                Col04 = x.Col04,
                Col05 = x.Col05,
                Col06 = x.Col06,
                Col07 = x.Col07,
                Col08 = x.Col08,
                Col09 = x.Col09,
                Col10 = x.Col10,
                Col11 = x.Col11,
                Col12 = x.Col12,
                Col13 = x.Col13,
                Col14 = x.Col14,
                Col15 = x.Col15,
                Col16 = x.Col16,
                Col17 = x.Col17,
                Col18 = x.Col18,
                Col19 = x.Col19,
                Col20 = x.Col20,
                Col21 = x.Col21,
                Col22 = x.Col22,
                Col23 = x.Col23,
                Col24 = x.Col24,
                Col25 = x.Col25,
                Col26 = x.Col26,
                Col27 = x.Col27,
                Col28 = x.Col28,
                Col29 = x.Col29,
                Col30 = x.Col30,
            };
        }

        //
        // GET: /SampleData/Create
        public ActionResult Create()
        {
            return View(new SampleDataViewModel());
        }

        //
        // POST: /SampleData/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SampleDataViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                SampleDataService service = new SampleDataService(db);
                service.Add(this._toBusinessModel(viewModel));
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /SampleData/Delete
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var viewModel = new SampleDataViewModel();

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                SampleDataService service = new SampleDataService(db);
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
        // POST: /SampleData/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SampleDataViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                SampleDataService service = new SampleDataService(db);
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
        // GET: /SampleData/Details
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var viewModel = new SampleDataViewModel();

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                SampleDataService service = new SampleDataService(db);
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
        // GET: /SampleData/Edit
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var viewModel = new SampleDataViewModel();

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                SampleDataService service = new SampleDataService(db);
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
        // POST: /SampleData/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SampleDataViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                SampleDataService service = new SampleDataService(db);
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
        // GET: /SampleData/
        public ActionResult Index(int? page = 1)
        {
            IPagedList<SampleDataViewModel> pagedList = null;

            using (ModelRepository db = new ModelRepository(this._factory.GetDatabaseObject()))
            {
                SampleDataService service = new SampleDataService(db);
                pagedList = service.GetPagedList(this._toViewModel, page ?? 1);
            }

            return View(pagedList);
        }
    }
}