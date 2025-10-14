using EFCoreViewer.Test;

using var db = new BloggingContext();

// Does it work with a method-based query syntax?
var queryById = db.Blogs
    .Where(blog => blog.BlogId == 12);

// Does it work with a Where Contains query?
List<string> blogUrls = ["Test"];

var queryByName = db.Blogs
    .Where(blog => blogUrls.Contains(blog.Url));

// Does it work with a query expression syntax?
var blogTypeIds = new List<int?> { 1, 2, 3, };

IQueryable<Blog> GetBlogs() => db.Blogs.AsQueryable();

var queryExpression = from b in GetBlogs()
    where b.TypeId != null && blogTypeIds.Contains(b.TypeId) &&
          b.Posts.FirstOrDefault().Author.AuthorId != null &&
          b.Posts.FirstOrDefault().Author.FirstName == "John"
    where b.StatusId == (byte)BlogStatusEnum.LIVE
    select b;

// How does it handle an untranslatable query?
var uniquePosts = new List<Post>();

var queryInvalid = from b in db.Blogs
    where uniquePosts.Any(post => b.Posts.Contains(post))
    select b;

System.Diagnostics.Debugger.Break();