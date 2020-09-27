using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace RGB_to_GREY
{
    class Program
    {
        static Bitmap transform(Bitmap bitmap)
        {
             int width = bitmap.Width;
             int height = bitmap.Height;
             for (int i = 0; i < width; i++)
             {
                 for (int j = 0; j < height; j++)
                 {
                     Color p = bitmap.GetPixel(i, j);
           
                     int a = p.A;
                     int r = p.R;
                     int g = p.G;
                     int b = p.B;
           
                     int avg = (r + g + b) / 3;
           
                     bitmap.SetPixel(i, j, Color.FromArgb(a, avg, avg, avg));
                 }
             }
            return bitmap;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь цветной картинки");
            Console.WriteLine("Например C:\\path\\to\\image.jpg");
            string picture = Console.ReadLine();
            string expansion = picture.Substring(picture.Length - 4);
            try
            {
                if (expansion[0] == '.')
                {
                    if (!(expansion == ".jpg"|| expansion== ".png"|| expansion == ".bmp"))
                    {
                        throw new Exception();
                    }
                    Bitmap bitmap = new Bitmap(picture);
                    Program.transform(bitmap);
                    string newpicture = picture.Remove(picture.Length - 4, 4) + "-result" + expansion;
                    bitmap.Save(newpicture);
                    Console.WriteLine("Черно-белая картинка на ходится здесь "+ newpicture);
                }
                else
                {
                   throw new Exception();
                }
             
            }
            catch (Exception)
            {
                Console.WriteLine("Введите верный путь или формат файла");
            }

        }
    }
}
