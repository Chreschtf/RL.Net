using System;
using RL.Core;

namespace RL.Agents
{
    public class RandomAgent : Agent
    {
        public RandomAgent()
        {

        }

        public override int[] GetAction(IState state, int[] legalActions)
        {

            return new int[] { 1 };
        }
    }
}
