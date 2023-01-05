﻿using Flunt.Notifications;
using System.Runtime.CompilerServices;

namespace IWantAPI.Endpoints;

public static class ProblemDetailsExtensions
{
    public static Dictionary<string, string[]> ConvertToProblemDetails(this IReadOnlyCollection<Notification> notifications)
    {
        return notifications
                .GroupBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Select(x => x.Message)
                .ToArray());
    }
}