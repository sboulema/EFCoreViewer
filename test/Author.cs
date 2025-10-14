namespace EFCoreViewer.Test;

public record Author
{
    public int AuthorId { get; init; }

    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;
}
