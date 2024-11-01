using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiniteStateMachine
{
    public interface IState
    {
        string Name { get; }

        void OnEnter();
        
        /**
         * Called on stateMachine.Update
         * Note : Is not called "Update" so IState & MonoBehaviours works together
         */
        void OnStateUpdate();
        
        /**
         * Called on stateMachine.FixedUpdate
         */
        void OnStateFixedUpdate();
        void OnExit();
    }

}
