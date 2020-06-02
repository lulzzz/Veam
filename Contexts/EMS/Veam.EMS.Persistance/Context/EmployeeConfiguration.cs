//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Veam.EMS.Domain;

//namespace Veam.EMS.Data
//{

//    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
//    {
//        public void Configure(EntityTypeBuilder<Employee> entity)
//        {

//            entity.HasIndex(e => e.GlobalId)
//                  .HasName("UQ__Employee__A50E8993D0F46EBD")
//                  .IsUnique();

//            entity.Property(e => e.EmployeeId)
//                .HasColumnName("EmployeeID")
//                .HasMaxLength(30)
//                .IsUnicode(false)
//                .ValueGeneratedNever();

//            entity.Property(e => e.AvailableFlag).HasDefaultValueSql("('1')");

//            entity.Property(e => e.BirthDate).HasColumnType("date");

//            entity.Property(e => e.CardId)
//                .HasColumnName("CardID")
//                .HasMaxLength(50)
//                .IsUnicode(false);

//            entity.Property(e => e.ChangedDate)
//                .HasColumnType("datetime")
//                .HasDefaultValueSql("(getdate())");

//            entity.Property(e => e.EmployeeType)
//                .IsRequired()
//                .HasColumnType("nchar(2)");

//            entity.Property(e => e.FirstName)
//                .IsRequired()
//                .HasMaxLength(50)
//                .IsUnicode(false);

//            entity.Property(e => e.FirstNameThai)
//                .IsRequired()
//                .HasMaxLength(50);

//            entity.Property(e => e.Gender)
//                .IsRequired()
//                .HasColumnType("nchar(1)");

//            entity.Property(e => e.GlobalId)
//                .IsRequired()
//                .HasColumnName("GlobalID")
//                .HasMaxLength(30)
//                .IsUnicode(false);

//            entity.Property(e => e.Hand)
//                .IsRequired()
//                .HasMaxLength(10)
//                .IsUnicode(false);

//            entity.Property(e => e.Height).HasColumnType("decimal(18, 0)");

//            entity.Property(e => e.HireDate).HasColumnType("date");

//            entity.Property(e => e.HireType)
//                .IsRequired()
//                .HasMaxLength(10)
//                .IsUnicode(false);

//            entity.Property(e => e.LastName)
//                .IsRequired()
//                .HasMaxLength(50)
//                .IsUnicode(false);

//            entity.Property(e => e.LastNameThai)
//                .IsRequired()
//                .HasMaxLength(50);

//            entity.Property(e => e.Title)
//                .IsRequired()
//                .HasMaxLength(5);

//            entity.Property(e => e.TitleThai)
//                .IsRequired()
//                .HasMaxLength(15);

//        }
//    }
//    public class EmployeeAccountConfiguration : IEntityTypeConfiguration<EmployeeAccount>
//    {
//        public void Configure(EntityTypeBuilder<EmployeeAccount> entity)
//        {

//            entity.HasKey(e => new { e.EmployeeId, e.AccountId });

//            entity.Property(e => e.EmployeeId)
//                .HasColumnName("EmployeeID")
//                .HasMaxLength(30)
//                .IsUnicode(false);

//            entity.Property(e => e.AccountId).HasColumnName("AccountID");

//            entity.HasOne(d => d.Account)
//                .WithMany(p => p.EmployeeAccount)
//                .HasForeignKey(d => d.AccountId)
//                .HasConstraintName("FK_EmployeeUser_MasterUser_UserID");

//            entity.HasOne(d => d.Employee)
//                .WithMany(p => p.EmployeeAccount)
//                .HasForeignKey(d => d.EmployeeId)
//                .HasConstraintName("FK_EmployeeUser_Employee_EmployeeID");
//        }
//    }
//    public class EmployeeAddressConfiguration : IEntityTypeConfiguration<EmployeeAddress>
//    {
//        public void Configure(EntityTypeBuilder<EmployeeAddress> entity)
//        {
           
//                entity.Property(e => e.EmployeeAddressId).HasColumnName("EmployeeAddressID");

//                entity.Property(e => e.ChangedDate)
//                    .HasColumnType("datetime")
//                    .HasDefaultValueSql("(getdate())");

//                entity.Property(e => e.City)
//                    .IsRequired()
//                    .HasMaxLength(30);

//                entity.Property(e => e.Country)
//                    .IsRequired()
//                    .HasMaxLength(50);

//                entity.Property(e => e.EmailAddress)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.EmployeeId)
//                    .IsRequired()
//                    .HasColumnName("EmployeeID")
//                    .HasMaxLength(30)
//                    .IsUnicode(false);

//                entity.Property(e => e.HomeAddress)
//                    .IsRequired()
//                    .HasMaxLength(100);

//                entity.Property(e => e.PhoneNumber)
//                    .HasMaxLength(30)
//                    .IsUnicode(false);

//                entity.Property(e => e.PostalCode)
//                    .IsRequired()
//                    .HasMaxLength(15);

//                entity.HasOne(d => d.Employee)
//                    .WithMany(p => p.EmployeeAddress)
//                    .HasForeignKey(d => d.EmployeeId)
//                    .HasConstraintName("FK_EmployeeAdress_Employee_EmployeeID");
            
//        }
//    }

//    public class EmployeeEducationConfiguration : IEntityTypeConfiguration<EmployeeEducation>
//    {
//        public void Configure(EntityTypeBuilder<EmployeeEducation> entity)
//        {
            
//                entity.Property(e => e.EmployeeEducationId).HasColumnName("EmployeeEducationID");

