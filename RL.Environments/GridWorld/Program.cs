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

            var e = new GridWorldEnvironment(5, 5, agent);
        }
    }
}
