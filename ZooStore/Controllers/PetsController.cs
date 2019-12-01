using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooStore.ActionFilters;
using ZooStore.Entities;
using ZooStore.Models;
using ZooStore.ViewModels.Pets;

namespace ZooStore.Controllers
{
    [AuthFilter]
    public class PetsController : Controller
    {
        public ActionResult Index(IndexVM model)
        {
            model.Page = model.Page <= 0 ? 1 : model.Page;
            model.ItemsPerPage = model.ItemsPerPage <= 0 ? 10 : model.ItemsPerPage;

            ZooContext context = new ZooContext();

            model.Items = context.Pets.OrderBy(i => i.Id)
                                          .Skip((model.Page - 1) * model.ItemsPerPage)
                                          .Take(model.ItemsPerPage)
                                          .ToList();

            model.PagesCount = (int)Math.Ceiling(context.Pets.Count() / (double)model.ItemsPerPage);

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            ZooContext context = new ZooContext();

            Pet item = Id == null ?
                            new Pet() :
                            context.Pets.Where(u => u.Id == Id.Value)
                                         .FirstOrDefault();

            if (item == null)
                return RedirectToAction("Index", "Pets");

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.Type = item.Type;
            model.FurType = item.FurType;
            model.Age = item.Age;
            model.LifeSpan = item.LifeSpan;
            model.HereFrom = item.HereFrom;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            ZooContext context = new ZooContext();

            Pet item = new Pet();
            item.Id = model.Id;
            item.Type = model.Type;
            item.FurType = model.FurType;
            item.Age = model.Age;
            item.LifeSpan = model.LifeSpan;
            item.HereFrom = model.HereFrom;

            if (item.Id <= 0)
            {
                context.Pets.Add(item);
            }
            else
            {
                context.Entry(item).State = EntityState.Modified;
            }

            context.SaveChanges();

            return RedirectToAction("Index", "Pets");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            ZooContext context = new ZooContext();

            Pet item = context.Pets.Where(u => u.Id == Id)
                                        .FirstOrDefault();

            context.Pets.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Pets");
        }
    }
}