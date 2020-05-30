using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Fonts;
using SixLabors.ImageSharp.Drawing.Processing;
using System.IO;

namespace Captai.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 1) { return; }


            FontCollection fonts = new FontCollection();
            var actionManFont = fonts.Install("/home/peter/Pictures/captai/Action_Man.ttf");
            var font = new Font(actionManFont, 39, FontStyle.Regular);

            FontRectangle s = new FontRectangle(369, 80, 506, 302);

            var textGraphicOptions = new TextGraphicsOptions()
            {
                TextOptions = {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    WrapTextWidth = 164.0f
                }
            };

            var result = "output.jpg";
            using(Image<Rgba32> image = (Image<Rgba32>)Image.Load("/home/peter/Pictures/captai/template.png"))
            {
                image.Mutate(x => x
                    .DrawText(textGraphicOptions, args[0], font, Color.Black, new PointF(362.0f, 171.0f))
                );
                image.Save(result);
            }
        }
    }
}
