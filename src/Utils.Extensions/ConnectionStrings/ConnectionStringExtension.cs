using System.Text.RegularExpressions;

namespace Utils.Extensions.ConnectionStrings
{
    public static class ConnectionStringExtension
    {
        public static string ExtractValueOfConnectionString(string connectionString, string matchCase)
        {
            if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(matchCase))
                return "";

            var match = Regex.Match(connectionString, @$"{matchCase}([A-Za-z0-9-_.@#$%¨!*()+]+)", RegexOptions.IgnoreCase);
            return match.Success ? match?.Groups[1]?.Value : "";
        }
    }
}
