namespace MyApp.Controllers
{
  using Microsoft.AspNetCore.Mvc;

  [Route("api/[controller]")]
  public class MyController: Controller
  {
    [HttpGet]
    public int Add(int x, int y)
    {
      return x + y;
    }
  }
}
