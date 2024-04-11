using BlogWeb.Data;
using BlogWeb.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogWeb.Repositories
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly BlogDbContext BlogDbContext;

        public BlogPostCommentRepository(BlogDbContext BlogDbContext)
        {
            this.BlogDbContext = BlogDbContext;
        }

        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
            await BlogDbContext.BlogPostComment.AddAsync(blogPostComment);
            await BlogDbContext.SaveChangesAsync();
            return blogPostComment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId)
        {
            return await BlogDbContext.BlogPostComment.Where(x => x.BlogPostId == blogPostId)
                .ToListAsync();
        }
    }
}
