using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace FiniteStateMachine
{
    [Serializable]
    public abstract class ExecutionState : BaseState
    {
        private bool _isCompleted = false;
        private bool _isRunning = false;
        private CancellationTokenSource _cts;

        public bool IsCompleted => _isCompleted;

        public override void OnEnter()
        {
            base.OnEnter();

            _isCompleted = false;
            _isRunning = true;

            _cts = new CancellationTokenSource();

            Run().Forget();
        }

        public override void OnExit()
        {
            base.OnExit();

            _isRunning = false;
            _isCompleted = false;

            if (_cts != null)
            {
                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }
        }

        /// <summary>
        /// Main template method that is called when the state is entered
        /// </summary>
        private async UniTaskVoid Run()
        {
            try
            {
                await Execute(_cts.Token);
                
                if (_isRunning) // évite de valider si on a quitté l'état
                {
                    _isCompleted = true;
                    OnExecutionCompleted();
                }
            }
            catch (OperationCanceledException)
            {
                // normal lors d'un OnExit
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogException(e);
            }
        }

        /// <summary>
        /// Override this method to implement the state logic
        /// </summary>
        protected abstract UniTask Execute(CancellationToken token);

        /// <summary>
        /// Optional hook called when the state is completed
        /// </summary>
        protected virtual void OnExecutionCompleted()
        {
        }
    }
}