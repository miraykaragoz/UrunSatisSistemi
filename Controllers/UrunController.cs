using Microsoft.AspNetCore.Mvc;
using UrunSatisSistemi.Models;

namespace UrunSatisSistemi.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult Index()
        {
            var urun = new List<Urun>();
            using StreamReader reader = new StreamReader("App_Data/index.txt");
            var urunData = reader.ReadToEnd();
            var urunLines = urunData.Split('\n');
            foreach (var line in urunLines)
            {
                var urunParts = line.Split('|');
                urun.Add(
                    new Urun()
                    {
                        Id = int.Parse(urunParts[0]),
                        Name = urunParts[1],
                        Price = int.Parse(urunParts[2]),
                        Currency = urunParts[3],
                        Stock = int.Parse(urunParts[4]),
                        Img = urunParts[5]
                    }
                );
            }

            return View(urun);
        }

       
        [HttpPost]
        public IActionResult Index(Satis model)
        {
            var urun = new List<Urun>();
            using StreamReader reader = new StreamReader("App_Data/index.txt");
            var urunData = reader.ReadToEnd();
            var urunLines = urunData.Split('\n');
            foreach (var line in urunLines)
            {
                var urunParts = line.Split('|');
                urun.Add(
                    new Urun()
                    {
                        Id = int.Parse(urunParts[0]),
                        Name = urunParts[1],
                        Price = int.Parse(urunParts[2]),
                        Currency = urunParts[3],
                        Stock = int.Parse(urunParts[4]),
                        Img = urunParts[5]
                    }
                );
            }

            //Satis model = new Satis();
            //model.SelectedProduct = selectedProduct;
            //model.Quantity = quantity;
            //model.Payment = alinanPara;

            var findSelectedProduct = urun.FirstOrDefault(urun => urun.Id == model.SelectedProduct);

            if (findSelectedProduct != null)
            {
                var totalPrice = model.Quantity * findSelectedProduct.Price;
                if (model.Payment >= totalPrice)
                {
                    model.Change = model.Payment - totalPrice;
                    return RedirectToAction("BasariliOdeme", model);
                }
                else
                {
                    ViewData["Hata"] = "Yetersiz ödeme miktarı. Lütfen tekrar deneyin.";
                }
            }

            return View(urun);
        }

        [HttpGet]
        public IActionResult BasariliOdeme(Satis model)
        {
            return View(model);
        }
    }
}
