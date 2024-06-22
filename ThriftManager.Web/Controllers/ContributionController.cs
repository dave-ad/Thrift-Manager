using Azure;
using Microsoft.EntityFrameworkCore;
using ThriftManager.Domain.ValueObjects;

namespace ThriftManager.Web.Controllers;

public class ContributionController : Controller
{
    private readonly ILogger<ContributionController> _logger;
    private readonly IContributionService _contributionService;

    public ContributionController(ILogger<ContributionController> logger, IContributionService contributionService)
    {
        _contributionService = contributionService;
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateContribution(CreateContributionRequest request)
    {
        if (!ModelState.IsValid)
        {
            return View(nameof(CreateContribution), request);
        }

        try
        {
            ServiceResponse<ContributionResponse> resp = await _contributionService.CreateContribution(request);

            if (!resp.IsSuccessful)
            {
                _logger.LogError("Failed to create contribution: {Message}", resp.TechMessage);
                ModelState.AddModelError("", resp.Error);
                return View(nameof(CreateContribution), request);
            }

            TempData["SuccessMessage"] = "Successfully created the contribution!";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An exception occurred while creating new contribution group.");
            ModelState.AddModelError("", "An error occurred while creating new contribution group. Please try again.");
            return View(nameof(CreateContribution), request);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddContributingMember(AddContributingMemberRequest request)
    {
        var resp = await _contributionService.AddContributingMember(request);

        if (resp.IsSuccessful)
        {
            TempData["SuccessMessage"] = "Successfully joined the contribution group.";
            return RedirectToAction("Index");
        }
        else if (resp.Error == "Contribution slots filled up")
        {
            TempData["InfoMessage"] = "Current Contribution is ongoing. Creating a new contribution for you...";

            var newContributionResponse = await _contributionService.CreateContribution(new CreateContributionRequest
            {
                Title = "New Contribution",
                GroupId = request.GroupId
            });

            if (newContributionResponse.IsSuccessful)
            {
                var addMemberResponse = await _contributionService.AddContributingMember(new AddContributingMemberRequest
                {
                    ContributionId = newContributionResponse.Value.ContributionId,
                    MemberId = request.MemberId
                });

                if (addMemberResponse.IsSuccessful)
                {
                    TempData["SuccessMessage"] = "Successfully joined the new contribution group.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Error adding member to the new contribution");
                }
            }
            else
            {
                ModelState.AddModelError("", "Error creating a new contribution");
            }

            return RedirectToAction("Index");
        }
        else
        {
            ModelState.AddModelError("", resp.Error);
            return View("Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> InitWallet(InitWalletRequest request)
    {
        var resp = await _contributionService.InitWallet(request);

        if (resp.IsSuccessful)
        {
            TempData["SuccessMessage"] = "Contribution wallet initialized successfully.";
        }
        else
        {
            ModelState.AddModelError("", resp.Error);
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> MakeContribution(MakeContributionRequest request)
    {
        var resp = await _contributionService.MakeContribution(request);

        if (resp.IsSuccessful)
        {
            TempData["SuccessMessage"] = "Contribution made successfully.";
        }
        else
        {
            ModelState.AddModelError("", resp.Error);
        }

        return RedirectToAction("Index");
    }
}
