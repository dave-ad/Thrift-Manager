namespace ThriftManager.Web.Controllers;

public class GroupController : Controller
{
    private readonly ILogger<GroupController> _logger;
    private readonly IGroupService _groupService;

    public GroupController(ILogger<GroupController> logger, IGroupService groupService)
    {
        _groupService = groupService;
        _logger = logger;
    }

    // GET: GroupController
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        //ViewData["Message"] = "Group Created Successfully 👍";
        var resp = await _groupService.GetAvailableGroups();
        if (!resp.IsSuccessful)
        {
            var errorViewModel = new ErrorViewModel
            {
                Message = resp.Error,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View("Error", errorViewModel);
        }

        var viewModel = new GroupListViewModel
        {
            Groups = resp.Items
        };

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult CreateGroup()
    {
        ViewBag.GroupCreatedMessage = "Group Joined Successfully 👍";
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateGroup(CreateGroupRequest newGroup)
    {
        if (!ModelState.IsValid)
        {
            return View(nameof(CreateGroup), newGroup);
        }

        //// Assuming createdBy is retrieved from the current logged-in user
        //string createdBy = User.Identity.Name; // Replace this with the actual logic to get the logged-in user's name
        //newGroup.CreatedBy = createdBy;

        try
        {
            ServiceResponse<GroupIdResponse> resp = await _groupService.CreateGroup(newGroup);

            if (resp.IsSuccessful)
            {
                TempData["SuccessMessage"] = "Group created successfully.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogError("Failed to create group: {Message}", resp.TechMessage);
                ModelState.AddModelError("", "Failed to create group");
                return View(nameof(CreateGroup), newGroup);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An exception occurred while creating new group.");
            ModelState.AddModelError("", "An error occurred while creating new group. Please try again.");
            return View(nameof(CreateGroup), newGroup);
        }
    }

    //[HttpPost]
    //public async Task<IActionResult> JoinGroup(JoinGroupRequest request)
    //{
    //    var resp = await _groupService.JoinGroup(request);
    //    if (!resp.IsSuccessful)
    //    {
    //        ModelState.AddModelError("", resp.Error);
    //        var viewModel = new GroupListViewModel
    //        {
    //            Groups = (await _groupService.GetAvailableGroups()).Items,
    //            JoinGroupRequest = request
    //        };
    //        return View("Index", viewModel);

    //    }

    //    TempData["SuccessMessage"] = "Successfully joined the group!";
    //    return RedirectToAction("Index");
    //}

    [HttpGet]
    public async Task<IActionResult> GetAvailableGroups()
    {
        var resp = await _groupService.GetAvailableGroups();

        if (!resp.IsSuccessful)
        {
            return BadRequest(resp.Error);
        }

        return Ok(resp.Items);
    }

    [HttpGet("Error")]
    public IActionResult Error(string message)
    {
        var errorViewModel = new ErrorViewModel
        {
            Message = message,
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        };
        return View(errorViewModel);
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
