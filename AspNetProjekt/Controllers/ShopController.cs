using AspNetProjekt.Models;
using AspNetProjekt.Services;
using AspNetProjekt.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web;

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
        private readonly IMyAppSettings _myAppSettings;
        public ShopController(IItemService itemService, ICategoryService categoryService,
            IShoppingCartService shoppingCartService, IWebHostEnvironment hostEnvironment,
            UserManager<MyUser> userManager, SignInManager<MyUser> signInManager, IMyAppSettings MyAppSettings)
        {
            _itemService = itemService;
            _categoryService = categoryService;
            _shoppingCartService = shoppingCartService;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
            _signInManager = signInManager;
            _myAppSettings = MyAppSettings;
        }


        public IActionResult Index([FromQuery] string[]? category)
        {
            if(category is not null && category.Length != 0)
            {
                HashSet<string> categories = new HashSet<string>();
                var allCategories = _categoryService.FindAll().Select(e => e.CategoryName).ToList();
                foreach (var item in category)
                    if (allCategories.Contains(item))
                        _myAppSettings.filteringCategories.Add(item);
            }

            HashSet<Item> items = _itemService.FindAll().Where(e => e.ItemAvalibility > 0).ToHashSet();
            HashSet<Item> FileredItems = new HashSet<Item>();
            if (_myAppSettings.filteringCategories is null || _myAppSettings.filteringCategories.Count == 0)
                return View("Index", items);

            foreach (var item in items)
                foreach (var filteringCategory in _myAppSettings.filteringCategories)
                    foreach (var cat in item.Categories)
                        if (cat.CategoryName == filteringCategory)
                            FileredItems.Add(item);

            return View("Index", FileredItems);

        }
        [Authorize(Roles = "Admin")]
        #region createItem
        public IActionResult CreateItem(ItemDto? itemDto)
        {
            if (itemDto is null)
                itemDto = new ItemDto();

            var categories = _categoryService.FindAll().ToList();
            itemDto.categoriesList = new List<SelectListItem>();

            foreach (var category in categories)
                itemDto.categoriesList.Add(new SelectListItem(category.CategoryName, category.CategoryId.ToString()));


            return View("CreateItem", itemDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        #endregion
        #region editItem
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditItem(Guid? id)
        {
            if (id is null)
                return RedirectToAction("Index");

            Item? item = _itemService.FindBy(id);
            if (item is null)
                return NotFound();

            ItemDto itemDto = new ItemDto(item);
            return CreateItem(itemDto);
        }
        [Authorize(Roles = "Admin")]
        private IActionResult EditItem(ItemDto itemDto)
        {
            Item item = itemDto.ConvertTo();
            if (itemDto.ImageFile is not null)
            {
                DeleteImage(itemDto);
                item.ItemImageName = SaveImage(itemDto);
            }
            item.ItemId = Guid.Parse(itemDto.ItemId);
            _itemService.Update(item);
            return RedirectToAction("Index");
        }
        #endregion
        #region createCategory
        [Authorize(Roles = "Admin")]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateCategory([FromForm] CategoryDto? categoryDto)
        {
            if (categoryDto is null)
                return View();

            if (!ModelState.IsValid)
                return View(categoryDto);

            Category category = categoryDto.ConvertTo();
            var response = _categoryService.Save(category);
            return RedirectToAction("Index");
        }
        #endregion
        [HttpPost]
        public void LikeItem([FromBody] string id)
        {
            if (id == null)
                return;
            Guid itemId = Guid.Parse(id);
            Guid userId = Guid.Parse(_userManager.GetUserId(User));
            _itemService.Like(itemId, userId);
        }
        [HttpPost]
        public void WishItem([FromBody] string id)
        {
            if (id == null)
                return;
            Guid itemId = Guid.Parse(id);
            Guid userId = Guid.Parse(_userManager.GetUserId(User));
            _itemService.Wish(itemId, userId);
        }
        [HttpPost]
        public IActionResult AddFilterCategory([FromBody] string categoryName)
        {
            List<Category> categories = _categoryService.FindAll().ToList();
            if (!categories.Any(e => e.CategoryName == categoryName))
                return Index(_myAppSettings.filteringCategories.ToArray());
            if (_myAppSettings.filteringCategories is null)
                _myAppSettings.filteringCategories = new HashSet<string>();

            if (!_myAppSettings.filteringCategories.Add(categoryName))
                _myAppSettings.filteringCategories.Remove(categoryName);

            return RedirectToAction("Index", _myAppSettings.filteringCategories.ToArray());

        }

        [Authorize(Roles = "Admin")]
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
        private void DeleteImage(ItemDto itemDto)
        {
            Item item = _itemService.FindBy(Guid.Parse(itemDto.ItemId));
            if (item.ItemImageName is null)
                return;
            try
            {
                string wwwrootPath = _hostEnvironment.WebRootPath;
                string path = Path.Combine(wwwrootPath + "/image", item.ItemImageName);
                System.IO.File.Delete(path);
            }
            catch
            {

                return;
            }

        }

        [HttpPost]
        public JsonResult AjaxMethod([FromBody] string test)
        {
            return Json(test);
        }

    }
}
