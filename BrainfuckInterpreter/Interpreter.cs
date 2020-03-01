using System;
using System.Collections.Generic;
using System.Text;

namespace BrainfuckInterpreter
{
    public class Interpreter
    {
        private List<int> _cells;
        private Stack<int> _stack;
        private int _index;

        public Interpreter()
        {
            _cells = new List<int>() { 0 };
            _stack = new Stack<int>();
            _index = 0;
        }

        public void Parse(string code)
        {
            int ci = 0;
            char cmd = ' ';

            while (ci < code.Length)
            {
                cmd = code[ci];

                switch (cmd)
                {
                    case '+': _cells[_index] += 1; ++ci; break;
                    case '-': _cells[_index] -= 1; ++ci; break;
                    case '<': ShiftLeft(); ++ci; break;
                    case '>': ShiftRight(); ++ci; break;
                    case '[': StartLoop(code, ref ci); ++ci; break;
                    case ']': EndOrRestartLoop(ref ci); break;
                    case '.': Console.Write((char)_cells[_index]); ++ci; break;
                }
            }
        }

        private void ShiftLeft()
        {
            if (_index == 0)
                _cells.Insert(0, 0);
            else
                --_index;
        }

        private void ShiftRight()
        {
            if (_index + 1 == _cells.Count)
            {
                _cells.Add(0);
                ++_index;
            }
            else
                _index += 1;
        }

        private void StartLoop(string code, ref int ci)
        {
            if (_cells[_index] == 0) 
                while (code[ci] != ']') ci += 1;

            else _stack.Push(ci);
        }

        private void EndOrRestartLoop(ref int ci)
        {
            ci = ((_cells[_index] == 0) ? ci + 1 : _stack.Pop());
        }
    }
}
