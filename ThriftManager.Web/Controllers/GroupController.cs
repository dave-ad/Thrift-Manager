namespace ThriftManager.Web.Controllers
{
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
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateGroup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(CreateGroupRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceResponse = await _groupService.CreateGroup(request);

            if (serviceResponse.IsSuccessful)
            {
                return Ok(serviceResponse.Value);
            }
            else
            {
                return StatusCode(500, serviceResponse.Error);
            }
            //var newGroup = new CreateGroupRequest
            //{
            //    Name = "Group One",
            //    Title = "The Group One",
            //    Amount = 100,
            //    Slots = 10,
            //    Period = Period.Monthly,
            //    Tenure = 10,
            //    DueDay = 3,
            //};

            //ServiceResponse<GroupIdResponse> resp = await _groupService.CreateGroup(newGroup);

            //return View(resp);
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
}
