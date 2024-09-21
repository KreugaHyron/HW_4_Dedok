using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_Dedok
{
    public static class StringExtensions
    {
        public static bool AreBracketsValid(this string str)
        {
            var stack = new Stack<char>();
            var brackets = new Dictionary<char, char>
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' }
        };

            foreach (var ch in str)
            {
                if (brackets.ContainsKey(ch))
                {
                    stack.Push(ch);
                }
                else if (brackets.ContainsValue(ch))
                {
                    if (stack.Count == 0 || brackets[stack.Pop()] != ch)
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}
