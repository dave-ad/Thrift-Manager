namespace ThriftManager.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMemberService _memberService;
    public HomeController(ILogger<HomeController> logger, IMemberService memberService)
    {
        _memberService = memberService;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    //public async Task<IActionResult> AddMember()
    //{
    //    var account = new MemberBankAccount
    //    {
    //        AccountName = "Jack Doe",
    //        AccountNumber = "1834267801",
    //        BankId = 3,
    //        BVN = "55363214398"
    //    };
    //    var newMember = new CreateMemberRequest
    //    {
    //        FirstName = "Jane",
    //        LastName = "Doe",
    //        OtherNames = "Jack",
    //        Email = "janedoe@email.com",
    //        DateOfBirth = new DateOnly(2000, 12, 05),
    //        Gender = Gender.Female,
    //        MobileNumber = "08012345836",
    //        NIN = "9233938251",
    //        Account = account
    //    };

    //    ServiceResponse<MemberIdResponse> resp = await _memberService.CreateMember(newMember);
    //    return View(resp);
    //}


    //public IActionResult Privacy()
    //{
    //    return View();
    //}

    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //public IActionResult Error()
    //{
    //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //}
}
