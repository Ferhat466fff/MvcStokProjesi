using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();

        //Indexde Arama yapsın ve sayfalasın
        public ActionResult Index(string p,int sayfa=1)
        { //arama
           var degerler= from d in db.Tbl_Urunler select d;
            if(!String.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.URUNAD.Contains(p));
            }
            //sayfalama
            var degerler2 = degerler.OrderBy(k => k.URUNID).ToPagedList(sayfa,6);
            return View(degerler2);
        }


        //Ürün ekleme
        [HttpGet]
        public ActionResult YeniUrün()
        {
            List<SelectListItem> degerler = (from i in db.Tbl_Kategoriler.ToList()//Veritabanındaki tüm kategorileri çektik
                               select new SelectListItem
                              {
                                    Text = i.KATEGORIAD,//displaymember(gözükecek deger)
                                     Value = i.KATERGOIID.ToString()//valuemember gibi düşün(arkada dönen deger) 
                             }).ToList();//listele
            ViewBag.dgr = degerler;//ViewBag-->controller tarafındaki ifadeyi teniürün view tasıyacak
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrün(Tbl_Urunler u)
        {

            var ktg = db.Tbl_Kategoriler.Where(m => m.KATERGOIID == u.Tbl_Kategoriler.KATERGOIID).FirstOrDefault();
            //tblkategoriler kategorııd=u(tbl uurnler) kategorı ıd eşitse getirme işlemi yap
            u.Tbl_Kategoriler = ktg;
            db.Tbl_Urunler.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");// RedirectToAction-->kaydettikden sonra ürünlerin index'e dön
        }
       
        //ÜRÜN SİLME
        public ActionResult SIL(int id)
        {
            var urunler = db.Tbl_Urunler.Find(id);//find(bul) ürünlerdeki id bul
            db.Tbl_Urunler.Remove(urunler);//urunler gelen degeri sil
            db.SaveChanges();//kaydet
            return RedirectToAction("Index");//index sayfasına at
        }


        //Ürün Güncelleye Butonuna Tıklandığında ürünleri Güncelleme
        [HttpPost]
        public ActionResult Guncelle(Tbl_Urunler p)
        {
            var urun = db.Tbl_Urunler.Find(p.URUNID);//tblürünlerdeki id yi bul
            urun.URUNAD = p.URUNAD;//biizm girecegimiz kategorıad tbl kategorışerdeki adla değişsin
            urun.MARKA = p.MARKA;
            urun.STOK = p.STOK;
            urun.FİYAT = p.FİYAT;

            //Tblkategoriler ilişkili o sebeble böyle yaptık
            var ktg = db.Tbl_Kategoriler.Where(m => m.KATERGOIID == p.Tbl_Kategoriler.KATERGOIID).FirstOrDefault();
            urun.URUNKATEGORI= ktg.KATERGOIID;//artık urunkategori kategorııd eşit değişiklik yapabiliriz
            db.SaveChanges();//kaydet
            return RedirectToAction("Index");//ındex sayfasına at
        }




        //Güncelleye Butonuna Tıklandığında ürün Bilgilerini Getirme 
        public ActionResult UrunGetir(int id)
        {
            var urn = db.Tbl_Urunler.Find(id);// find(bul) kategorilerdeki id bul
            List<SelectListItem> degerler = (from i in db.Tbl_Kategoriler.ToList()//Veritabanındaki tüm kategorileri çektik
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,//displaymember(gözükecek deger)
                                                 Value = i.KATERGOIID.ToString()//valuemember gibi düşün(arkada dönen deger) 
                                             }).ToList();//listele
            ViewBag.dgr = degerler;//ViewBag-->controller tarafındaki ifadeyi yeniürün view tasıyacak
       
            return View("UrunGetir", urn);
        }

       




    }
}