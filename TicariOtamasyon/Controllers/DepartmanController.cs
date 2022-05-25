﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtamasyon.Models.Siniflar;

namespace TicariOtamasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x => x.Durum == true).ToList();
            return View(degerler);
            //var Urunler = c.Uruns.Where(x => x.Durum == true).ToList();
        }
        public ActionResult DepartmanPartial()
        {
            var degerler = c.Departmans.Where(x => x.Durum == false).ToList();
            return View(degerler);
        }
        public ActionResult Aktiflestir(int id)
        {
            var deger = c.Departmans.Find(id);
            deger.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var deger = c.Departmans.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanKaliciSil(int id)
        {
            var deger = c.Departmans.Find(id);//depertman id başka yerde kullanılıyorsa 
            c.Departmans.Remove(deger);//silmez hata verir
            c.SaveChanges();//hatayı hata sayfasına taşıyacağız
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {

            return View();

        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Departmans.Find(id);
            return View("DepartmanGetir", dpt);
        }
        public ActionResult DepartmanGuncelle(Departman d)
        {
            var dept = c.Departmans.Find(d.DepartmanID);
            dept.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult DepartmanDetay(int id)
        {
            var deger = c.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt = c.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(deger);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHareketis.Where(x => x.Personelid == id).ToList();
            var per = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }
    }
}



