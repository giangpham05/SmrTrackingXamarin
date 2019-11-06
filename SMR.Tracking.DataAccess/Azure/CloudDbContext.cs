using Microsoft.EntityFrameworkCore;
using SMR.Tracking.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SMR.Tracking.DataAccess
{
    public class CloudDbContext: DbContext, IDisposable
    {
        private readonly string _connectionString;

        public CloudDbContext(string connectionString) 
            => _connectionString = connectionString;

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var AddedEntities = ChangeTracker.Entries<Audit>().Where(E => E.State == EntityState.Added).ToList();

            AddedEntities.ForEach(E =>
            {
                E.Entity.CreatedOn = DateTime.Now;
            });

            var EditedEntities = ChangeTracker.Entries<Audit>().Where(E => E.State == EntityState.Modified).ToList();

            EditedEntities.ForEach(E =>
            {
                E.Entity.ModifiedOn = DateTime.Now;
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlServer(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.HasDefaultSchema("");
            #region Defect
            modelBuilder.Entity<Defect>()
                .Property(d => d.No)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Defect>()
               .Property(d => d.InspectionDate);

            modelBuilder.Entity<Defect>()
               .Property(d => d.RepairDateDue);

            modelBuilder.Entity<Defect>()
                .HasOne<Repairer>(d => d.Repairer)
                .WithMany(p => p.Defects)
                .HasForeignKey(d => d.AtId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Defect>()
                .HasOne<WalkByInspection>(d => d.WalkByInspection)
                .WithMany(p => p.Defects)
                .HasForeignKey(d => d.WalkByInspectionId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Defect>()
                .HasOne<AT>(d => d.At)
                .WithMany(p => p.Defects)
                .HasForeignKey(d => d.AtId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Defect>()
               .HasOne<ST1>(d => d.St1)
               .WithMany(s => s.Defects)
               .HasForeignKey(d => d.St1Id)
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Defect>()
               .HasOne<ST2>(d => d.St2)
               .WithMany(s => s.Defects)
               .HasForeignKey(d => d.St2Id)
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Defect>()
               .HasOne<Status>(d => d.Status)
               .WithMany(s => s.Defects)
               .HasForeignKey(d => d.StatusId)
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Defect>()
              .HasOne<Priority>(d => d.Priority)
              .WithMany(p => p.Defects)
              .HasForeignKey(d => d.PriorityId)
              .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Defect>()
              .HasOne<DefectType>(d => d.DefectType)
              .WithMany(dt => dt.Defects)
              .HasForeignKey(d => d.DefectTypeId);

            modelBuilder.Entity<Defect>()
              .HasOne<LocationPrefix>(d => d.LocationPrefix)
              .WithMany(lp => lp.Defects)
              .HasForeignKey(d => d.LocationPrefixId)
              .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Defect>()
                .Property(e => e.LocationFromDesc)
                .IsUnicode(false);

            modelBuilder.Entity<Defect>()
                .Property(e => e.LocationToDesc)
                .IsUnicode(false);

            modelBuilder.Entity<Defect>()
                .Property(e => e.RepairComments)
                .IsUnicode(false);

            modelBuilder.Entity<Defect>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            //modelBuilder.Entity<DefectInspector>()
            //    .HasKey(di => new { di.DefectId, di.InspectorId});
            modelBuilder.Entity<DefectInspector>()
                .HasOne<Defect>(di => di.Defect)
                .WithMany(d => d.DefectInspectors)
                .HasForeignKey(di => di.DefectId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<DefectInspector>()
                .HasOne<Inspector>(di => di.Inspector)
                .WithMany(i => i.DefectInspectors)
                .HasForeignKey(di => di.InspectorId)
                .OnDelete(DeleteBehavior.SetNull);
            #endregion

            #region Repair Line
            //modelBuilder.Entity<DefectRepairLine>()
            //    .HasKey(e => new
            //    {
            //        e.DefectId,
            //        e.RepaierId
            //    });

            modelBuilder.Entity<DefectRepairLine>()
                .HasOne<Defect>(e => e.Defect)
                .WithMany(d => d.DefectRepairLines)
                .HasForeignKey(d => d.DefectId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<DefectRepairLine>()
                .HasOne<Repairer>(e => e.Repairer)
                .WithMany(d => d.DefectRepairLines)
                .HasForeignKey(d => d.RepaierId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<DefectRepairLine>()
                .HasOne<Inventory>(d => d.Inventory)
                .WithMany(p => p.DefectRepairLines)
                .HasForeignKey(d => d.InventoryId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<DefectRepairLine>()
                .Property(d => d.Quantity).IsRequired(false);
            modelBuilder.Entity<DefectRepairLine>()
               .Property(e => e.RepairComment).IsRequired(false)
               .IsUnicode(false);

            modelBuilder.Entity<DefectRepairLine>()
               .Property(e => e.RepairDate);

            #endregion

            #region Hi Rail Inspection
            modelBuilder.Entity<HiRailInspection>()
                .Property(d => d.No)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<HiRailInspection>()
                .HasOne<AssetCondition>(d => d.AssetCondition)
                .WithMany(p => p.HiRailInspections)
                .HasForeignKey(d => d.AssetConditionId).IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<HiRailInspection>()
              .Property(e => e.InspectionDate);

            //modelBuilder.Entity<HiRailInspector>()
            //    .HasKey(hi => new { hi.HiRailInspectionId, hi.InspectorId });

            modelBuilder.Entity<HiRailInspector>()
                .HasOne<HiRailInspection>(hi => hi.HiRailInspection)
                .WithMany(d => d.HiRailInspectors)
                .HasForeignKey(hi => hi.HiRailInspectionId).IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<HiRailInspector>()
                .HasOne<Inspector>(di => di.Inspector)
                .WithMany(i => i.HiRailInspectors)
                .HasForeignKey(di => di.InspectorId).IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<HiRailMatrix>()
            //    .HasKey(hi => new 
            //    { 
            //        hi.HiRailInspectionId, hi.HiRailLocationId, 
            //        hi.HiRailAssetTypeId, hi.AssetConditionId 
            //    });

            modelBuilder.Entity<HiRailMatrix>()
                .HasOne<HiRailInspection>(hi => hi.HiRailInspection)
                .WithMany(d => d.HiRailMatrices)
                .HasForeignKey(hi => hi.HiRailInspectionId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<HiRailMatrix>()
                .HasOne<HiRailLocation>(di => di.HiRailLocation)
                .WithMany(i => i.HiRailMatrices)
                .HasForeignKey(di => di.HiRailLocationId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<HiRailMatrix>()
                .HasOne<HiRailAssetType>(di => di.HiRailAssetType)
                .WithMany(i => i.HiRailMatrices)
                .HasForeignKey(di => di.HiRailAssetTypeId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<HiRailMatrix>()
                .HasOne<AssetCondition>(di => di.AssetCondition)
                .WithMany(i => i.HiRailMatrices)
                .HasForeignKey(di => di.AssetConditionId)
                .OnDelete(DeleteBehavior.SetNull);
            #endregion

            #region Walk By Inspection
            modelBuilder.Entity<WalkByInspection>()
                .Property(d => d.No)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<WalkByInspection>()
              .Property(e => e.InspectionDate);
            modelBuilder.Entity<WalkByInspection>()
               .Property(e => e.Location);
            modelBuilder.Entity<WalkByInspection>()
               .Property(e => e.Description).IsRequired(false)
               .IsUnicode(false);
            modelBuilder.Entity<WalkByInspection>()
               .Property(e => e.Gauge).IsRequired(false)
               .IsUnicode(false);
            modelBuilder.Entity<WalkByInspection>()
               .Property(e => e.Super).IsRequired(false)
               .IsUnicode(false);
            modelBuilder.Entity<WalkByInspection>()
               .Property(e => e.PoorSleepers).IsRequired(false)
               .IsUnicode(false);

            modelBuilder.Entity<WalkByInspection>()
                .HasOne<AssetCondition>(d => d.AssetCondition)
                .WithMany(p => p.WalkByInspections)
                .HasForeignKey(d => d.AssetConditionId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<WalkByInspection>()
              .HasOne<LocationPrefix>(d => d.LocationPrefix)
              .WithMany(lp => lp.WalkByInspections)
              .HasForeignKey(d => d.LocationPrefixId)
              .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<WalkByInspection>()
              .HasOne<LocationPrefix>(d => d.LocationPrefix)
              .WithMany(lp => lp.WalkByInspections)
              .HasForeignKey(d => d.LocationPrefixId)
              .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<WalkByInspector>()
            //   .HasKey(wb => new { wb.WalkByInspectionId, wb.InspectorId });

            modelBuilder.Entity<WalkByInspector>()
                .HasOne<WalkByInspection>(hi => hi.WalkByInspection)
                .WithMany(d => d.WalkByInspectors)
                .HasForeignKey(hi => hi.WalkByInspectionId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<WalkByInspector>()
                .HasOne<Inspector>(di => di.Inspector)
                .WithMany(i => i.WalkByInspectors)
                .HasForeignKey(di => di.InspectorId)
                .OnDelete(DeleteBehavior.SetNull);
            #endregion

            #region File
            modelBuilder.Entity<FileAttachment>()
                .HasOne<Defect>(df => df.Defect)
                .WithMany(i => i.FileAttachments)
                .HasForeignKey(di => di.DefectId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<FileAttachment>()
                .Property(e => e.Filename)
                .IsUnicode(false);

            modelBuilder.Entity<FileAttachment>()
                .Property(e => e.Mimetype)
                .IsUnicode(false);
            #endregion

            #region Dictionaries
            modelBuilder.Entity<AssetCondition>()
                .Property(e => e.Label)
                .IsFixedLength();
            modelBuilder.Entity<AT>()
                .Property(e => e.Label)
                .IsUnicode(false);

            modelBuilder.Entity<ST1>()
                .Property(e => e.Label)
                .IsUnicode(false);
            modelBuilder.Entity<ST1>()
                .HasOne<AT>(s => s.At)
                .WithMany(a => a.St1s)
                .HasForeignKey(s => s.AtId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ST2>()
                .Property(e => e.Label)
                .IsUnicode(false);
            modelBuilder.Entity<ST2>()
                .HasOne<ST1>(s => s.St1)
                .WithMany(s1 => s1.St2s)
                .HasForeignKey(s2 => s2.St1Id)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<DefectType>()
                .Property(e => e.Label)
                .IsUnicode(false);
            modelBuilder.Entity<DefectType>()
                .Property(e => e.DefectAction)
                .IsUnicode(false);

            modelBuilder.Entity<DefectType>()
                .HasOne<ST2>(s => s.St2)
                .WithMany(s => s.DefectTypes)
                .HasForeignKey(dt => dt.St2Id)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<DefectType>()
                .HasOne<Priority>(s => s.Priority)
                .WithMany(s => s.DefectTypes)
                .HasForeignKey(dt => dt.PriorityId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<HiRailAssetType>()
                .Property(e => e.Label)
                .IsFixedLength();
            modelBuilder.Entity<HiRailLocation>()
                .Property(e => e.Label)
                .IsFixedLength();
            modelBuilder.Entity<Inspector>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Priority>()
                .Property(e => e.Label)
                .IsUnicode(false);

            modelBuilder.Entity<Repairer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Label)
                .IsUnicode(false);
            modelBuilder.Entity<Inventory>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<LocationPrefix>()
                .Property(e => e.Label)
                .IsUnicode(false);
            #endregion
        }

        #region DB Sets
        public DbSet<Defect> Defects { get; set; }
        public DbSet<AT> Ats { get; set; }
        public DbSet<ST1> St1s { get; set; }
        public DbSet<ST2> St2s { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<DefectType> DefectTypes { get; set; }
        public DbSet<LocationPrefix> LocationPrefixes { get; set; }
        public DbSet<AssetCondition> AssetConditions { get; set; }
        public DbSet<FileAttachment> FileAttachments { get; set; }
        public DbSet<HiRailAssetType> HiRailAssetTypes { get; set; }
        public DbSet<HiRailInspection> HiRailInspections { get; set; }
        public DbSet<HiRailLocation> HiRailLocations { get; set; }
        public DbSet<Inspector> Inspectors { get; set; }
        public DbSet<LocationIncrement> LocationIncrements { get; set; }
        public DbSet<Repairer> Repairers { get; set; }
        public DbSet<DefectRepairLine> RepairLines { get; set; }
        public DbSet<WalkByInspection> WalkByInspections { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<DefectInspector> DefectInspectors { get; set; }
        public DbSet<HiRailInspector> HiRailInspectors { get; set; }
        public DbSet<WalkByInspector> WalkByInspectors { get; set; }
        public DbSet<HiRailMatrix> HiRailMatrices { get; set; }
        public DbSet<DefectRepairLine>  DefectRepairLines { get; set; }
        #endregion
    }
}
