using System.Collections.Immutable;
using System.Security.Policy;

namespace Akkamart.Server.Shared.Client.Entity {
    public class History {
        public ImmutableList<HistoryItem> HistoryItems { get; set; }
        public void Add (HistoryItem item) {
            HistoryItems.Add (item);
        }
    }
}