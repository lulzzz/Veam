using System;
using System.Text;
using Veam.Domain.Core.ValueObjects;

namespace Veam.EAM.Domain
{
    /// <summary>
    /// value Object
    /// </summary>
    public class AssetModel : ValueObject<AssetModel>
    {
        /// <summary>
        ///Defines asset Moadel
        /// </summary>
        /// <param name="Model name"></param>
        /// <param name="Model number"></param>
        /// <param name="Model brand"></param>
        /// <param name="product"></param>
        public AssetModel(string name, string number, string brand, string product)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.number = number ?? throw new ArgumentNullException(nameof(number));
            this.brand = brand ?? throw new ArgumentNullException(nameof(brand));
            this.product = product ?? throw new ArgumentNullException(nameof(product));
        }

        public string name { get; private set; }
        public string number { get; private set; }
        public string brand { get; private set; }
        public string product { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder()
           .Append(product.Remove(2)).Append("-")
           .Append(brand.Remove(2)).Append("-").
            Append(number.Remove(3)).Append("-");
            return sb.ToString();
        }
    }
}