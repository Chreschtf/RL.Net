using System.Collections.Generic;

namespace RL.Core
{
    public abstract class Agent
    {
        public abstract int[] GetAction(IState state, int[] legalActions);
    }
}
