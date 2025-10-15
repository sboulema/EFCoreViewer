using EFCoreViewer.Test.Shared;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreViewer.Test.Net48
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                // Does it work with a method-based query syntax?
                var queryById = db.Blogs
                    .Where(blog => blog.BlogId == 12);

                // Does it work with a Where Contains query?
                var blogUrls = new List<string>() { "Test" };

                var queryByName = db.Blogs
                    .Where(blog => blogUrls.Contains(blog.Url));

                // Does it work with a query expression syntax?
                var blogTypeIds = new List<int?> { 1, 2, 3, };

                IQueryable<Blog> GetBlogs() => db.Blogs.AsQueryable();

                var queryExpression = from b in GetBlogs()
                                      where blogTypeIds.Contains(b.TypeId)
                                      select b;

                // How does it handle an untranslatable query?
                var uniquePosts = new List<Post>();

                var queryInvalid = from b in db.Blogs
                                   where uniquePosts.Any(post => b.Posts.Contains(post))
                                   select b;

                System.Diagnostics.Debugger.Break();
            }
        }
    }
}
