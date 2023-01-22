using AspNetProjekt.Models;
using AspNetProjekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetProjekt.Controllers
{
    public class ShopController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<MyUser> _userManager;
        private readonly SignInManager<MyUser> _signInManager;

        public ShopController(IItemService itemService, ICategoryService categoryService,
            IShoppingCartService shoppingCartService, IWebHostEnvironment hostEnvironment,
            UserManager<MyUser> userManager, SignInManager<MyUser> signInManager)
        {
            _itemService = itemService;
            _categoryService = categoryService;
            _shoppingCartService = shoppingCartService;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View("Index", _itemService.FindAll());
        }

        public IActionResult CreateItem(ItemDto? itemDto)
        {
            if (itemDto is null)
                itemDto = new ItemDto();

            var categories = _categoryService.FindAll().ToList();
            itemDto.categoriesList = new List<SelectListItem>();
            foreach (var category in categories)
            {
                itemDto.categoriesList.Add(new SelectListItem(category.CategoryName, category.CategoryId.ToString()));
            }

            return View("CreateItem", itemDto);
        }

        [HttpPost]
        public IActionResult CreateItemForm([FromForm] ItemDto? itemDto)
        {
            if (itemDto is null)
                return CreateItem(itemDto);

            if (!ModelState.IsValid)
                return CreateItem(itemDto);
            if (itemDto.ItemId != null)
                return EditItem(itemDto);
            Item item = itemDto.ConvertTo();

            if (itemDto.ImageFile is not null)
                item.ItemImageName = SaveImage(itemDto);

            var response = _itemService.Save(item);

            return RedirectToAction("Index");
        }
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory([FromForm] CategoryDto? categoryDto)
        {
            if (categoryDto is null)
                return View();

            if (!ModelState.IsValid)
                return View(categoryDto);

            Category category = categoryDto.ConvertTo();
            var response = _categoryService.Save(category);
            return Index();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditItem(Guid? id)
        {
            if (id is null)
                return Index();
            Item? item = _itemService.FindBy(id);
            if (item is null)
                return NotFound();
            ItemDto itemDto = new ItemDto(item);
            return CreateItem(itemDto);
        }
        private IActionResult EditItem(ItemDto itemDto)
        {
            Item item = itemDto.ConvertTo();
            if (itemDto.ImageFile is not null)
                item.ItemImageName = SaveImage(itemDto);
            item.ItemId = Guid.Parse(itemDto.ItemId);
            _itemService.Update(item);
            return Index();
        }

        private string SaveImage(ItemDto itemDto)
        {
            string wwwrootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(itemDto.ImageFile.FileName);
            string extension = Path.GetExtension(itemDto.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

            string path = Path.Combine(wwwrootPath + "/image", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                itemDto.ImageFile.CopyTo(fileStream);
            }
            return fileName;
        }


        [HttpPost]
        public JsonResult AjaxMethod([FromBody] string test)
        {
            return Json(test);
        }

    }
}
