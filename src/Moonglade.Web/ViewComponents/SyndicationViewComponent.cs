namespace Moonglade.Web.ViewComponents;

public class SyndicationViewComponent(ILogger<SyndicationViewComponent> logger) : ViewComponent
{
  public async Task<IViewComponentResult> InvokeAsync()
  {
    try
    {
      return View();
    }
    catch (Exception e)
    {
      logger.LogError(e, "Error Reading FriendLink.");
      return Content("ERROR");
    }
  }
}
