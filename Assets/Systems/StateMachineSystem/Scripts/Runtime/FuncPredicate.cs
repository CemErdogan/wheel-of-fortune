using System;

namespace StateMachineSystem
{
    public class FuncPredicate : IPredicate
    {
        private readonly Func<bool> _condition;
        
        public FuncPredicate(Func<bool> condition)
        {
            _condition = condition;
        }
        
        public bool Evaluate()
        {
            return _condition.Invoke();
        }
    }
}