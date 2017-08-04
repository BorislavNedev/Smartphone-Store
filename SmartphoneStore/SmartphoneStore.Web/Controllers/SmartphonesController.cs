using SmartphoneStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartphoneStore.Web.Controllers
{
    public class SmartphonesController : BaseController
    {
        public ActionResult Details(int id)
        {
            var viewModel = this.Data.Smartphones
                .All()
                .Where(x => x.Id == id)
                .Select(x => new SmartphoneDetailsViewModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    MonitorSize = x.MonitorSize,
                    RamMemorySize = x.RamMemorySize,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    Description = x.Description,
                    ManufacturerName = x.Manufacturer.Name,
                    Comments = x.Comments.Select(y => new CommentViewModel { AuthorUsername = y.Author.UserName, Content = y.Content })
                }).FirstOrDefault();

            return View(viewModel);
        }
    }
}