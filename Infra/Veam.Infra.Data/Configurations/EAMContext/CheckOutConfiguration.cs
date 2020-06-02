using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EAM.Domain;

namespace Veam.Infra.Data
{
    //public class CheckOutConfiguration : IEntityTypeConfiguration<CheckOut>
    //{
    //    public void Configure(EntityTypeBuilder<CheckOut> builder)
    //    {
    //        builder.ToTable("CheckOut", schema: "EAM");
    //        builder.HasKey(e => e.Id);


    //        //  builder.HasDiscriminator<string>("to")
    //        //  .HasValue<CheckOut>("CheckOut_base")
    //        //  .HasValue<CheckOutToEmployee>("CheckOut_emp")
    //        //     .HasValue<CheckOutToEmployee>("CheckOut_parent")
    //        //.HasValue<CheckOutToLocation>("CheckOut_Loc");
    //        #region checkoutclass
    //        builder.HasOne(e => e.asset).
    //            WithMany(a => a.Checkouts)
    //            .HasForeignKey(x => x.assetId)
    //            .IsRequired()
    //         ;

    //        builder.OwnsOne(af => af.assignmentInfo, cfg =>
    //          {
    //              cfg.Property(e => e.assignmentStatus).IsRequired()
    //            ;
    //              cfg.Property(e => e.assetConditon).IsRequired()
    //            ;
    //              cfg.Property(e => e.conditionNote).IsRequired()
    //           ;
    //          });

    //        builder.OwnsOne(rq => rq.requestInfo, cfg =>
    //        {
    //            cfg.Property(e => e.approveDate).IsRequired()
    //              ;
    //            cfg.Property(e => e.approvedBy).IsRequired()
    //             ;
    //            cfg.Property(e => e.acceptedBy).IsRequired()
    //             ;
    //            cfg.Property(e => e.requestedDate).IsRequired()
    //             ;
    //            cfg.Property(e => e.requestedBy).IsRequired()
    //            ;
    //            cfg.Property(e => e.checkedOutDate).IsRequired()
    //         ;
    //        });

    //        builder.Property(e => e.returnedDate).IsRequired()
    //         ;
    //        builder.Property(e => e.retiredDate).IsRequired()
    //         ;
    //        #endregion
    //    }
    //}

    //public class CheckOutToLocationConfiguration : IEntityTypeConfiguration<CheckOutToLocation>
    //{
    //    public void Configure(EntityTypeBuilder<CheckOutToLocation> builder)
    //    {
    //        builder.ToTable("CheckOutToLocation", schema: "EAM");
    //        builder.HasKey(e => e.Id);


    //        builder.Property(e => e.subsideryId).IsRequired()
    //       ;
    //        builder.Property(e => e.centerId).IsRequired()
    //        ;
    //        builder.Property(e => e.hallId).IsRequired()
    //        ;
    //        builder.Property(e => e.managerId).IsRequired()
    //      ;


    //        #region checkoutclass
    //        //builder.HasOne(e => e.asset).
    //        //    WithMany(a => a.Checkouts)
    //        //    .HasForeignKey(x => x.assetId)
    //        //    .IsRequired()
    //        // ;

    //        builder.OwnsOne(af => af.assignmentInfo, cfg =>
    //        {
    //            cfg.Property(e => e.assignmentStatus).IsRequired()
    //          ;
    //            cfg.Property(e => e.assetConditon).IsRequired()
    //          ;
    //            cfg.Property(e => e.conditionNote).IsRequired()
    //         ;
    //        });

    //        builder.OwnsOne(rq => rq.requestInfo, cfg =>
    //        {
    //            cfg.Property(e => e.approveDate).IsRequired()
    //              ;
    //            cfg.Property(e => e.approvedBy).IsRequired()
    //             ;
    //            cfg.Property(e => e.acceptedBy).IsRequired()
    //             ;
    //            cfg.Property(e => e.requestedDate).IsRequired()
    //             ;
    //            cfg.Property(e => e.requestedBy).IsRequired()
    //            ;
    //            cfg.Property(e => e.checkedOutDate).IsRequired()
    //         ;
    //        });

