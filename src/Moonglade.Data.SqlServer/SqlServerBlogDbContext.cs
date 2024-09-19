using Microsoft.EntityFrameworkCore;

using Moonglade.Data.SqlServer.Configurations;

namespace Moonglade.Data.SqlServer;


public class SqlServerBlogDbContext : BlogDbContext
{
    public SqlServerBlogDbContext()
    {
    }

    public SqlServerBlogDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new CommentReplyConfiguration());
        modelBuilder.ApplyConfiguration(new PostConfiguration());
        modelBuilder.ApplyConfiguration(new PostCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new LoginHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new MentionConfiguration());
        modelBuilder.ApplyConfiguration(new BlogThemeConfiguration());
        modelBuilder.ApplyConfiguration(new BlogAssetConfiguration());
        modelBuilder.ApplyConfiguration(new StyleSheetConfiguration());
        modelBuilder.ApplyConfiguration(new BlogConfigurationConfiguration());
        modelBuilder.ApplyConfiguration(new PageConfiguration());
        modelBuilder.ApplyConfiguration(new CalendarConfiguration());
        modelBuilder.ApplyConfiguration(new CertificateEntityConfiguration());
        modelBuilder.ApplyConfiguration(new HonoraryPositionConfiguration());
        modelBuilder.ApplyConfiguration(new MandateConfiguration());
        modelBuilder.ApplyConfiguration(new MembershipConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new PublicationConfiguration());
        modelBuilder.ApplyConfiguration(new TalkConfiguration());
        modelBuilder.ApplyConfiguration(new TestimonialConfiguration());
        modelBuilder.ApplyConfiguration(new VideoConfiguration());
        modelBuilder.ApplyConfiguration(new PagesContentConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
