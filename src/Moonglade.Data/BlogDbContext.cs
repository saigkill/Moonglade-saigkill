using Moonglade.Data.Entities;

namespace Moonglade.Data;

public class BlogDbContext : DbContext
{
    public BlogDbContext()
    {
    }

    public BlogDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<CategoryEntity> Category { get; set; }
    public virtual DbSet<CommentEntity> Comment { get; set; }
    public virtual DbSet<CommentReplyEntity> CommentReply { get; set; }
    public virtual DbSet<PostEntity> Post { get; set; }
    public virtual DbSet<PostCategoryEntity> PostCategory { get; set; }
    public virtual DbSet<PostTagEntity> PostTag { get; set; }
    public virtual DbSet<PostViewEntity> PostView { get; set; }
    public virtual DbSet<TagEntity> Tag { get; set; }
    public virtual DbSet<FriendLinkEntity> FriendLink { get; set; }
    public virtual DbSet<PageEntity> CustomPage { get; set; }
    public virtual DbSet<LoginHistoryEntity> LoginHistory { get; set; }
    public virtual DbSet<MentionEntity> Mention { get; set; }
    public virtual DbSet<BlogThemeEntity> BlogTheme { get; set; }
    public virtual DbSet<StyleSheetEntity> StyleSheet { get; set; }
    public virtual DbSet<BlogAssetEntity> BlogAsset { get; set; }
    public virtual DbSet<BlogConfigurationEntity> BlogConfiguration { get; set; }
    public virtual DbSet<CalendarEntity> Calendar { get; set; }
    public virtual DbSet<CertificateEntity> Certificate { get; set; }
    public virtual DbSet<HonoraryPositionEntity> HonoraryPosition { get; set; }
    public virtual DbSet<MandateEntity> Mandate { get; set; }
    public virtual DbSet<MembershipEntity> Membership { get; set; }
    public virtual DbSet<ProjectEntity> Project { get; set; }
    public virtual DbSet<PublicationEntity> Publication { get; set; }
    public virtual DbSet<TalkEntity> Talk { get; set; }
    public virtual DbSet<TestimonialEntity> Testimonial { get; set; }
    public virtual DbSet<VideoEntity> Video { get; set; }
    public virtual DbSet<PagesContentEntity> PagesContent { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new FriendLinkConfiguration());

        modelBuilder
            .Entity<PostEntity>()
            .HasMany(p => p.Tags)
            .WithMany(p => p.Posts)
            .UsingEntity<PostTagEntity>(
                j => j
                    .HasOne(pt => pt.Tag)
                    .WithMany()
                    .HasForeignKey(pt => pt.TagId),
                j => j
                    .HasOne(pt => pt.Post)
                    .WithMany()
                    .HasForeignKey(pt => pt.PostId));
    }

}

public static class BlogDbContextExtension
{
    public static async Task ClearAllData(this BlogDbContext context)
    {
        await context.PostView.ExecuteDeleteAsync();
        await context.PostTag.ExecuteDeleteAsync();
        await context.PostCategory.ExecuteDeleteAsync();
        await context.CommentReply.ExecuteDeleteAsync();
        await context.Category.ExecuteDeleteAsync();
        await context.Tag.ExecuteDeleteAsync();
        await context.Comment.ExecuteDeleteAsync();
        await context.FriendLink.ExecuteDeleteAsync();
        await context.Mention.ExecuteDeleteAsync();
        await context.Post.ExecuteDeleteAsync();
        await context.BlogConfiguration.ExecuteDeleteAsync();
        await context.BlogAsset.ExecuteDeleteAsync();
        await context.BlogTheme.ExecuteDeleteAsync();
        await context.StyleSheet.ExecuteDeleteAsync();
        await context.LoginHistory.ExecuteDeleteAsync();
        await context.Calendar.ExecuteDeleteAsync();
        await context.Certificate.ExecuteDeleteAsync();
        await context.HonoraryPosition.ExecuteDeleteAsync();
        await context.Mandate.ExecuteDeleteAsync();
        await context.Membership.ExecuteDeleteAsync();
        await context.Project.ExecuteDeleteAsync();
        await context.Publication.ExecuteDeleteAsync();
        await context.Talk.ExecuteDeleteAsync();
        await context.Testimonial.ExecuteDeleteAsync();
        await context.Video.ExecuteDeleteAsync();
        await context.PagesContent.ExecuteDeleteAsync();
    }
}
