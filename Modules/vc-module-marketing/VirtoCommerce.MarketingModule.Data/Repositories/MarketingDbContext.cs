using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;
using VirtoCommerce.MarketingModule.Data.Model;

namespace VirtoCommerce.MarketingModule.Data.Repositories
{
    public class MarketingDbContext : DbContextWithTriggers
    {
        public MarketingDbContext(DbContextOptions<MarketingDbContext> options)
            : base(options)
        {
        }

        protected MarketingDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CouponEntity>().ToTable("Coupon");
            modelBuilder.Entity<CouponEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<CouponEntity>().Property(x => x.Id);
            modelBuilder.Entity<CouponEntity>().HasOne(x => x.Promotion).WithMany()
                .HasForeignKey(x => x.PromotionId).OnDelete(DeleteBehavior.Cascade).IsRequired();
            modelBuilder.Entity<CouponEntity>().HasIndex(i => new { i.Code, i.PromotionId }).IsUnique().HasName("IX_CodeAndPromotionId");


            modelBuilder.Entity<PromotionEntity>().ToTable("Promotion");
            modelBuilder.Entity<PromotionEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<PromotionEntity>().Property(x => x.Id);

            modelBuilder.Entity<PromotionUsageEntity>().ToTable("PromotionUsage");
            modelBuilder.Entity<PromotionUsageEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<PromotionUsageEntity>().Property(x => x.Id);
            modelBuilder.Entity<PromotionUsageEntity>().HasOne(x => x.Promotion).WithMany()
                .HasForeignKey(x => x.PromotionId).OnDelete(DeleteBehavior.Cascade).IsRequired();

            modelBuilder.Entity<DynamicContentItemEntity>().ToTable("DynamicContentItem");
            modelBuilder.Entity<DynamicContentItemEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<DynamicContentItemEntity>().Property(x => x.Id);
            modelBuilder.Entity<DynamicContentItemEntity>().HasOne(x => x.Folder).WithMany(x => x.ContentItems)
                .HasForeignKey(x => x.FolderId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DynamicContentPlaceEntity>().ToTable("DynamicContentPlace");
            modelBuilder.Entity<DynamicContentPlaceEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<DynamicContentPlaceEntity>().Property(x => x.Id);
            modelBuilder.Entity<DynamicContentPlaceEntity>().HasOne(x => x.Folder).WithMany(x => x.ContentPlaces)
                .HasForeignKey(x => x.FolderId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DynamicContentPublishingGroupEntity>().ToTable("DynamicContentPublishingGroup");
            modelBuilder.Entity<DynamicContentPublishingGroupEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<DynamicContentPublishingGroupEntity>().Property(x => x.Id);

            modelBuilder.Entity<PublishingGroupContentItemEntity>().ToTable("PublishingGroupContentItem");
            modelBuilder.Entity<PublishingGroupContentItemEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<PublishingGroupContentItemEntity>().Property(x => x.Id);
            modelBuilder.Entity<PublishingGroupContentItemEntity>().HasOne(p => p.ContentItem).WithMany()
                .HasForeignKey(x => x.DynamicContentItemId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PublishingGroupContentItemEntity>().HasOne(p => p.PublishingGroup)
                  .WithMany(x => x.ContentItems).HasForeignKey(x => x.DynamicContentPublishingGroupId)
                  .OnDelete(DeleteBehavior.Cascade).IsRequired();

            modelBuilder.Entity<PublishingGroupContentPlaceEntity>().ToTable("PublishingGroupContentPlace");
            modelBuilder.Entity<PublishingGroupContentPlaceEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<PublishingGroupContentPlaceEntity>().Property(x => x.Id);
            modelBuilder.Entity<PublishingGroupContentPlaceEntity>().HasOne(p => p.ContentPlace).WithMany()
                .HasForeignKey(x => x.DynamicContentPlaceId)
                .OnDelete(DeleteBehavior.Cascade).IsRequired();
            modelBuilder.Entity<PublishingGroupContentPlaceEntity>().HasOne(p => p.PublishingGroup)
               .WithMany(x => x.ContentPlaces).HasForeignKey(x => x.DynamicContentPublishingGroupId)
               .OnDelete(DeleteBehavior.Cascade).IsRequired();

            modelBuilder.Entity<DynamicContentFolderEntity>().ToTable("DynamicContentFolder");
            modelBuilder.Entity<DynamicContentFolderEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<DynamicContentFolderEntity>().Property(x => x.Id);

            modelBuilder.Entity<PromotionStoreEntity>().ToTable("PromotionStore");
            modelBuilder.Entity<PromotionStoreEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<PromotionStoreEntity>().Property(x => x.Id);
            modelBuilder.Entity<PromotionStoreEntity>().HasOne(x => x.Promotion)
                .WithMany(x => x.Stores).HasForeignKey(x => x.PromotionId)
                .OnDelete(DeleteBehavior.Cascade).IsRequired();
            modelBuilder.Entity<PromotionStoreEntity>().HasIndex(i => i.StoreId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