    //        builder.Property(e => e.returnedDate).IsRequired()
    //         ;
    //        builder.Property(e => e.retiredDate).IsRequired()
    //         ;
    //        #endregion
    //    }
    //}

    public class CheckOutToEmployeeConfiguration : IEntityTypeConfiguration<CheckOutToEmployee>
    {
        public void Configure(EntityTypeBuilder<CheckOutToEmployee> builder)
        {
            builder.ToTable("CheckOutToEmployee", schema: "EAM");
            // builder.HasKey(e => e.Id);

            builder.Property(e => e.employeeId).IsRequired()
             ;
            builder.Property(e => e.managerId).IsRequired()
           ;
            builder.Property(e => e.subsideryId).IsRequired()
          ;

            #region checkoutclass
            //builder.HasOne(e => e.asset).
            //    WithMany(a => a.Checkouts)
            //    .HasForeignKey(x => x.assetId)
            //    .IsRequired()
            // ;

            builder.OwnsOne(af => af.assignmentInfo, cfg =>
            {
                cfg.Property(e => e.assignmentStatus).IsRequired()
              ;
                cfg.Property(e => e.assetConditon).IsRequired()
              ;
                cfg.Property(e => e.conditionNote).IsRequired()
             ;
            });

            builder.OwnsOne(rq => rq.requestInfo, cfg =>
            {
                cfg.Property(e => e.approveDate).IsRequired()
                  ;
                cfg.Property(e => e.approvedBy).IsRequired()
                 ;
                cfg.Property(e => e.acceptedBy).IsRequired()
                 ;
                cfg.Property(e => e.requestedDate).IsRequired()
                 ;
                cfg.Property(e => e.requestedBy).IsRequired()
                ;
                cfg.Property(e => e.checkedOutDate).IsRequired()
             ;
            });

            builder.Property(e => e.returnedDate).IsRequired()
             ;
            builder.Property(e => e.retiredDate).IsRequired()
             ;
            #endregion
        }
    }

    //public class CheckOutToParentAssetConfiguration : IEntityTypeConfiguration<CheckOutToParentAsset>
    //{
    //    public void Configure(EntityTypeBuilder<CheckOutToParentAsset> builder)
    //    {
    //        builder.ToTable("CheckOutToParentAsset", schema: "EAM");
    //        builder.HasKey(e => e.Id);

    //        builder.Property(e => e.parentAssetId).IsRequired()
    //       ;

    //        #region checkoutclass
    //        //builder.HasOne(e => e.asset).
    //        //    WithMany(a => a.Checkouts)
    //        //    .HasForeignKey(x => x.assetId)
    //        //    .IsRequired()
    //        // ;

    //        builder.OwnsOne(af => af.assignmentInfo, cfg =>
    //        {
    //            cfg.Property(e => e.assignmentStatus).IsRequired()
    //          ;
    //            cfg.Property(e => e.assetConditon).IsRequired()
    //          ;
    //            cfg.Property(e => e.conditionNote).IsRequired()
    //         ;
    //        });

    //        builder.OwnsOne(rq => rq.requestInfo, cfg =>
    //        {
    //            cfg.Property(e => e.approveDate).IsRequired()
    //              ;
    //            cfg.Property(e => e.approvedBy).IsRequired()
    //             ;
    //            cfg.Property(e => e.acceptedBy).IsRequired()
    //             ;
    //            cfg.Property(e => e.requestedDate).IsRequired()
    //             ;
    //            cfg.Property(e => e.requestedBy).IsRequired()
    //            ;
    //            cfg.Property(e => e.checkedOutDate).IsRequired()
    //         ;
    //        });

    //        builder.Property(e => e.returnedDate).IsRequired()
    //         ;
    //        builder.Property(e => e.retiredDate).IsRequired()
    //         ;
    //        #endregion
    //    }
    //}
     
}