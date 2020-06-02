using Stateless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veam.Common.Domain;

namespace Veam.Purchases.Domain
{
    public class PurchaseOrderStatus : ValueObject<PurchaseOrderStatus>
    {
        private StateMachine<State, Trigger> _machine;
        private State _state;

        public PurchaseOrderStatus()
        {
            ConfigureStateMachine();
        }

        public enum State
        {
            Draft,
            PendingApproval,
            Approved,
            Shipped,
            Delivered,
            Cancelled
        }

        public enum Trigger
        {
            PendingApproval,
            Approved,
            Shipped,
            Delivered,
            Cancelled
        }

        public bool IsStateBeforeApproved => CurrentState == State.Draft
                                             || CurrentState == State.PendingApproval;

        public State CurrentState
        {
            get => _machine.State;
            private set => ConfigureStateMachine(value);
        }

        public IEnumerable<Trigger> PermittedTriggers => _machine.PermittedTriggers;

        private void ConfigureStateMachine(State initialState = State.Draft)
        {
            _state = initialState;
            _machine = new StateMachine<State, Trigger>(
                () => _state,
                s => _state = s);

            _machine.Configure(State.Draft)
                .Permit(Trigger.PendingApproval, State.PendingApproval)
                .Permit(Trigger.Approved, State.Approved)
                .Permit(Trigger.Cancelled, State.Cancelled);

            _machine.Configure(State.PendingApproval)
                .Permit(Trigger.Approved, State.Approved)
                .Permit(Trigger.Cancelled, State.Cancelled);

            _machine.Configure(State.Approved)
                .Permit(Trigger.Shipped, State.Shipped)
                .Permit(Trigger.Cancelled, State.Cancelled);

            _machine.Configure(State.Shipped)
                .Permit(Trigger.Delivered, State.Delivered)
                .Permit(Trigger.Cancelled, State.Cancelled);
        }

        public void Fire(Trigger trigger)
        {
            _machine.Fire(trigger);
        }

        public override string ToString()
        {
            return _state.ToString();
        }

        protected  IEnumerable<object> GetAtomicValues()
        {
            yield return CurrentState;
        }
    }
  
}
