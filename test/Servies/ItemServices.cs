using test.Models;
using test.ViewModel;

namespace test.Servies
{
    public class ItemServices
    {
        public ItemServices(applictioncontext _db)
        {
            Db = _db;
        }

        public applictioncontext Db { get; }

        public bool addmain(ItemVm mn)
        {
           
            try
            {
                Item OBJ = new Item();
                OBJ.Name = mn.Name;
                OBJ.mainitemId = mn.idmain;
                OBJ.price = mn.price;
                OBJ.quanity= mn.quanity;
                Db.Item.Add(OBJ);
                Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                return false;

            } 
        }
        public IEnumerable<Item> Getitem() {
            var Data = Db.Item.ToList();
            return Data;
        } public Item Getitembyid(int id) {
            var Data = Db.Item.Find(id);
            return Data;
        }
        public bool editeitem(ItemVm mn)
        {

            try
            {
                var OBJ = Db.Item.FirstOrDefault(x => x.Id== mn.Id);
                OBJ.Name = mn.Name;
                OBJ.mainitemId = mn.idmain;
                OBJ.price = mn.price;
                OBJ.quanity = mn.quanity;
                Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }
        public bool delete(int id) {
            var Data = Db.Item.Find(id);
            Db.Item.Remove(Data);
            Db.SaveChanges();
            return true;
        }

    }
}
