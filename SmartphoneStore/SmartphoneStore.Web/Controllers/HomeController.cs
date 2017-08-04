namespace SmartphoneStore.Web.Controllers
{
    using Models;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var listOfSmartphones = this.Data.Smartphones
                .All()
                .OrderByDescending(x => x.Votes.Count())
                .Take(6)
                .Select(x => new SmartphoneViewModel
                {
                    Id = x.Id,
                    Manufacturer = x.Manufacturer.Name,
                    Model = x.Model,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price
                });

            return View(listOfSmartphones);
        }
        
    }
}