using EFCoreViewer.Test;

using var db = new BloggingContext();

var queryById = db.Blogs
    .Where(blog => blog.BlogId == 12);

// Does it work with a Where Contains query ?
List<string> blogUrls = ["Test"];

var queryByName = db.Blogs
    .Where(blog => blogUrls.Contains(blog.Url));

System.Diagnostics.Debugger.Break();