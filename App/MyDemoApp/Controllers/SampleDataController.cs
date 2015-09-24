using MyDemoApp.Core;
using MyDemoApp.Infrastructure;
using MyDemoApp.Logic.Models;
using MyDemoApp.Logic.Services;
using MyDemoApp.Models.Views;
using System;
using System.Collections.Generic;
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
        // GET: /SampleData/
        public ActionResult Index(int? page = 1)
        {
            IPagedList<SampleDataViewModel> pagedList = null;

            using (IRepository db = this._factory.GetDatabaseObject())
            {
                var pageNo = page ?? 1;
                var pageSize = 20;
                var skipIndex = pageNo * pageSize;

                pagedList = db.Query<MyDemoApp.Entities.sample_data>().ToPagedList(x => x.id, pageNo, pageSize, x => new SampleDataViewModel
                {
                    Id = x.id,
                    Col01 = x.col01,
                    Col02 = x.col02,
                    Col03 = x.col03,
                    Col04 = x.col04,
                    Col05 = x.col05,
                    Col06 = x.col06,
                    Col07 = x.col07,
                    Col08 = x.col08,
                    Col09 = x.col09,
                    Col10 = x.col10,
                    Col11 = x.col11,
                    Col12 = x.col12,
                    Col13 = x.col13,
                    Col14 = x.col14,
                    Col15 = x.col15,
                    Col16 = x.col16,
                    Col17 = x.col17,
                    Col18 = x.col18,
                    Col19 = x.col19,
                    Col20 = x.col20,
                    Col21 = x.col21,
                    Col22 = x.col22,
                    Col23 = x.col23,
                    Col24 = x.col24,
                    Col25 = x.col25,
                    Col26 = x.col26,
                    Col27 = x.col27,
                    Col28 = x.col28,
                    Col29 = x.col29,
                    Col30 = x.col30,
                });
            }

            return View(pagedList);
        }
    }
}