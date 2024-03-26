using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;//mvcstok(projemızın ismi)içinde bulunan models(model klasorunun icinde bulunan) entity klasörünü sec
using PagedList;
using PagedList.Mvc;//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir



namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.Tbl_Kategoriler.ToList().ToPagedList(sayfa, 6);
            //Sayfa 1den başlasın ve 4 erli bölünsün çalıştır gör
            return View(degerler);
        }

        //Yeni Kategori Ekle Butonuna Tıklandığında Kategori Bilgilerini Getirme 
        [HttpGet]//-->Sayfa yüklenince bunu yap
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]//-->ben butona tıklayınca bunu yap
        public ActionResult YeniKategori(Tbl_Kategoriler p1)
        {   if(!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.Tbl_Kategoriler.Add(p1);
            db.SaveChanges();//kaydet
            return View();
        }



        //kategori silme
        public ActionResult SIL(int id)
        {
            var kategori = db.Tbl_Kategoriler.Find(id);//find(bul) kategorilerdeki id bul
            db.Tbl_Kategoriler.Remove(kategori);//kategoriden gelen degeri sil
            db.SaveChanges();//kaydet
            return RedirectToAction("Index");//ındex sayfasına yönlendir
        }


        //Kategori Güncelleye Butonuna Tıklandığında Kategori Güncelleme
        public ActionResult Guncelle(Tbl_Kategoriler p1)
        {
            var ktg = db.Tbl_Kategoriler.Find(p1.KATERGOIID);//tblkategorilerdeki id yi bul
            ktg.KATEGORIAD= p1.KATEGORIAD;//biizm girecegimiz kategorıad tbl kategorışerdeki adla değişsin
            db.SaveChanges();//kaydet
            return RedirectToAction("Index");//ındex sayfasına at
        }


       //Güncelleye Butonuna Tıklandığında Kategori Bilgilerini Getirme 
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.Tbl_Kategoriler.Find(id);// find(bul) kategorilerdeki id bul
            return View("KategoriGetir", ktgr);
        }
    }
}