namespace EFCoreViewer.Test.Shared;

public record Author
{
    public int AuthorId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
}
