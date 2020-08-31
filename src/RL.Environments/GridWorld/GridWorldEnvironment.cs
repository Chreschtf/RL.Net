using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using RL.Core;

namespace RL.Environments
{
    public class GridWorldEnvironment : RL.Core.Environment
    {
        private GridWalkState[,] _grid;
        private readonly int _xDim;
        private readonly int _yDim;
        private readonly List<int> _legalActions;

        Agent Agent;
        private ValueTuple<int, int> _currentPosition;

        private int _step;

        public GridWorldEnvironment(int x_dim, int y_dim)
        {
            _grid = new GridWalkState[x_dim, y_dim];
            _xDim = x_dim;
            _yDim = y_dim;
            for (int i = 0; i < _xDim; i++)
            {
                for (int j = 0; j < y_dim; j++)
                {
                    _grid[i, j] = new GridWalkState(new ValueTuple<int, int>(i, j), false);
                }
            }

            // by default, terminal stage is opposite end of the grid
            _grid[x_dim - 1, y_dim - 1] = new GridWalkState(new ValueTuple<int, int>(x_dim - 1, y_dim - 1), true);

            _currentPosition = new ValueTuple<int, int>(0, 0);
            _grid[_currentPosition.Item1, _currentPosition.Item2].SetContent("x");

            // move top, bot, left, right
            _legalActions = new List<int>() { 0, 1, 2, 3 };
            _step = 0;
        }

        public void SetAgent(Agent agent)
        {
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

        public override List<int> GetLegalActions()
        {
            return _legalActions;
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
            var CurrentState = _grid[_currentPosition.Item1, _currentPosition.Item2];

            while (!CurrentState.IsTerminal())
            {
                List<int> legalActions = GetLegalActions();
                var chosenAction = Agent.GetAction(CurrentState, legalActions);
                var reward = ApplyAction(chosenAction);
                Agent.AssignReward(reward);
                CurrentState = _grid[_currentPosition.Item1, _currentPosition.Item2];
            }
        }

        private int ApplyAction(int action)
        {
            // System.Runtime.Contracts.Requires(_legalActions.)
            // Contract.Requires<InvalidOperationException>(_legalActions.Contains(action), $"Specified invalid moving direction {action}");
            _grid[_currentPosition.Item1, _currentPosition.Item2].SetContent(" ");
            switch (action)
            {
                case 0: // up
                    _currentPosition.Item1 = Math.Max(_currentPosition.Item1 - 1, 0);
                    break;
                case 1: //  down
                    _currentPosition.Item1 = Math.Min(_currentPosition.Item1 + 1, _xDim - 1);
                    break;
                case 2: // left 
                    _currentPosition.Item2 = Math.Max(_currentPosition.Item2 - 1, 0);
                    break;
                case 3: //  right
                    _currentPosition.Item2 = Math.Min(_currentPosition.Item2 + 1, _yDim - 1);
                    break;
                    // default:
                    //     throw new InvalidOperationException($"Specified invalid moving direction {action}");

            }
            _grid[_currentPosition.Item1, _currentPosition.Item2].SetContent("x");
            _step += 1;
            DisplayGrid();
            if (_grid[_currentPosition.Item1, _currentPosition.Item2].IsTerminal())
            {
                return 1;
            }
            return -1;
        }

        private void DisplayGrid()
        {
            Console.WriteLine($"======= Step {_step} =======");
            for (int i = 0; i < _xDim; i++)
            {
                Console.Write("|");
                for (int j = 0; j < _yDim; j++)
                {
                    Console.Write(_grid[i, j] + "|");
                }
                Console.WriteLine();
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
