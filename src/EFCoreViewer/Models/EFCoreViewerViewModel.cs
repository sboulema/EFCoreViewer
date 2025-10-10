using EFCoreViewer.Resources;
using Microsoft.VisualStudio.Extensibility.UI;
using System.Runtime.Serialization;

namespace EFCoreViewer.Models;

[DataContract]
public class EFCoreViewerViewModel : NotifyPropertyChangedObject
{
    private string _sql = string.Empty;

    [DataMember]
    public string SQL
    {
        get => _sql;
        set => SetProperty(ref _sql, value);
    }

    #region Labels
#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
    [DataMember]
    public string TabItemHeaderSQL => EFCoreViewerStrings.TabItemHeaderSQL;

    [DataMember]
    public string CheckBoxLabelWordWrap => EFCoreViewerStrings.CheckBoxLabelWordWrap;
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore IDE0079 // Remove unnecessary suppression
    #endregion
}
