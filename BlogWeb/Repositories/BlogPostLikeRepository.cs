using BlogWeb.Data;
using BlogWeb.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogWeb.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BlogDbContext BlogDbContext;

        public BlogPostLikeRepository(BlogDbContext BlogDbContext)
        {
            this.BlogDbContext = BlogDbContext;
        }

        public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
        {
            await BlogDbContext.BlogPostLike.AddAsync(blogPostLike);
            await BlogDbContext.SaveChangesAsync();
            return blogPostLike;
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            return await BlogDbContext.BlogPostLike.Where(x => x.BlogPostId == blogPostId)
                .ToListAsync();
        }

        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
            return await BlogDbContext.BlogPostLike
                .CountAsync(x => x.BlogPostId == blogPostId);
        }
    }
}
