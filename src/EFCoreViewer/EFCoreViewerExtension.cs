using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Extensibility;

namespace EFCoreViewer;

[VisualStudioContribution]
internal class EFCoreViewerExtension : Extension
{
    /// <inheritdoc/>
    public override ExtensionConfiguration ExtensionConfiguration => new()
    {
        Metadata = new(
            id: "EFCoreViewer.b40a35c6-e71a-491e-b686-acabe4727c56",
            version: ExtensionAssemblyVersion,
            publisherName: "Samir Boulema",
            displayName: "EFCoreViewer",
            description: "Adds a debug visualizer to easily see the SQL query for an EF Core 3.1 query.")
        {
            MoreInfo = "https://github.com/sboulema/EFCoreViewer",
            ReleaseNotes = "https://github.com/sboulema/EFCoreViewer/releases",
            Tags = ["EF", "EFCore", "SQL", "Database"],
            // TODO: BUG? License file is missing
            //License = "Resources/License.txt",
            Icon = "Resources/Logo_90x90.png",
            PreviewImage = "Resources/Screenshot.png",
            InstallationTargetVersion = "[17.14,19.0)",
        },
    };

    /// <inheritdoc />
    protected override void InitializeServices(IServiceCollection serviceCollection)
    {
        base.InitializeServices(serviceCollection);

        // You can configure dependency injection here by adding services to the serviceCollection.
    }
}
