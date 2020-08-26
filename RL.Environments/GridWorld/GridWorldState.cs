using System.Collections.Generic;
using System;

using RL.Core;

namespace RL.Environments
{
    public class RandomWalkState : IState
    {
        private readonly Tuple<int, int> _position;
        private readonly bool _terminal;
        // readonly float Reward { get; private set; }
        public RandomWalkState(Tuple<int, int> position, bool terminal/* , float reward */)
        {
            // Reward = reward;
            _terminal = terminal;
            _position = position;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool IsTerminal()
        {
            return _terminal;
        }
    }
}