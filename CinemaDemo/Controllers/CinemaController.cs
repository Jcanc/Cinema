using Microsoft.AspNetCore.Mvc;
using CinemaDemo.Models;
using SqlSugar;
using CinemaDemo.ViewModels;
using System.Collections.Generic;

namespace CinemaDemo.Controllers
{
    public class CinemaController : Controller
    {
        private readonly SqlSugarClient _sqlSugarDb;

        public CinemaController(SqlSugarClient sqlSugarDb)
        {
            _sqlSugarDb = sqlSugarDb;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var lamadaData = _sqlSugarDb.Queryable<Cinema>().ToList() as IEnumerable<Cinema>;
            var data = new List<ViewCinemaList>();
            int no = 1;
            if (lamadaData != null)
            {
                foreach (var item in lamadaData)
                {
                    data.Add(new ViewCinemaList
                    {
                        Id = item.Id,
                        No = no,
                        Name = item.Name,
                        Address = item.Address,
                        Grade = item.Grade
                    });
                    no++;
                }
            }
            return View(data);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ViewCinemaAdd addModel)
        {
            var model = new Cinema
            {
                Name = addModel.Name,
                Address = addModel.Address,
                Grade = addModel.Grade
            };
            _sqlSugarDb.Insertable<Cinema>(model).IgnoreColumns(c => c.Id).ExecuteCommand();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int cinemaId)
        {
            var data = _sqlSugarDb.Queryable<Cinema>().First(c => c.Id == cinemaId);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(ViewCinemaEdit editModel)
        {
            var model = new Cinema
            {
                Name = editModel.Name,
                Address = editModel.Address,
                Grade = editModel.Grade
            };
            _sqlSugarDb.Updateable<Cinema>(model).Where(c => c.Id == editModel.Id).ExecuteCommand();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int cinemaId)
        {
            _sqlSugarDb.Deleteable<Cinema>().Where(c => c.Id == cinemaId).ExecuteCommand();
            return RedirectToAction("Index");
        }
    }
}
