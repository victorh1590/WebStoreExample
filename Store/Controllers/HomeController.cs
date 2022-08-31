using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Models.ViewModels;

namespace Store.Controllers
{
  public class HomeController : Controller
  {
    private IStoreRepository _repository;
    public int PageSize = 4;

    public HomeController(IStoreRepository repository)
    {
      _repository = repository;
    }

    // public IActionResult Index() => View(_repository.Products); // Send products from repository to view.

    //   public ViewResult Index(int productPage = 1) 
    //     => View(_repository.Products
    //     .OrderBy(p => p.ProductID)
    //     .Skip((productPage - 1) * PageSize)
    //     .Take(PageSize));
    // }

    public ViewResult Index(int productPage = 1) => View(new ProductsListViewModel
    {
      Products = _repository.Products
      .OrderBy(p => p.ProductID)
      .Skip((productPage - 1) * PageSize)
      .Take(PageSize),
      PagingInfo = new PagingInfo
      {
        CurrentPage = productPage,
        ItemsPerPage = PageSize,
        TotalItems = _repository.Products.Count()
      }
    });
  }
}