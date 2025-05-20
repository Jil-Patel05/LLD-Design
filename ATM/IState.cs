using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.ATM
{
    public enum STATE_TYPE
    {
        IDLE_STATE,
        HAS_CARD,
        SELECT_TRANSACTION,
        PROCESS_TRANSACTION
    }
    public interface IState
    {
        public string getStateName();
        public IState getNextState();// Pass ATMMachine object reference to here
    }
    public class Factory
    {
        public static IState getState(STATE_TYPE type)
        {
            switch (type)
            {
                case STATE_TYPE.IDLE_STATE:
                    return new IdleState();
                case STATE_TYPE.HAS_CARD:
                    return new HasCard();
                case STATE_TYPE.SELECT_TRANSACTION:
                    return new SelectTransaction();
                case STATE_TYPE.PROCESS_TRANSACTION:
                    return new ProcessTransaction();
                default:
                    return new NullObject();
            }
        }
    }
    public class NullObject : IState
    {
        public IState getNextState()
        {
            return Factory.getState(STATE_TYPE.IDLE_STATE);
        }

        public string getStateName()
        {
            return "Null object";
        }

    }
    public class IdleState : IState
    {
        public IState getNextState()
        {
            return Factory.getState(STATE_TYPE.HAS_CARD);
        }

        public string getStateName()
        {
            return "Idle state";
        }
    }
    public class HasCard : IState
    {
        public IState getNextState()
        {
            return Factory.getState(STATE_TYPE.SELECT_TRANSACTION);
        }

        public string getStateName()
        {
            return "Has card";
        }
    }
    public class SelectTransaction : IState
    {
        public IState getNextState()
        {
            return Factory.getState(STATE_TYPE.PROCESS_TRANSACTION);
        }

        public string getStateName()
        {
            return "Select transaction";
        }
    }
    public class ProcessTransaction : IState
    {
        public IState getNextState()
        {
            return Factory.getState(STATE_TYPE.IDLE_STATE);
        }

        public string getStateName()
        {
            return "Process transaction";
        }
    }
}