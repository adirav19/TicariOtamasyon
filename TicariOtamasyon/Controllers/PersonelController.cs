using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtamasyon.Models.Siniflar;

namespace TicariOtamasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();

            return View(degerler);
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var prs = c.Personels.Find(id);
            return View("PersonelGetir",prs);

        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var prs = c.Personels.Find(p.PersonelID);
            prs.PersonelAd = p.PersonelAd;
            prs.PersonelSoyad = p.PersonelSoyad;
            prs.PersonelGorsel = p.PersonelGorsel;
            prs.Departmanid = p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}