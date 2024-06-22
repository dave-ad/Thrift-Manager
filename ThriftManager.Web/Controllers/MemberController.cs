namespace ThriftManager.Web.Controllers;

public class MemberController : Controller
{
    private readonly ILogger<MemberController> _logger;
    private readonly IMemberService _memberService;
    public MemberController(ILogger<MemberController> logger, IMemberService memberService)
    {
        _memberService = memberService;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        ViewData["Message"] = "Member Added Successfully 👍";
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> AddMember()
    {
        ViewBag.MemberCreatedMessage = "Group Joined Successfully 👍";
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddMember(CreateMemberRequest newMember)
    {
        if (!ModelState.IsValid)
        {
            return View(nameof(AddMember), newMember);
        }

        try
        {
            ServiceResponse<MemberIdResponse> resp = await _memberService.CreateMember(newMember);

            if (resp.IsSuccessful)
            {
                TempData["SuccessMessage"] = "Member added successfully.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogError("Failed to create member: {Message}", resp.TechMessage);
                ModelState.AddModelError("", "Failed to create member");
                return View(nameof(AddMember), newMember);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An exception occurred while creating the member.");
            ModelState.AddModelError("", "An error occurred while creating the member. Please try again.");
            return View(nameof(AddMember), newMember);
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

