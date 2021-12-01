using System;
using System.Collections.Generic;
using System.Text;
using JournalWriter.Views;
using JournalWriter.Controllers;

namespace JournalWriter.Models
{

    public class PageQueue
    {
        public int StackCount { get { return stack.Count; } }

        private List<Page> stack;

        public PageQueue()
        {
            stack = new List<Page>();
            //stack.Add(new Page("EmptyPage", InitializeDisplay.ForegroundColor));
        }

        public void Push(Page p)
        {
            stack.Add(p);
        }
        public Page Pop()
        {
            Page page = stack[stack.Count - 1]; ;

            stack.RemoveAt(stack.Count - 1);

            return page;
        }
        public Page GetTop()
        {
            if (stack.Count > 0)
            {
                return stack[stack.Count - 1];
            }
            else
            {
                return null; 
            }
        }
    }
}
