using test.Models;
using test.ViewModel;

namespace test.Servies
{
    public class MainServices
    {
        public MainServices(applictioncontext _db)
        {
            Db = _db;
        }

        public applictioncontext Db { get; }

        public bool addmain(mainVm mn)
        {
           
            try
            {
                mainitem OBJ = new mainitem();
                OBJ.Nmae = mn.Name;
                Db.mainitem.Add(OBJ);
                Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                return false;

            } 
        }
        public IEnumerable<mainitem> GetMainitem() {
            var Data = Db.mainitem.ToList();
            return Data;
        } public mainitem GetMainitembyid(int id) {
            var Data = Db.mainitem.Find(id);
            return Data;
        }
        public bool editemain(mainVm mn)
        {

            try
            {
                var Data = Db.mainitem.FirstOrDefault(x => x.id== mn.id);
                Data.Nmae=mn.Name;
                Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }
        public bool delete(int id) {
            var Data = Db.mainitem.Find(id);
            Db.mainitem.Remove(Data);
            Db.SaveChanges();
            return true;
        }

    }
}
