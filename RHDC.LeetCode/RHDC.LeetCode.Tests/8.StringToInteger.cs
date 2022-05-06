using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace RHDC.LeetCode.Tests
{
    [TestClass]
    public class StringToInteger
    {
        [TestMethod]
        public void TestMethod1()
        {
            var s = "42";
            var result = MyAtoi(s);
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var s = "     -42";
            var result = MyAtoi(s);
            Assert.AreEqual(-42, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var s = "4193 with words";
            var result = MyAtoi(s);
            Assert.AreEqual(4193, result);
        }


        public int MyAtoi(string s)
        {
            var machine = new atoiStateMachine();
            for (var i = 0; i < s.Length && machine.getState() != atoiState.Exit; i++)
            {
                machine.doWork(s[i]);
            }

            return machine.getResult();
        }

    }

    public class atoiStateMachine
    {
        private atoiState _state;
        private int result, sign;

        public atoiStateMachine()
        {
            _state = atoiState.Start;
            result = 0;
            sign = 1;
        }

        public void doWork(char c)
        {
            if (_state == atoiState.Start)
            {
                if (c == ' ')
                {
                    return;
                }
                else if (c=='+' || c == '-')
                {
                    gotoSignState(c);
                }
                else if (Char.IsDigit(c))
                {
                    gotoIntegerState(c - '0');
                }
                else
                {
                    gotoExitState();
                }
            }
            else if (_state == atoiState.Integer || _state == atoiState.Sign)
            {
                if (char.IsDigit(c))
                {
                    gotoIntegerState(c - '0');
                }
                else
                {
                    gotoExitState();
                }
            }
        }

        private void gotoExitState()
        {
            _state = atoiState.Exit;
        }

        private void gotoIntegerState(int i)
        {
            _state = atoiState.Integer;
            appendDigit(i);
        }

        private void appendDigit(int i)
        {
             if ((result > Int32.MaxValue / 10 ) || (result == Int32.MaxValue / 10 && i > Int32.MaxValue % 10)) {
                if (sign == 1)
                {
                    result = int.MaxValue;
                }
                else
                {
                    result = int.MinValue;
                    sign = 1;
                }

                gotoExitState();
             }
             else
             {
                 result = result * 10 + i;
             }
        }

        private void gotoSignState(char c)
        {
            sign = (c == '+') ? 1 : -1;
            _state = atoiState.Sign;
        }

        internal atoiState getState()
        {
            return _state;
        }

        internal int getResult()
        {
            return result * sign;
        }
    }

    enum atoiState
    {
        Start,
        Integer,
        Sign,
        Exit
    }
}