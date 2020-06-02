//using System;
//using System.Globalization;
//using System.Text;
//using Veam.EAM.Application;

//namespace SomeUI
//{
//    class Program
//    {
//        //private static SamuraiContext _context = new SamuraiContext();
//        static void Main(string[] args)
//        {
//            checkTagger();

//        }
//         public static void checkTagger()
//        {
//            var dt = "09/01/2018 12:00:00 AM";
//            var yy = DateTime.ParseExact(dt.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture).ToString("yy");
//            var mm = DateTime.ParseExact(dt.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture).ToString("MM");
//            var dd = DateTime.ParseExact(dt.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture).ToString("dd");

//            var tag = Tagger.GenerateTag16("spitAc", "Daikin", 1, yy, mm, dd);
//            var tag2 = Tagger.GenerateTag16("spitAc", "Daikin", 2, yy, mm, dd);
//            var k = Tagger.TagByWarrantyEnd(tag, yy, mm, dd);
//            var defaulttag = Tagger.DefaultTag("spitAc", "Daikin", 1);
//            var defaulttag2 = Tagger.DefaultTag("spitAc", "Daikin", 2);
//            Console.WriteLine($"tag generated is: {tag}");
//            Console.WriteLine($"tag generated is: {tag2}");
//            Console.WriteLine($"tag update is { k}");
//            Console.WriteLine($"tag Default is { defaulttag}");
//            Console.WriteLine($"tag Default is { defaulttag2}");
//        }
       
//    }

//    //public static class Tagger
//    //{
//    //    /// <summary>
//    //    ///  product(3),brand(2),yymmdd
//    //    /// </summary>
//    //    /// <param name="productName"></param>
//    //    /// <param name="brand"></param>
//    //    /// <param name="uniqueno"></param>
//    //    /// <param name="yy"></param>
//    //    /// <param name="mm"></param>
//    //    /// <param name="dd"></param>
//    //    /// <returns></returns>
//    //    public static string GenerateTag16(string productName, string brand, long uniqueno, string yy, string mm, string dd)
//    //    {


//    //        StringBuilder sb = new StringBuilder()
//    //       .Append(productName.Remove(3).ToUpper())
//    //       .Append(brand.Remove(2).ToUpper())
//    //       .Append(uniqueno.ToString("00000"))
//    //       .Append(yy)
//    //       .Append(mm)
//    //       .Append(dd);
//    //        var Tag = sb.ToString();
//    //        return Tag;
//    //    }

//    //    /// <summary>
//    //    /// product(3),brand(2),yymmdd
//    //    /// </summary>
//    //    /// <param name="tag"></param>
//    //    /// <param name="yy"></param>
//    //    /// <param name="mm"></param>
//    //    /// <param name="dd"></param>
//    //    /// <returns></returns>
//    //    public static string TagByWarrantyEnd(string tag, string yy, string mm, string dd)
//    //    {

//    //        StringBuilder sb = new StringBuilder()
//    //          .Append(tag.Remove(tag.Length - 6, 6).ToUpper())
//    //          .Append(yy)
//    //          .Append(mm)
//    //          .Append(dd);
//    //        var Tag = sb.ToString();

//    //        return Tag;
//    //    }
//    //}
//}
