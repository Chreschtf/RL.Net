using System.Collections.Generic;

namespace RL.Core
{
    public abstract class Environment
    {
        // public virtual State State {get; private set;}
        public abstract void Reset();
        public abstract void Step();
        public abstract void Render();
        public abstract List<int> GetLegalActions();
        // public abstract List<T> GetLegalActions<T>(List<T> legalActions);
        public abstract void RunTrajectory();

        public abstract bool IsTerminal();
    }
}
