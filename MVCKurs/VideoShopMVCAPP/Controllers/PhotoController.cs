using Microsoft.AspNetCore.Mvc;

namespace VideoShopMVCAPP.Controllers
{
    public class PhotoController : Controller
    {
        //GET
        public IActionResult UploadPictureSample()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadPictureSample(IFormFile datei)
        {
            if (datei == null)
                ModelState.AddModelError("datei", "Bitte eine Datei auswählen");

            if (ModelState.IsValid)
            {
                FileInfo fileInfo = new FileInfo(datei.FileName);

                //absoluten Speicherpfad
                string savePath = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\" + fileInfo.Name;


                //Upload und Speichern der Datei an den definierten Ort
                using (FileStream stream = new FileStream(savePath, FileMode.Create))
                {
                    await datei.CopyToAsync(stream);
                }

                return RedirectToAction(nameof(UploadPictureSample));
            }

            return View();
        }


        
        public IActionResult PictureGallery()
        {
            string imageDiretoryPath = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\";

            string[] pictures = Directory.GetFiles(imageDiretoryPath);

            return View(pictures);
        }

        public IActionResult FormattedGallery()
        {
            string imageDiretoryPath = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\";

            string[] pictures = Directory.GetFiles(imageDiretoryPath);

            return View(pictures);
        }
    }
}
