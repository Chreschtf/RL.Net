using System;
using System.Collections.Generic;
using RL.Core;

namespace RL.Agents
{
    public class RandomAgent : Agent
    {
        public RandomAgent()
        {
            _sumOfrewards = 0;
            _sumOfRewardsHistory = new List<float>() { _sumOfrewards };
        }

        public override int GetAction(IState state, List<int> legalActions)
        {
            var rand = new Random();
            int index = rand.Next(legalActions.Count);
            return legalActions[index];
        }

        // public override void AssignReward(int reward)
        // {

        // }
    }
}
