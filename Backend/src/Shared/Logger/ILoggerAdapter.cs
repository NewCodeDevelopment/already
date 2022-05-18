namespace Shared.Logger;

public interface ILoggerAdapter<T>
{
    // LogLevel Debug(2)
    void LogDebug(string message);
    void LogDebug<T0>(string message, T0 arg0);
    void LogDebug<T0, T1>(string message, T0 arg0, T1 arg1);
    void LogDebug<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);

    // LogLevel Information(2)
    void LogInformation(string message);
    void LogInformation<T0>(string message, T0 arg0);
    void LogInformation<T0, T1>(string message, T0 arg0, T1 arg1);
    void LogInformation<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);

    // LogLevel Warning(3)
    void LogWarning(string message);
    void LogWarning<T0>(string message, T0 arg0);
    void LogWarning<T0, T1>(string message, T0 arg0, T1 arg1);
    void LogWarning<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);

    // LogLevel Error(2)
    void LogError(string message);
    void LogError<T0>(string message, T0 arg0);
    void LogError<T0, T1>(string message, T0 arg0, T1 arg1);
    void LogError<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);

    // LogLevel Critical(1)
    void LogCritical(string message);
    void LogCritical<T0>(string message, T0 arg0);
    void LogCritical<T0, T1>(string message, T0 arg0, T1 arg1);
    void LogCritical<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);
}
