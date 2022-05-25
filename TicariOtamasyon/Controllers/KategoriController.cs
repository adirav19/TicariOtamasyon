using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtamasyon.Models.Siniflar;

namespace TicariOtamasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEKle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult KategoriEKle(Kategori k)
        {

            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var kate = c.Kategoris.Find(id);
            c.Kategoris.Remove(kate);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir", kategori);

        }
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var ktgrupdt = c.Kategoris.Find(k.KategoriID);//sayfaya ıd ile taşıdığımz değerin
            ktgrupdt.KategoriAd = k.KategoriAd;//aynı id ye bağlı olan kısmının adını 
            c.SaveChanges();//değiştiriyoruz. yani id sabit kalıyor isim değişiyor.
            return RedirectToAction("Index");// bu kısım ileriki kısımlarda sorun çıkarabilir
            //revize edilmesi gerekebiliri.
        }

      
    }


}