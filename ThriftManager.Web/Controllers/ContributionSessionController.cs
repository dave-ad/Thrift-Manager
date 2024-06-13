//using ThriftManager.Domain.Entities;
//using ThriftManager.Service.ContributionServices;

//namespace ThriftManager.Web.Controllers;

//public class ContributionSessionController : Controller
//{
//    private readonly ILogger<ContributionSessionController> _logger;
//    private readonly IContributionSessionService _contributionSessionService;
//    public ContributionSessionController(ILogger<ContributionSessionController> logger, IContributionSessionService contributionSessionService)
//    {
//        _contributionSessionService = contributionSessionService;
//        _logger = logger;
//    }

//    public IActionResult Index()
//    {
//        return View();
//    }

//    //[HttpPost]
//    //public async Task<IActionResult> CreateContributionSession(CreateContributionSessionRequest request)
//    //{
//    //    var resp = await _contributionSessionService.CreateContributionSession(request);
//    //    if (resp.IsSuccessful)
//    //    {
//    //        //return Ok(resp.IsSuccessful);
//    //        //return Ok();
//    //        return RedirectToAction("Index"); // Redirect to a suitable view
//    //    }
//    //    ModelState.AddModelError("", resp.Error);
//    //    return View("Error");
//    //    //return BadRequest(resp.Error);
//    //}

//    [HttpPost]
//    public async Task<IActionResult> AddMemberToContributionSession(long contributionSessionId, int memberId)
//    {
//        var resp = await _contributionSessionService.AddMemberToContributionSession(contributionSessionId, memberId);
//        if (resp.IsSuccessful)
//        {
//            //return Ok();
//            return RedirectToAction("Index"); // Redirect to a suitable view
//        }
//        ModelState.AddModelError("", resp.Error);
//        return View("Error");
//        //return BadRequest(resp.Error);
//    }

//    [HttpPost]
//    public async Task<IActionResult> MakeContribution(long contributionSessionId, int memberId, decimal amount)
//    {
//        var resp = await _contributionSessionService.MakeContribution(contributionSessionId, memberId, amount);
//        if (resp.IsSuccessful)
//        {
//            return RedirectToAction("Index"); // Redirect to a suitable view
//            //return Ok();
//        }
//        ModelState.AddModelError("", resp.Error);
//        return View("Error");
//        //return BadRequest(resp.Error);
//    }

//    public IActionResult Privacy()
//    {
//        return View();
//    }

//    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//    public IActionResult Error()
//    {
//        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//    }
//}

