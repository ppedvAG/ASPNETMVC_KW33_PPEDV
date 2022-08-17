
using System.Drawing;

namespace VideoShopMVCAPP.Middleware
{
    public class ThumbnailGen
    {
        private readonly RequestDelegate _next;

        public ThumbnailGen(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var fileNameOfPicture = httpContext.Request.Query["img"][0]; //Ich zu 100% das die Index-Position [0] ein BildPath beinhaltet
            var absolutePicturePath = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\" + fileNameOfPicture;

            using (var sr = new FileStream(absolutePicturePath, FileMode.Open))
            {
                using (var image = new Bitmap(sr))
                {
                    var resized = new Bitmap(300, 200);
                    using (var graphics = Graphics.FromImage(resized))
                    {
                        graphics.DrawImage(image, 0, 0, 300, 200);

                        var ms = new MemoryStream();

                        resized.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                        await httpContext.Response.Body.WriteAsync(ms.ToArray());
                    }
                }
            }
        }
    }


    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ThumbnailGenExtensions
    {
        public static IApplicationBuilder UseThumbnailGen(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ThumbnailGen>();
        }
    }
}
