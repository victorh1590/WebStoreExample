using Microsoft.AspNetCore.Mvc;
using Store.Models;

namespace Store.Components
{
  public class NavigationMenuViewComponent : ViewComponent
  {
    private IStoreRepository _repository;
    public NavigationMenuViewComponent(IStoreRepository repository)
    {
      _repository = repository;
    }
    public IViewComponentResult Invoke()
    {
      return View(_repository.Products
        .Select(x => x.Category)
        .Distinct()
        .OrderBy(x => x));
    }
  }
}