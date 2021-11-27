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
            stack.Add(new Page("EmptyPage"));
        }

        public void Push(Page p)
        {
            stack.Add(p);
        }
        public Page Pop()
        {

            stack.RemoveAt(stack.Count - 1);

            return stack[stack.Count - 1];
        }
        public Page GetTop()
        {
            return stack[stack.Count - 1];
        }
    }
}
