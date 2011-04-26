using System;
using System.Web.Mvc;
using ShopModel.Abstract;
using ShopModel.Concrete;
using ShopModel.Entities;

namespace MvcShop.Controllers
{
    public class ReceptsController : Controller
    {
        private readonly IReceptRepository _receptRepository;
        private const int PageSize = 2;
        public ReceptsController()
        {
            _receptRepository = new FakeReceptRepository();
        }

        public ViewResult List(int category,int page)
        {
            if (category==null)
            {
                //need load all recepts
            }
            else
            {
                // need load repepts in category
            }

            ViewData["CurrentCategory"] = category;
            if (page < 1) page = 1;
            var numRecept = _receptRepository.Recepts.Count;
            ViewData["TotalPages"] = (int) Math.Ceiling((double)numRecept/PageSize);
            var count = page * PageSize < numRecept ? PageSize : page * PageSize - numRecept;
            if (count > PageSize)
            {
                page = 1;
                count = page * PageSize < numRecept ? PageSize : page * PageSize - numRecept;
            }
            ViewData["CurrentPage"] = page;
            return View(_receptRepository.Recepts.GetRange((page-1)*PageSize,count));
        }

    }
}
