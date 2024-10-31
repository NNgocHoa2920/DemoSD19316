using BanHopDongSo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace BanHopDongSo1.Controllers
{
   
    public class CategoryController : Controller
    {
        //gọi class đại dieejn cho csdl sang đây để dùng
        protected CategoryDbContext _db;

        //tiêm DI , tiêm db vào trong controoler dể sử dụng
        public CategoryController(CategoryDbContext db)
        {
            _db = db;
        }

        //hiển thị ra list danh sách category
     
        public IActionResult Index()
        {
            var categoryList = _db.Categories.ToList();
            return View(categoryList);
        }

        //thêm 1 đối tượng category
        //tạo ra form create
        public IActionResult Create()
        {
            return View();
        }
        [ActionName("Create")]
        [HttpPost]
        public IActionResult CreateABC(Category cte)
        {
            _db.Categories.Add(cte);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //sửa
        //hiển thị ra form edit chứa dữ liệu cần edit
        public ActionResult Edit(int HE)
        {
            //lấy ra đối tượng cần sửa
            //x.Ma là dữ liệu ở db, id là dữ liệu truyền vào
            var categoryEdit = _db.Categories.FirstOrDefault(x => x.Ma == HE);
            return View(categoryEdit);
        }
        [HttpPost]
        public ActionResult Edit(Category cte)
        {
            _db.Categories.Update(cte);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int HE)
        {
            var categoryDetails = _db.Categories.FirstOrDefault(x => x.Ma == HE);
            return View(categoryDetails);
        }

        public IActionResult Delete(int HE) 
        {
            var categoryDelete = _db.Categories.FirstOrDefault(x => x.Ma == HE);
            _db.Categories.Remove(categoryDelete);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //DEMO ACTION METHOD
        //DATATYPE
        public IActionResult ABC() // TẠO RA VEW ABC
        {
            return View();
        }
        [HttpPost]
        public IActionResult ABC(int id, string name)// BẮT ĐẦU XỬ LÍ
        {
            //string welCome = $"Chào mừng {id} có tên {name} đến với chúng tôi";
            //return View((object)welCome);
            Category cate = new Category();
            cate.Ma = id;
            cate.Name = name;
            cate.Description = " hí con gà";
            return View(cate);  

        }

    }
}
