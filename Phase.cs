using System;

namespace CardGame
{
    public class Phase
    {
        private State _state;

        public void NextPhase()
        {
            _state.NextPhase(this);
        }

        public void SetState(State state)
        {
            _state = state;
        }

        public void Preparation()
        {
            _state.Preparation(this);
        }

        public void Drawing()
        {
            _state.Drawing(this);
        }

        public void MainPhase()
        {
            _state.MainPhase(this);
        }

        public void Attacking()
        {
            _state.Attacking(this);
        }

        public void Ending()
        {
            _state.Ending(this);
        }
    }

    public abstract class State
    {
        public abstract void NextPhase(Phase phase);
        public abstract void Preparation(Phase phase);
        public abstract void Drawing(Phase phase);
        public abstract void MainPhase(Phase phase);
        public abstract void Attacking(Phase phase);
        public abstract void Ending(Phase phase);
    }
}
