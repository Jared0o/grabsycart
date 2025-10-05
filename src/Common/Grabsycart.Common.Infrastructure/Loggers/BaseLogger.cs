using Microsoft.Extensions.Logging;

namespace Grabsycart.Common.Infrastructure.Loggers;

public static partial class BaseLogger
{
    [LoggerMessage(EventId = 2, Level = LogLevel.Error, Message = "{msg}")]
    public static partial void LogBaseError(this ILogger logger, Exception ex, string msg);

}