using System;
using System.Collections.Generic;
using System.Text;

namespace Batman_JR0LDJ
{
    class NotEnoughBudgetException : Exception
    {
        public NotEnoughBudgetException()
        {
        }
        public NotEnoughBudgetException(string message) : base(message)
        {
        }
    }
}
