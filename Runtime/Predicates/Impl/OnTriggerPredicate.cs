using System;
using FiniteStateMachine;

namespace FiniteStateMachine
{
    public class OnTriggerPredicate : IPredicate
    {
        private bool _isTriggered;
        
        public OnTriggerPredicate(ref Action action)
        {
            action += () => _isTriggered = true;
        }
        
        public bool Evaluate()
        {
            if (_isTriggered)
            {
                _isTriggered = false;
                return true;
            }
            
            return false;
        }
    }
}