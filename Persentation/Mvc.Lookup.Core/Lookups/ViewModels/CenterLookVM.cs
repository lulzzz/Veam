using NonFactors.Mvc.Lookup;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Veam.Data;

namespace Veam.Lookups
{
    public class CenterLookVM
    {
        [Key]
        [LookupColumn(Hidden = true)]
        [Display(Name = "Center ID")]
        public long Id { get; set; }

        [LookupColumn]
        [Display(Name = "Center Name")]
        public string centerName { get; set; }

        [LookupColumn]
        [Display(Name = " Center No")]
        public int CenterNo { get; set; }

        [LookupColumn]
        [Display(Name = "Location")]
        public string Location { get; set; }

    }
    public class CenterLookUp : MvcLookup<CenterLookVM>
    {
        private DataDbContext Context { get; }
        public CenterLookUp(DataDbContext _Context)
        {
            Context = _Context;
            GetId = (model) => model.Id.ToString();
        }
        public override IQueryable<CenterLookVM> GetModels()
        {


            return Context.Center.Select(p =>
            new CenterLookVM
            {
                Id = p.Id,
                centerName = p.centerName,
                Location = p.centerType.Type
            }).AsQueryable() ;

        }
    }

    public class HallLookUpVM
    {
        [Key]
        [LookupColumn(Hidden = true)]
        [Display(Name = " ID")]
        public long Id { get; set; }

        [LookupColumn(Hidden = true)]
        [Display(Name = " centerID")]
        public long? centerId { get; set; }

        [LookupColumn]
        [Display(Name = "Hall Name")]
        public string hallName { get; set; }

        [LookupColumn]
        [Display(Name = " Hall No")]
        public string HallNo { get; set; }

        [LookupColumn]
        [Display(Name = "center")]
        public string Center { get; set; }

    }
    public class HallLookUp : MvcLookup<HallLookUpVM>
    {
        private DataDbContext Context { get; }
        public HallLookUp(DataDbContext _Context)
        {
            Context = _Context;
            GetId = (model) => model.Id.ToString() ;
        }
        public override IQueryable<HallLookUpVM> GetModels()
        {
            return Context.Hall.Select(p =>
            new HallLookUpVM
            {
                Id = p.Id,
                hallName = p.hallName,
                HallNo = p.hallNo,
                Center = p.center.centerName,
                centerId = p.centerId,
            }).AsQueryable();

        }
    }

}
