using System.Collections.Generic;
using System;

using RL.Core;

namespace RL.Environments
{
    public class GridWalkState : IState
    {
        private readonly ValueTuple<int, int> _position;
        private readonly bool _terminal;
        private string _content = " ";
        // readonly float Reward { get; private set; }
        public GridWalkState(ValueTuple<int, int> position, bool terminal/* , float reward */)
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
            return _content;
        }

        public void SetContent(string c)
        {
            _content = c;
        }
        public bool IsTerminal()
        {
            return _terminal;
        }
    }
}