using System;
using RL.Core;

namespace RL.Environments
{
    public class GridWorldEnvironment : RL.Core.Environment
    {
        private RandomWalkState[,] _grid;
        private readonly int _x_dim;
        private readonly int _y_dim;
        private readonly int[] _legal_actions;

        Agent Agent;
        private Tuple<int, int> _current_position;

        public GridWorldEnvironment(int x_dim, int y_dim, Agent agent)
        {
            _grid = new RandomWalkState[x_dim, y_dim];
            _x_dim = x_dim;
            _y_dim = y_dim;
            for (int i = 0; i < _x_dim; i++)
            {
                for (int j = 0; j < y_dim; j++)
                {
                    _grid[i, j] = new RandomWalkState(new Tuple<int, int>(i, j), false);
                }
            }

            _grid[x_dim - 1, y_dim - 1] = new RandomWalkState(new Tuple<int, int>(x_dim - 1, y_dim - 1), true);

            _current_position = new Tuple<int, int>(0, 0);

            // top, bot, left, right
            _legal_actions = new int[] { 0, 1, 2, 3 };

            Agent = agent;

        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool IsTerminal()
        {
            throw new NotImplementedException();
        }

        public override int[] GetLegalActions(Agent agent)
        {
            return _legal_actions;
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }

        public override void Reset()
        {

        }

        public override void RunTrajectory()
        {
            var CurrentState = _grid[_current_position.Item1, _current_position.Item2];

            while (!CurrentState.IsTerminal())
            {


            }
        }

        public override void Step()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
