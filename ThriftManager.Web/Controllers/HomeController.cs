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

    public async Task<IActionResult> AddMember()
    {
        var account = new MemberBankAccount
        {
            AccountName = "James Joseph",
            AccountNumber = "1234567801",
            BankId = 1,
            BVN = "55563214598"
        };
        var newMember = new CreateMemberRequest
        {
            FirstName = "Somebody",
            LastName = "Joseph",
            OtherNames = "James",
            Email = "somebody@yahoo.com",
            DateOfBirth = new DateOnly(1990, 02, 02),
            Gender = Gender.Male,
            MobileNumber = "08056423145",
            NIN = "0213653241",
            Account = account
        };

        ServiceResponse<MemberIdResponse> resp = await _memberService.CreateMember(newMember);
        return View(resp);
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
