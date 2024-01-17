using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;

namespace IWantApp.Endpoints;

public static class ProblemDetailsExtensions
{
    public static Dictionary<string, string[]> ConverToProblemDetails(this IReadOnlyCollection<Notification> notifications)
    {
        return notifications.GroupBy(g => g.Key).ToDictionary(g => g.Key, g => g.Select(X => X.Message).ToArray());
    }

    public static Dictionary<string, string[]> ConverToProblemDetails(this IEnumerable<IdentityError> error)
    {
        var dictionary = new Dictionary<string, string[]>();
        dictionary.Add("Errors", error.Select(e => e.Description).ToArray());
        return dictionary;
    }
}
