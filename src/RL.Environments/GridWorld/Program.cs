using System;
using RL.Core;
using RL.Agents;

namespace RL.Environments
{
    class Program
    {
        static void Main(string[] args)
        {
            var agent = new RandomAgent();

            var e = new GridWorldEnvironment(2, 2);
            e.SetAgent(agent);
            e.RunTrajectory();
        }
    }
}
