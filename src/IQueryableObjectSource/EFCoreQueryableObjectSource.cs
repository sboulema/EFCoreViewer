using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.IO;
using System.Linq;

namespace IQueryableObjectSource;

public class EFCoreQueryableObjectSource : VisualizerObjectSource
{
    public override void GetData(object target, Stream outgoingData)
    {
        var result = Convert(target);
        SerializeAsJson(outgoingData, result);
    }

    private static EFCoreResult Convert(object target)
    {
        if (target is not IQueryable queryable)
        {
            return new();
        }

        try
        {
            return new()
            {
                SQL = queryable.ToQueryString(),
            };
        }
        catch (Exception e)
        {
            return new()
            {
                ErrorMessage = e.Message,
            };
        }
    }
}