
using Akkamart.Server.Shared.Client.ValueObjects;
namespace Akkamart.Server.Shared.Client.Entity
{
    public class HistoryItem
    {
        public Url Url { get; set; }
        public VisitingDateTime VisitDateTime { get; set; }
    }
}