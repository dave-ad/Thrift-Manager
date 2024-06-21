using System;

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
    public async Task<IActionResult> Index()
    {
        ViewData["Message"] = "Group Created Successfully 👍";
        return View();
    }

    [HttpGet]
    public IActionResult CreateGroup()
    {
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

    //public async Task<IActionResult> ViewAllGroups()
    //{
    //    var resp = await _groupService.ViewAllGroups();

    //    if (!resp.IsSuccessful)
    //    {
    //        return NotFound(resp.Error);
    //    }

    //    return Ok(resp.Value);

    //}

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
