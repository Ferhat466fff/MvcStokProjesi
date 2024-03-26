using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;//tanımla
using PagedList.Mvc;//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir//Sayfalama kullanmak için kütüphaneyi kullanıyoruz daha oncesinde indirdik-->mvcstok sağ tık browse gir paged yaz indir



namespace MvcStok.Controllers
{
    public class MusterilerController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();


        //Index Arama(Search) Yapma ve sayfalama
        public ActionResult Index(string p,int sayfa=1)
        {
               //Arama yeri boş değilse aşadakileri yap
               var degerler = from d in db.Tbl_Musteriler select d;
            if(!string.IsNullOrEmpty(p))//!-->Arama yeri boşsa aşadakileri yap
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));//müşteriadı içersinde parametre 1 olanları getir
            }

            var Degerler2 = degerler.OrderBy(k => k.MUSTERIID).ToPagedList(sayfa, 6);//orderby yaptık 2 işlem vardı
            return View(Degerler2);
        }
      
        //Yeni Müşteri Ekle Butonuna Tıklandığında Musteri Bilgilerini Getirme 
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(Tbl_Musteriler m)
        {
            if (!ModelState.IsValid)//boş bırakılırsa yenimüüşteri ındex git
            {
                return View("YeniMusteri");
            }
           
            db.Tbl_Musteriler.Add(m);
            db.SaveChanges();
            return View();
        }

        //Müşteri silme
        public ActionResult SIL(int id)
        {
            var musteri = db.Tbl_Musteriler.Find(id);////find(bul) musteriler id bul
            db.Tbl_Musteriler.Remove(musteri);//id sil
            db.SaveChanges();//kaydet
            return RedirectToAction("Index");//index sayfasına yonlendir
        }

        //Müşteri Güncelleye Butonuna Tıklandığında Müşteri Güncelleme
        public ActionResult Guncelle(Tbl_Musteriler p2)
        {
            var mstr = db.Tbl_Musteriler.Find(p2.MUSTERIID);//tblkategorilerdeki id yi bul
            mstr.MUSTERIAD = p2.MUSTERIAD;//biizm girecegimiz kategorıad tbl kategorışerdeki adla değişsin
            mstr.MUSTERISOYAD = p2.MUSTERISOYAD;
            db.SaveChanges();//kaydet
            return RedirectToAction("Index");//ındex sayfasına at
        }



        //Güncelleye Butonuna Tıklandığında Müşteri Bilgilerini Getirme 
        public ActionResult MusteriGetir(int id)
        {
            var mst = db.Tbl_Musteriler.Find(id);// find(bul) kategorilerdeki id bul
            return View("MusteriGetir", mst);
        }

        
    }
}

