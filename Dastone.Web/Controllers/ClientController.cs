using AutoMapper;
using Dastone.Domain.Entity;
using Dastone.Domain.Enum;
using Dastone.Domain.Interfaces.Service;
using Dastone.ViewModel.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Dastone.Controllers
{
    public class ClientController : Controller
    {
        IMapper _vMapper;
        private readonly ILogger<ClientController> _vLogger;
        private readonly IClientService _vIClientService;
        public ClientController(ILogger<ClientController> _pLogger, IClientService _pIClientService)
        {
            _vLogger = _pLogger;
            _vIClientService = _pIClientService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult _List()
        {
            IEnumerable<ClientViewModel> vCourtyards = _vMapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(_vIClientService.GetAllActive(Situations.Active));
            return PartialView("_List", vCourtyards);
        }

    }
}
