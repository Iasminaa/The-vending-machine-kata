using System.Globalization;

namespace VendingMachine
{
    public static class Money
    {
        private static readonly Dictionary<decimal, string> coins = new()
        {
            { 0.01m, "1p" },
            { 0.02m,"2p" },
            { 0.05m, "5p"},
            { 0.1m, "10p"},
            { 0.2m, "20p"},
            { 0.5m, "50p" },
            { 1m, "£1" },
            { 2m, "£2" }
        };

        public static bool IsValid(decimal money) => coins.TryGetValue(money, out _);
        public static string Format(decimal money) => money.ToString("C", new CultureInfo("en-GB"));
    }
}
