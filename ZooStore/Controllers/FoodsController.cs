using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooStore.Entities;
using ZooStore.Models;
using ZooStore.ViewModels.Foods;

using ZooStore.ActionFilters;

namespace ZooStore.Controllers
{
    [AuthFilter]
    public class FoodsController : Controller
    {
        public ActionResult Index(IndexVM model)
        {
            model.Page = model.Page <= 0 ? 1 : model.Page;
            model.ItemsPerPage = model.ItemsPerPage <= 0 ? 10 : model.ItemsPerPage;

            ZooContext context = new ZooContext();

            model.Items = context.Foods.OrderBy(i => i.Id)
                                          .Skip((model.Page - 1) * model.ItemsPerPage)
                                          .Take(model.ItemsPerPage)
                                          .ToList();

            model.PagesCount = (int)Math.Ceiling(context.Foods.Count() / (double)model.ItemsPerPage);

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            ZooContext context = new ZooContext();

            Food item = Id == null ?
                            new Food() :
                            context.Foods.Where(u => u.Id == Id.Value)
                                         .FirstOrDefault();

            if (item == null)
                return RedirectToAction("Index", "Foods");

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.Type = item.Type;
            model.Quantity = item.Quantity;
            model.Price = item.Price;

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            ZooContext context = new ZooContext();

            Food item = context.Foods.Where(u => u.Id == Id)
                                        .FirstOrDefault();

            context.Foods.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Foods");
        }
    }
}