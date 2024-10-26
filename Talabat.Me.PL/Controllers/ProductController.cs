using Microsoft.AspNetCore.Mvc;
using Talabat.Me.BLL.Interfaces;
using Talabat.Me.DAL.Model;

namespace Talabat.Me.PL.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var product = await _unitOfWork.GenerateRepository<Product, int>().GetAllAsync();
            return View(product);
        }
    }
}
