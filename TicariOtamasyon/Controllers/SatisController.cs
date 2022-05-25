using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtamasyon.Models.Siniflar;

namespace TicariOtamasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHareketis.ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> urun = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()

                                           }).ToList();
            ViewBag.urun = urun;

            List<SelectListItem> cariler = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.CariAd,
                                               Value = x.CariID.ToString()

                                           }).ToList();
            ViewBag.cariler = cariler;

            List<SelectListItem> personel = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()

                                           }).ToList();
            ViewBag.personel = personel;
            return View();


        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareketi s)
        {
            c.SatisHareketis.Add(s);
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {

            List<SelectListItem> urun = (from x in c.Uruns.ToList()
                                         select new SelectListItem
                                         {

                                             Text = x.UrunAd,
                                             Value = x.UrunID.ToString()

                                         }).ToList();
            ViewBag.urun = urun;

            List<SelectListItem> cariler = (from x in c.Carilers.ToList()
                                            select new SelectListItem
                                            {

                                                Text = x.CariAd,
                                                Value = x.CariID.ToString()

                                            }).ToList();
            ViewBag.cariler = cariler;

            List<SelectListItem> personel = (from x in c.Personels.ToList()
                                             select new SelectListItem
                                             {

                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.PersonelID.ToString()

                                             }).ToList();
            ViewBag.personel = personel;


















            var deger = c.SatisHareketis.Find(id);
            return View("SatisGetir", deger);

        }
        public ActionResult SatisGuncelle(SatisHareketi p)
        {



            



            return View();




          /*var urn = c.Uruns.Find(p.UrunID);
            urn.AlisFiyat = p.AlisFiyat;
            urn.Durum = p.Durum;
            urn.Kategoriid = p.Kategoriid;
            urn.Marka = p.Marka;
            urn.SatisFiyat = p.SatisFiyat;
            urn.Stok = p.Stok;
            urn.UrunAd = p.UrunAd;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");*/  
        }
    }
}