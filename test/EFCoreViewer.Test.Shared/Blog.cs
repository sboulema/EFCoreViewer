namespace EFCoreViewer.Test.Shared;

public record Blog
{
    public int BlogId { get; set; }

    public int? TypeId { get; set; }

    public byte StatusId { get; set; }

    public string Url { get; set; } = string.Empty;

    public List<Post> Posts { get; } = [];
}
