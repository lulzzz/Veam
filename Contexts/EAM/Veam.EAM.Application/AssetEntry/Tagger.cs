using System;
using System.Text;

namespace Veam.EAM.Application
{

    public static class Tagger
    {
        /// <summary>
        /// ref date 2018/09/01
        /// </summary>
        /// <param name="product"></param>
        /// <param name="brand"></param>
        /// <param name="newId"></param>
        /// <returns></returns>
        public static string DefaultTag( string product, string brand, long newId)
        {
           return Tagger.GenerateTag16(product, brand, newId, "18", "09", "01");
        }
        /// <summary>
        ///  product(3),brand(2),yymmdd
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="brand"></param>
        /// <param name="uniqueno"></param>
        /// <param name="yy"></param>
        /// <param name="mm"></param>
        /// <param name="dd"></param>
        /// <returns></returns>
        public static string GenerateTag16(string productName, string brand, long uniqueno, string yy, string mm, string dd)
        {


            StringBuilder sb = new StringBuilder()
           .Append(productName.Remove(3).ToUpper())
           .Append(brand.Remove(2).ToUpper()) .Append("-")
           .Append(yy)
           .Append(mm)
           .Append(dd).Append("-")
           .Append(uniqueno.ToString("00000"));

            var Tag = sb.ToString();
            return Tag;
        }

        /// <summary>
        /// product(3),brand(2),yymmdd
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="yy"></param>
        /// <param name="mm"></param>
        /// <param name="dd"></param>
        /// <returns></returns>
        public static string TagByWarrantyEnd(string tag, string yy, string mm, string dd)
        {

            StringBuilder sb = new StringBuilder()

              .Append(tag.ToUpper()).Remove(5, 7).Insert(5,"-"+yy +mm+dd);
              ////.Append(yy)
              //.Append(mm)
              //.Append(dd);
            var Tag = sb.ToString();

            return Tag;
        }
    }
}
