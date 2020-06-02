using NonFactors.Mvc.Lookup;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Veam.CenterRent.Application;
using Veam.Centers.Application;
using Veam.Data;

namespace Veam.Lookups
{
    public class BuildingLookVM
    {
       
        [LookupColumn(Hidden = true)]
        [Display(Name = "building ID")]
        public long Id { get; set; }

        [LookupColumn]
        [Display(Name = "Center Name")]
        public string buidingName { get; set; }
       
        [LookupColumn]
        [Display(Name = " Center No")]
        public string buidingNo { get; set; }
    }
    public class BuidingLookUP : MvcLookup<BuildingLookVM>
    {
        private DataDbContext Context { get; }
        public BuidingLookUP(DataDbContext _Context)
        {
            Context = _Context;
          //  GetId = (model) => model.Id;
        }
        public override IQueryable<BuildingLookVM> GetModels()
        {

            return Context.Building.Select(p =>
            new BuildingLookVM
            {
                Id = p.Id,
                buidingNo = p.buildingNo,
                buidingName = p.buildingName,
              
            }).AsQueryable();

        }
    }

}
