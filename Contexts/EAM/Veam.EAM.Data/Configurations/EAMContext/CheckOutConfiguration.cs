using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EAM.Domain;

namespace Veam.Infra.Data
{
    public class CheckOutConfiguration : IEntityTypeConfiguration<CheckOut>
    {
        public void Configure(EntityTypeBuilder<CheckOut> builder)
        {
            builder.ToTable("CheckOut", schema: "EAM");
            builder.HasKey(e => e.Id);

            #region checkoutclass
            builder.HasOne(e => e.asset).
                WithMany(a => a.Checkouts)
                .HasForeignKey(x => x.assetId)
                .IsRequired()
             ;

            builder.OwnsOne(af => af.assignmentInfo, cfg =>
              {
                  cfg.Property(e => e.assignmentStatus)
                ;
                  cfg.Property(e => e.assetConditon)
                ;
                  cfg.Property(e => e.conditionNote)
               ;
              });

            builder.OwnsOne(rq => rq.requestInfo, cfg =>
            {
                cfg.Property(e => e.approveDate)
                  ;
                cfg.Property(e => e.approvedBy)
                 ;
                
                cfg.Property(e => e.requestedDate)
                 ;
                cfg.Property(e => e.requestedBy)
                ;

            });

            builder.OwnsOne(rq => rq.toLocation, cfg =>
            {
                cfg.Property(e => e.subsideryId)
                 ;
                cfg.Property(e => e.centerId)
                     ;
                cfg.Property(e => e.hallId)
                    ;
                cfg.Property(e => e.managerId)
                 ;

            });

            builder.OwnsOne(rq => rq.toEmployee, cfg =>
            {
                cfg.Property(e => e.employeeId)
                  ;
                cfg.Property(e => e.departmentId)
                  ;
                cfg.Property(e => e.subsideryId)
                    ;

            });
            builder.OwnsOne(rq => rq.toParentAsset, cfg =>
            {

                cfg.Property(e => e.parentAssetId)
                ;
            });


            builder.Property(e => e.returnedDate) 
             ;
            builder.Property(e => e.retiredDate) 
             ;
            #endregion
        }
    }


}