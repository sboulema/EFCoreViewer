using EFCoreViewer.Models;
using Microsoft.VisualStudio.Extensibility.UI;

namespace EFCoreViewer.Windows;

internal class EFCoreViewerUserControl(EFCoreViewerViewModel dataContext) : RemoteUserControl(dataContext)
{
}
