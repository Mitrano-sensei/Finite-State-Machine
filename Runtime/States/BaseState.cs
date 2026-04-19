using System;
using UnityEngine;

namespace FiniteStateMachine
{
    [Serializable]
    public abstract class BaseState : IState
    {
        private string _name = "";
        public virtual string Name { get => _name.Length == 0 ? GetType().Name : _name; protected set => _name = value; }
        

        /**
         * Has to be called with the Update method of a StateMachine
         */
        public virtual void OnStateUpdate() { 
        
        }

        /**
         * Has to be called with the FixedUpdate method of a StateMachine
         */
        public virtual void OnStateFixedUpdate() { 
        
        }

        /**
         * Called when the state is exited
         */
        public virtual void OnExit() {
        
        }

        /**
         * Called when the state is entered
         */
        public virtual void OnEnter()
        {

        }

    }

}
