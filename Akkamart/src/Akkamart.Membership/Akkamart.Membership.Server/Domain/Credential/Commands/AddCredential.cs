using Akkamart.Membership.Server.Domain.Credential.ValueObjects;

namespace Akkamart.Membership.Server.Domain.Credential.Commands
{
    public class AddCredential
    {
        public Username Username { get; set; }
        public Password Password { get; set; }
        
    }
}