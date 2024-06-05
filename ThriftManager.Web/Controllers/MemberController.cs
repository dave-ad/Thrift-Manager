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
    public IActionResult AddMember()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //public async Task<IActionResult> AddMember()
    public async Task<IActionResult> AddMember(CreateMemberRequest newMember)
{

        if (!ModelState.IsValid)
        {
            return View(newMember);
        }

        ServiceResponse<MemberIdResponse> resp = await _memberService.CreateMember(newMember);

        if (resp.IsSuccessful)
        {
            return RedirectToAction(nameof(Index));
        }
        else
        {
            ModelState.AddModelError("", "Failed to create member");
            return View(newMember);
        }

        //var account = new MemberBankAccount
        //{
        //    AccountName = "Jack Doe",
        //    AccountNumber = "1834267801",
        //    BankId = 3,
        //    BVN = "55363214398"
        //};
        //var newMember = new CreateMemberRequest
        //{
        //    FirstName = "Jane",
        //    LastName = "Doe",
        //    OtherNames = "Jack",
        //    Email = "janedoe@email.com",
        //    DateOfBirth = new DateOnly(2000, 12, 05),
        //    Gender = Gender.Female,
        //    MobileNumber = "08012345836",
        //    NIN = "9233938251",
        //    Account = account
        //};

        //ServiceResponse<MemberIdResponse> resp = await _memberService.CreateMember(newMember);

        //return View(resp);
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

