namespace EFCoreViewer.Test;

public record Post
{
    public int PostId { get; init; }

    public string Title { get; init; } = string.Empty;

    public string Content { get; init; } = string.Empty;

    public int BlogId { get; init; }

    public required Blog Blog { get; init; }
}
