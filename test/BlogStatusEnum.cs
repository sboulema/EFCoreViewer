using System.Runtime.Serialization;

namespace EFCoreViewer.Test;

public enum BlogStatusEnum
{
    [EnumMember(Value = "UNKNOWN")]
    UNKNOWN = 0,

    [EnumMember(Value = "LIVE")]
    LIVE = 1,
}
