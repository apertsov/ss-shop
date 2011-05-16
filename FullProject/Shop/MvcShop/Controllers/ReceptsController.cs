using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using MvcShop.ServiceShop;
using ShopModel.Entities;

namespace MvcShop.Controllers
{
    public class ReceptsController : Controller
    {
        private List<Recept> _receptRepository;
        private const int PageSize = 4;
        public ReceptsController()
        {
            var ss = new ServiceShopClient();
            _receptRepository = ss.LoadAllRecept().ToList();
        }

        public ViewResult List(int? category,int page)
        {
            var ss = new ServiceShopClient();
            _receptRepository = category==null ? ss.LoadAllRecept().ToList() : ss.LoadReceptByCategory((int) category).ToList();

            ViewData["CurrentCategory"] = category;
            if (page < 1) page = 1;
            var numRecept = _receptRepository.Count;
            ViewData["TotalPages"] = (int) Math.Ceiling((double)numRecept/PageSize);
            ViewData["CurrentPage"] = page;
            return View(_receptRepository.Skip((page - 1) * PageSize).Take(PageSize).ToList());
        }

        public ActionResult Recept(string id)
        {
            ServiceShopClient ssc = new ServiceShopClient();
            ViewData["recept"] = ssc.LoadRecept(int.Parse(id));
            ssc.Close();

            return View();
        }
    }
}
