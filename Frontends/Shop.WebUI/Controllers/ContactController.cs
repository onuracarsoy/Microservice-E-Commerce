using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ServiceDistribute.Dtos.CatalogDtos.ContactDtos;
using Shop.ServiceDistribute.Services.CatalogServices.ContactServices;

using System.Text;

namespace Shop.WebUI.Controllers
{

    public class ContactController : Controller
    {
      private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            createContactDto.ContactSendDate = DateTime.Now;
            createContactDto.ContactIsRead = false;
            await _contactService.CreateContactAsync(createContactDto);
            return View();
        }
    }
}
