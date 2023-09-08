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
        public ClientController(ILogger<ClientController> _pLogger, IClientService _pIClientService, IMapper _pMapper)
        {
            _vMapper = _pMapper;
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
            var vClients = _vIClientService.GetAllActive(Situations.Active);
            if (vClients is not null && vClients.Any())
            {
                IEnumerable<ClientViewModel> vCourtyards = _vMapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(vClients);
                return PartialView("_List", vCourtyards);
            }
            else
                return PartialView("_List", new List<ClientViewModel>());

        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ClientViewModel Obj)
        {
            if (!ModelState.IsValid)
            {
                var vClientViewModel = _vMapper.Map<Client>(Obj);
                var vObjClient = await _vIClientService.Add(vClientViewModel);

                return RedirectToAction("Edit", new { Id = vObjClient.Id });
            }
            return View(Obj);
        }

        public async Task<IActionResult> Edit(long Id)
        {
            var vClient = await _vIClientService.GetById(Id);

            if (vClient == null)
                return RedirectToAction("Index");

            var vClientViewModel = _vMapper.Map<Client, ClientViewModel>(vClient);
            return View(vClientViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] ClientViewModel Obj)
        {
            if (ModelState.IsValid)
            {
                Obj.ChangeDate = DateTime.Now;

                Client vClient = await _vIClientService.GetById(Obj.Id);
                if (vClient != null && vClient.Id > 0)
                {
                    var vCourtyard = _vMapper.Map(Obj, vClient);

                    await _vIClientService.Update(vCourtyard);

                    return RedirectToAction("Index");
                }
            }
            return View(Obj);

        }
    }
}
