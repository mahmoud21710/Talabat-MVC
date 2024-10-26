using Microsoft.AspNetCore.Mvc;
using Talabat.Me.BLL.Interfaces;
using Talabat.Me.DAL.Model;

namespace Talabat.Me.PL.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RestaurantController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var resturant =await _unitOfWork.GenerateRepository<Restaurants, int>().GetAllAsync();
            return View(resturant);
        }
    }
}
