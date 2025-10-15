using EFCoreViewer.Windows;
using IQueryableObjectSource;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.DebuggerVisualizers;
using Microsoft.VisualStudio.RpcContracts.RemoteUI;
using System.Threading;
using System.Threading.Tasks;

namespace EFCoreViewer;

[VisualStudioContribution]
internal class EFCoreDebuggerVisualizerProvider : DebuggerVisualizerProvider
{
    private const string EntityQueryable = "Microsoft.EntityFrameworkCore.Query.Internal.EntityQueryable`1, Microsoft.EntityFrameworkCore, Version=0.0.0.0, Culture=neutral";
    private const string IncludableQueryable = "Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions+IncludableQueryable`2, Microsoft.EntityFrameworkCore, Version=0.0.0.0, Culture=neutral";
    private const string DisplayName = "EFCoreViewer.EFCoreDebuggerVisualizerProvider.DisplayName";

    /// <inheritdoc/>
    public override DebuggerVisualizerProviderConfiguration DebuggerVisualizerProviderConfiguration => new(
        new VisualizerTargetType($"%{DisplayName}%", EntityQueryable),
        new VisualizerTargetType($"%{DisplayName}%", IncludableQueryable))
    {
        VisualizerObjectSourceType = new(typeof(EFCoreQueryableObjectSource)),
    };

    /// <inheritdoc/>
    public override async Task<IRemoteUserControl> CreateVisualizerAsync(VisualizerTarget visualizerTarget, CancellationToken cancellationToken)
    {
        var result = await visualizerTarget.ObjectSource.RequestDataAsync<EFCoreResult>(jsonSerializer: null, cancellationToken);

        return new EFCoreViewerUserControl(new()
        {
            SQL = !string.IsNullOrEmpty(result.ErrorMessage)
                ? result.ErrorMessage
                : result.SQL,
        });
    }
}
