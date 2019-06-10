using System;
using Akka.Actor;
using Akka.Event;
using Akkamart.Membership.Server.Domain.Credential.Commands;
using Akkamart.Membership.Server.Domain.Credential.ValueObjects;
using Akkamart.Membership.Server.Domain.Events;
using Akkamart.Membership.Server.Domain.ValueObjects;
using Akkatecture.Aggregates;
using Akkatecture.Specifications.Provided;

namespace Akkamart.Membership.Server.Domain
{
     
    public class MemberActor : AggregateRoot<MemberActor, MemberId, MemberState>
    {

        private readonly ILoggingAdapter _logger = Context.GetLogger();
        public IActorRef _CredentialActorRef { get; private set; }
        public MemberActor(MemberId id) : base(id)
        {
            Command<CreateMemberCommand>(Execute);
            Command<GetMemberbyIdCommand>(Execute);
            //Command<RequestNewCredential> (Execute);
            Command<AddCredential>(Execute);
            Command<GenerateVerificationCode>(Execute);
            Command<VerifyMemberCommand>(Execute);
            
        }

        private bool Execute(GenerateVerificationCode obj)
        {
             VerificationCode verificationcode = new VerificationCode((GenerateRandomNo().ToString()));

            var aggregateEvent =
                new VerificationCodeRequestedEvent(verificationcode, this.State.Mobilenumber);
            Emit(aggregateEvent);

            return true;
        }

        private bool Execute(CreateMemberCommand command)
        {
            //this spec is part of Akkatecture
            var spec = new AggregateIsNewSpecification();
            if (spec.IsSatisfiedBy(this))
            {
                var aggregateEvent =
                    new MemberCreatedEvent(new MobileNumber(command.Mobilenumber), this.Id);
                Emit(aggregateEvent);
                Sender.Tell(aggregateEvent);
                return true;
            }

            return false;
        }
        private bool Execute(GetMemberbyIdCommand cmd)
        {
            var response = new MemberStateResponse(this.State);
            Sender.Tell(response);
            return true;
        }

        // private bool Execute (RequestNewCredential cmd) {
        //     if (!this.IsNew) {
        //         var credentialId = CredentialId.NewDeterministic (CredentialNamespace.Instance, $"{cmd.Username}{cmd.Password}");

        //         var credentialManager = Context.ActorOf (Props.Create<CredentialManager> ());
        //         credentialManager.Tell (new StoreCredential (credentialId, cmd.Username,
        //             cmd.Password,
        //             cmd.MemberId));

        //         Emit (new CredentialRequested (cmd.MemberId, credentialId));
        //         return true;

        //     } else
        //         return false;

        // }
      
        private bool Execute(VerifyMemberCommand cmd)
        {
            if (this.State.VerificationCode.Value == cmd.Code)
            {
                var @event = new MemberVerifiedEvent(true, Id);
                Emit(@event);
                Sender.Tell(new MemberVerificationResponse(true, Id));
                return true;
            }
            else
            {
                Sender.Tell(new MemberVerificationResponse(false, Id));
                return false;
            }

        }
        private bool Execute(AddCredential cmd)
        {
            var @event =
                new MemberAddCredentialEvent(this.Id, cmd.Username, cmd.Password);
            Emit(@event);

            return true;
        }








        private int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
    }
}