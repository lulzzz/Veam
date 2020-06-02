using System.ComponentModel.DataAnnotations;

namespace Veam.Base.ViewModels
{
    public enum ProductCategory
    {
        [Display(Name = "Asset")]
        Asset = 1,
        [Display(Name = "SpareParts")]
        SpareParts = 2,
        [Display(Name = "Component")]
        Component = 3,
        [Display(Name = "Accessory")]
        Accessory = 4,
        [Display(Name = "Consumable")]
        Consumables = 5,
        [Display(Name = "Capital")]
        Capital =6,
        [Display(Name = "Services")]
        Services =7,
        [Display(Name = "Service Contracts")]
        ServiceContract =8,
        [Display(Name = "New Project")]
        NewProject =9,
        [Display(Name = "Software")]
        software =10,
        [Display(Name = "Maintenance")]
        Maintenance = 11,
        [Display(Name = "IT")]
        IT = 12,
    }
    public enum ProductType
    {
        Furniture,
        FixedStructures,
        HVAC,
        Electrical,
        Tools_Spare,
        Electronic,
        AudioVedio,
        Software,
        Food,
        FMCG,
        Decor,
        Wellfare
    }
}
