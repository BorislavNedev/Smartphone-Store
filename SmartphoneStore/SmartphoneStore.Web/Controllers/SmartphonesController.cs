using Microsoft.AspNet.Identity;
using SmartphoneStore.Models;
using SmartphoneStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SmartphoneStore.Web.Controllers
{
    public class SmartphonesController : BaseController
    {
        const int PageSize = 5;

        private IQueryable<SmartphoneViewModel> GetAllSmartphones()
        {
            var data=this.Data.Smartphones.All().Select(x => new SmartphoneViewModel
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Manufacturer = x.Manufacturer.Name,
                Model = x.Model,
                Price = x.Price
            }).OrderBy(x=>x.Id);

            return data;
        }

        public ActionResult List(int? id)
        {
            int pageNumber = id.GetValueOrDefault(1);

            var viewModel = GetAllSmartphones().Skip((pageNumber - 1) * PageSize).Take(PageSize);
            ViewBag.Pages = Math.Ceiling((double)GetAllSmartphones().Count() / PageSize);

            return View(viewModel);
        }

        public ActionResult PostComment(SubmitCommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();

                this.Data.Comments.Add(new Comment()
                {
                    AuthorId = userId,
                    Content = commentModel.Comment,
                    SmartphoneId = commentModel.SmartphoneId
                });

                this.Data.SaveChanges();

                var viewModel = new CommentViewModel { AuthorUsername = username, Content = commentModel.Comment };
                return PartialView("_CommentPartial", viewModel);
            }
            else
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
            }
        }

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