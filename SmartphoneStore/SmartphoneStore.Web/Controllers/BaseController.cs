namespace SmartphoneStore.Web.Controllers
{
    using SmartphoneStore.Data.UnitOfWork;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        protected ISmartphoneStoreData Data;

        public BaseController(ISmartphoneStoreData data)
        {
            this.Data = data;
        }

        public BaseController()
            :this(new SmartphoneStoreData())
        {
        }
    }
}