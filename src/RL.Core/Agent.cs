using System.Collections.Generic;

namespace RL.Core
{
    public abstract class Agent
    {
        protected float _sumOfrewards;
        protected List<float> _sumOfRewardsHistory;
        public abstract int GetAction(IState state, List<int> legalActions);
        public virtual void AssignReward(int reward)
        {
            _sumOfrewards += reward;
            _sumOfRewardsHistory.Add(_sumOfrewards);
        }
        // public abstract int GetAction(IState state, int[] legalActions);
        // public abstract int[] GetAction(IState state, int[,] legalActions);
    }
}
