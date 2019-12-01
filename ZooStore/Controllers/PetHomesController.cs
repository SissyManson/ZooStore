using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooStore.ActionFilters;
using ZooStore.Entities;
using ZooStore.Models;
using ZooStore.ViewModels.PetHomes;

namespace ZooStore.Controllers
{
    [AuthFilter]
    public class PetHomesController : Controller
    {
        public ActionResult Index(IndexVM model)
        {
            model.Page = model.Page <= 0 ? 1 : model.Page;
            model.ItemsPerPage = model.ItemsPerPage <= 0 ? 10 : model.ItemsPerPage;

            ZooContext context = new ZooContext();

            model.Items = context.PetHomes.OrderBy(i => i.Id)
                                          .Skip((model.Page - 1) * model.ItemsPerPage)
                                          .Take(model.ItemsPerPage)
                                          .ToList();

            model.PagesCount = (int)Math.Ceiling(context.PetHomes.Count() / (double)model.ItemsPerPage);

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            ZooContext context = new ZooContext();

            PetHome item = Id == null ?
                            new PetHome() :
                            context.PetHomes.Where(u => u.Id == Id.Value)
                                         .FirstOrDefault();

            if (item == null)
                return RedirectToAction("Index", "PetHomes");

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.Type = item.Type;
            model.Size = item.Size;
            model.Material = item.Material;
            model.Price = item.Price;

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            ZooContext context = new ZooContext();

            PetHome item = context.PetHomes.Where(u => u.Id == Id)
                                        .FirstOrDefault();

            context.PetHomes.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index", "PetHomes");
        }
    }
}