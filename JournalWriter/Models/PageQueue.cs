using System;
using System.Collections.Generic;
using System.Text;
using JournalWriter.Views;

namespace JournalWriter.Models
{
    public class PageQueue
    {
        private List<Page> stack = new List<Page>();

        public void Push(Page p)
        {
            stack.Add(p);
        }
        public Page Pop()
        {
            return stack[stack.Count - 1];
        }
        public Page GetLastPage()
        {
            return stack[stack.Count - 1];
        }
    }
}
