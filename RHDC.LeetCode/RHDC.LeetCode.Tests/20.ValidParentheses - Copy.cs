using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace RHDC.LeetCode.Tests
{
    [TestClass]
    public class ValidParentheses
    {
        [TestMethod]
        public void TestMethod1()
        {
            var s = "()";
            var result = IsValid(s);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var s = "()[]{}";
            var result = IsValid(s);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var s = "(]";
            var result = IsValid(s);
            Assert.AreEqual(false, result);
        }

        private bool IsValid(string s)
        {
            var stack = new Stack<char>();
            foreach (var c in s)
            {
                switch (c)
                {
                    case '(':
                    case '[':
                    case '{':
                        stack.Push(c);
                        break;

                    case ')':
                        if (stack.Count == 0)
                        {
                            return false;
                        }
                        else if (stack.Peek() == '(')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(c);
                        }
                        break;

                    case ']':
                        if (stack.Count == 0)
                        {
                            return false;
                        }
                        else if (stack.Peek() == '[')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(c);
                        }
                        break;

                    case '}':
                        if (stack.Count == 0)
                        {
                            return false;
                        }
                        else if (stack.Peek() == '{')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(c);
                        }
                        break;

                    default:
                        break;
                }
            }

            return stack.Count == 0;
        }
    }
}