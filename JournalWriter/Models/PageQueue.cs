using System;
using System.Collections.Generic;
using System.Text;
using JournalWriter.Views;

namespace JournalWriter.Models
{
    public class PageQueue
    {
        private List<Page> stack;

        public PageQueue()
        {
            stack = new List<Page>();
        }

        public void Push(Page p)
        {
            stack.Add(p);
        }
        public Page Pop()
        {
            Page _p = stack[stack.Count - 1];

            stack.RemoveAt(stack.Count - 1);

            return _p;
        }
    }
}
