namespace EFCoreViewer.Test;

public record Blog
{
    public int BlogId { get; init; }

    public string Url { get; init; } = string.Empty;

    public List<Post> Posts { get; } = [];
}
