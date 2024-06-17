using Microsoft.AspNetCore.Mvc.Rendering;

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

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> AddMember()
    {
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
                ModelState.AddModelError("", "Failed to create member." + resp.Error);
                //return View(resp);
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

    //public async Task<IActionResult> AddMember()
    //{
    //var account = new MemberBankAccount
    //{
    //    AccountName = "James Joseph",
    //    AccountNumber = "1234567801",
    //    BankId = 1,
    //    BVN = "55563214598"
    //};
    //var newMember = new CreateMemberRequest
    //{
    //    Account = account,
    //    m
    //        DateOfBirth = new DateOnly(1990, 02, 02),
    //    Email = "somebody@yahoo.com",
    //    FirstName = "Somebody",
    //    Gender = Gender.Male,
    //    LastName = "Joseph",
    //    MobileNumber = "08056423145",
    //    NIN = "0213653241",
    //    OtherNames = "James"
    //};

    //    ServiceResponse<MemberIdResponse> resp = await _memberService.CreateMember(newMember);
    //    return View(resp);
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

