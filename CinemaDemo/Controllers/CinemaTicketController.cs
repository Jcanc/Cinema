using Microsoft.AspNetCore.Mvc;
using CinemaDemo.Models;
using SqlSugar;
using CinemaDemo.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CinemaDemo.Controllers
{
    public class CinemaTicketController : Controller
    {
        private readonly SqlSugarClient _sqlSugarDb;

        public CinemaTicketController(SqlSugarClient sqlSugarDb)
        {
            _sqlSugarDb = sqlSugarDb;
        }

        [HttpGet]
        public IActionResult Index(int cinemaId)
        {
            var lamadaData = _sqlSugarDb.Queryable<CinemaTicket>().Where(c => c.CinemaId == cinemaId).ToList() as IEnumerable<CinemaTicket>;
            var data = new List<ViewCinemaTicketList>();
            int no = 1;
            if (lamadaData != null)
            {
                foreach (var item in lamadaData)
                {
                    data.Add(new ViewCinemaTicketList
                    {
                        Id = item.Id,
                        No = no,
                        Name = item.Name,
                        Star = item.Star,
                        ReleaseTime = item.ReleaseTime.ToShortDateString()
                    });
                    no++;
                }
            }
            ViewBag.cinemaId = cinemaId;
            var cinemaName = _sqlSugarDb.Queryable<Cinema>().First(c => c.Id == cinemaId).Name;
            ViewBag.Title = $"{cinemaName}的影片列表：";
            return View(data);
        }

        public IActionResult Add(int cinemaId)
        {
            var cinemaName = _sqlSugarDb.Queryable<Cinema>().First(c => c.Id == cinemaId).Name;
            ViewBag.cinemaId = cinemaId;
            ViewBag.Title = $"添加{cinemaName}的影片";
            return View();
        }

        [HttpPost]
        public IActionResult Add(ViewCinemaTicketAdd addModel)
        {
            if (ModelState.IsValid)
            {
                var model = new CinemaTicket
                {
                    CinemaId = addModel.CinemaId,
                    Name = addModel.Name,
                    Star = addModel.Star,
                    ReleaseTime = addModel.ReleaseTime
                };
                _sqlSugarDb.Insertable<CinemaTicket>(model).IgnoreColumns(c => c.Id).ExecuteCommand();
            }
            return RedirectToAction("Index", new { cinemaId = addModel.CinemaId });
        }

        public IActionResult Edit(int cinemaId, int cinemaTicketId)
        {
            var data = _sqlSugarDb.Queryable<CinemaTicket, Cinema>((ct, c) => new object[]
            {
                JoinType.Left, ct.CinemaId == c.Id
            }).Where((ct, c) => ct.Id == cinemaTicketId).Select<ViewCinemaTicketEdit>().ToList().FirstOrDefault();
            ViewBag.cinemaId = cinemaId;
            ViewBag.cinemaTicketId = cinemaTicketId;
            ViewBag.Title = $"编辑{data.CinemaName}的影片";
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(ViewCinemaTicketEdit editModel)
        {
            if (ModelState.IsValid)
            {
                var model = new CinemaTicket
                {
                    CinemaId = editModel.CinemaId,
                    Name = editModel.Name,
                    Star = editModel.Star,
                    ReleaseTime = editModel.ReleaseTime
                };
                _sqlSugarDb.Updateable<CinemaTicket>(model).Where(c => c.Id == editModel.Id).ExecuteCommand();
            }

            return RedirectToAction("Index", new { cinemaId = editModel.CinemaId });
        }

        public IActionResult Delete(int cinemaId, int cinemaTicketId)
        {
            _sqlSugarDb.Deleteable<CinemaTicket>().Where(c => c.Id == cinemaTicketId).ExecuteCommand();
            return RedirectToAction("Index", new { cinemaId });
        }
    }
}
