using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Servies;
using test.ViewModel;

namespace test.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemServices ItemServices;

        public ItemController(ItemServices ItemServices)
        {
            this.ItemServices = ItemServices;
        }
        #region MAIN
        public IActionResult addItem()
        {
            //Add list of Main
            return View();
        }
        public IActionResult addItem1(ItemVm mv)
        {
            
            ItemServices.addmain(mv);
            return RedirectToAction("GETALL");
        }
        public IActionResult GETALL()
        {
            var data = ItemServices.Getitem();
            return View(data);
        }
        public IActionResult Delete(int id)
        {
            var data = ItemServices.Getitembyid(id);
            return View(data);

        }
        public IActionResult Delete1(int id)
        {
            var data = ItemServices.delete(id);
            return RedirectToAction("GETALL");
        }
        public IActionResult Details(int id)
        {
            var data = ItemServices.Getitembyid(id);
            ItemVm item = new ItemVm()
            {
                Id = data.Id,
                Name = data.Name,
                price = data.price,
                idmain = data.mainitemId,
                quanity = data.quanity
            };
            
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(ItemVm ids)
        {
            var data = ItemServices.editeitem(ids);
            return RedirectToAction("GETALL");
        }
        #endregion
    }
}
