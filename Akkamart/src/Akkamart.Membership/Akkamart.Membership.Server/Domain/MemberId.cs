using Akkatecture.Core;
using Newtonsoft.Json;
namespace Akkamart.Membership.Server.Domain {
    public class MemberId : Identity<MemberId> {
        public MemberId (string value) : base (value) { }
    }
}