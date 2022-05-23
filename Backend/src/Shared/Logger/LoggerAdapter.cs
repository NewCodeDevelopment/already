using Microsoft.Extensions.Logging;

namespace Shared.Logger;

public class LoggerAdapter<T> : ILoggerAdapter<T>, IDisposable
{
    private ILogger<T> _logger;

    public LoggerAdapter(ILogger<T> logger)
    {
        _logger = logger;
    }


    // LogLevel Debug(2)
    public void LogDebug(string message)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug(message);
        }
    }

    public void LogDebug<T0>(string message, T0 arg0)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug(message, arg0);
        }
    }

    public void LogDebug<T0, T1>(string message, T0 arg0, T1 arg1)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug(message, arg0, arg1);
        }
    }

    public void LogDebug<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug(message, arg0, arg1, arg2);
        }
    }


    // LogLevel Information(2)
    public void LogInformation(string message)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation(message);
        }
    }

    public void LogInformation<T0>(string message, T0 arg0)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation(message, arg0);
        }
    }

    public void LogInformation<T0, T1>(string message, T0 arg0, T1 arg1)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation(message, arg0, arg1);
        }
    }

    public void LogInformation<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation(message, arg0, arg1, arg2);
        }
    }


    // LogLevel Warning(3)
    public void LogWarning(string message)
    {
        if (_logger.IsEnabled(LogLevel.Warning))
        {
            _logger.LogWarning(message);
        }
    }

    public void LogWarning<T0>(string message, T0 arg0)
    {
        if (_logger.IsEnabled(LogLevel.Warning))
        {
            _logger.LogWarning(message, arg0);
        }
    }

    public void LogWarning<T0, T1>(string message, T0 arg0, T1 arg1)
    {
        if (_logger.IsEnabled(LogLevel.Warning))
        {
            _logger.LogWarning(message, arg0, arg1);
        }
    }

    public void LogWarning<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2)
    {
        if (_logger.IsEnabled(LogLevel.Warning))
        {
            _logger.LogWarning(message, arg0, arg1, arg2);
        }
    }


    // LogLevel Error(2)
    public void LogError(string message)
    {
        if (_logger.IsEnabled(LogLevel.Error))
        {
            _logger.LogError(message);
        }
    }

    public void LogError<T0>(string message, T0 arg0)
    {
        if (_logger.IsEnabled(LogLevel.Error))
        {
            _logger.LogError(message, arg0);
        }
    }

    public void LogError<T0, T1>(string message, T0 arg0, T1 arg1)
    {
        if (_logger.IsEnabled(LogLevel.Error))
        {
            _logger.LogError(message, arg0, arg1);
        }
    }

    public void LogError<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2)
    {
        if (_logger.IsEnabled(LogLevel.Error))
        {
            _logger.LogError(message, arg0, arg1, arg2);
        }
    }


    // LogLevel Critical(1)
    public void LogCritical(string message)
    {
        if (_logger.IsEnabled(LogLevel.Critical))
        {
            _logger.LogCritical(message);
        }
    }

    public void LogCritical<T0>(string message, T0 arg0)
    {
        if (_logger.IsEnabled(LogLevel.Critical))
        {
            _logger.LogCritical(message, arg0);
        }
    }

    public void LogCritical<T0, T1>(string message, T0 arg0, T1 arg1)
    {
        if (_logger.IsEnabled(LogLevel.Critical))
        {
            _logger.LogCritical(message, arg0, arg1);
        }
    }

    public void LogCritical<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2)
    {
        if (_logger.IsEnabled(LogLevel.Critical))
        {
            _logger.LogCritical(message, arg0, arg1, arg2);
        }
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