//                entity.Property(e => e.ChangedDate)
//                    .HasColumnType("datetime")
//                    .HasDefaultValueSql("(getdate())");

//                entity.Property(e => e.EmployeeId)
//                    .IsRequired()
//                    .HasColumnName("EmployeeID")
//                    .HasMaxLength(30)
//                    .IsUnicode(false);

//                entity.Property(e => e.LastEducation).HasDefaultValueSql("('1')");

//                entity.Property(e => e.MajorId).HasColumnName("MajorID");

//                entity.HasOne(d => d.Employee)
//                    .WithMany(p => p.EmployeeEducation)
//                    .HasForeignKey(d => d.EmployeeId);

//                entity.HasOne(d => d.Major)
//                    .WithMany(p => p.EmployeeEducation)
//                    .HasForeignKey(d => d.MajorId);
            
//        }
//    }

//    public class EmployeeImageConfiguration : IEntityTypeConfiguration<EmployeeImage>
//    {
//        public void Configure(EntityTypeBuilder<EmployeeImage> entity)
//        {
//            entity.HasKey(e => e.ImageId);

//            entity.Property(e => e.ImageId).HasColumnName("ImageID");

//            entity.Property(e => e.EmployeeId)
//                .IsRequired()
//                .HasColumnName("EmployeeID")
//                .HasMaxLength(30)
//                .IsUnicode(false);

//            entity.HasOne(d => d.Employee)
//                .WithMany(p => p.EmployeeImage)
//                .HasForeignKey(d => d.EmployeeId);
//        }
//    }

//    public class EmployeeLocationConfiguration : IEntityTypeConfiguration<EmployeeLocation>
//    {
//        public void Configure(EntityTypeBuilder<EmployeeLocation> entity)
//        {

//            entity.HasKey(e => new { e.LocationId, e.EmployeeId });

//            entity.Property(e => e.LocationId).HasColumnName("LocationID");

//            entity.Property(e => e.EmployeeId)
//                .HasColumnName("EmployeeID")
//                .HasMaxLength(30)
//                .IsUnicode(false);

//            entity.Property(e => e.ChangeDate)
//                .HasColumnType("datetime")
//                .HasDefaultValueSql("(getdate())");

//            entity.HasOne(d => d.Employee)
//                .WithMany(p => p.EmployeeLocation)
//                .HasForeignKey(d => d.EmployeeId);

//            entity.HasOne(d => d.Location)
//                .WithMany(p => p.EmployeeLocation)
//                .HasForeignKey(d => d.LocationId);
//        }
//    }
//    public class EmployeeStateConfiguration : IEntityTypeConfiguration<EmployeeState>
//    {
//        public void Configure(EntityTypeBuilder<EmployeeState> entity)
//        {

//            entity.HasKey(e => e.EmployeeId);

//            entity.Property(e => e.EmployeeId)
//                .HasColumnName("EmployeeID")
//                .HasMaxLength(30)
//                .IsUnicode(false)
//                .ValueGeneratedNever();

//            entity.Property(e => e.BusStationId).HasColumnName("BusStationID");

//            entity.Property(e => e.ChangedDate)
//                .HasColumnType("datetime")
//                .HasDefaultValueSql("(getdate())");

//            entity.Property(e => e.JobFunctionId).HasColumnName("JobFunctionID");

//            entity.Property(e => e.JoinDate).HasColumnType("date");

//            entity.Property(e => e.LevelId).HasColumnName("LevelID");

//            entity.Property(e => e.PositionId).HasColumnName("PositionID");

//            entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

//            entity.HasOne(d => d.BusStation)
//                .WithMany(p => p.EmployeeState)
//                .HasForeignKey(d => d.BusStationId);

//            entity.HasOne(d => d.Employee)
//                .WithOne(p => p.EmployeeState)
//                .HasForeignKey<EmployeeState>(d => d.EmployeeId);

//            entity.HasOne(d => d.JobFunction)
//                .WithMany(p => p.EmployeeState)
//                .HasForeignKey(d => d.JobFunctionId);

//            entity.HasOne(d => d.Level)
//                .WithMany(p => p.EmployeeState)
//                .HasForeignKey(d => d.LevelId);

//            entity.HasOne(d => d.Position)
//                .WithMany(p => p.EmployeeState)
//                .HasForeignKey(d => d.PositionId);

//            entity.HasOne(d => d.Shift)
//                .WithMany(p => p.EmployeeState)
//                .HasForeignKey(d => d.ShiftId);

//        }
//    }
//    public class EmployeSkillsConfiguration : IEntityTypeConfiguration<EmployeSkills>
//    {
//        public void Configure(EntityTypeBuilder<EmployeSkills> entity)
//        {
//            entity.HasKey(e => new { e.EmployeeId, e.SkillId });

//            entity.Property(e => e.EmployeeId)
//                .HasColumnName("EmployeeID")
//                .HasMaxLength(30)
//                .IsUnicode(false);

//            entity.Property(e => e.SkillId).HasColumnName("SkillID");

//            entity.HasOne(d => d.Employee)
//                .WithMany(p => p.EmployeSkills)
//                .HasForeignKey(d => d.EmployeeId)
//                .HasConstraintName("FK_EmployeeSkills_Employee_EmployeeID");

//            entity.HasOne(d => d.Skill)
//                .WithMany(p => p.EmployeSkills)
//                .HasForeignKey(d => d.SkillId)
//                .HasConstraintName("FK_EmployeeSkills_MasterSkill_SkillID");

//        }
//    }
//}