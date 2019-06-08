using Akkamart.Membership.Server.Domain.User.ValueObjects;

namespace Akkamart.Membership.Server.Domain.Credential.Commands
{
    public class GenerateVerificationCode
    {
        public Username Username { get; set; }
        
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}