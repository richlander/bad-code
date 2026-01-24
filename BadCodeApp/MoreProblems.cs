using System;
using System.Collections.Generic;

namespace BadCodeApp
{
    public class MoreProblems
    {
        // WARNING: Unused event
        public event EventHandler UnusedEvent;
        
        // WARNING: Method can be made static
        public int CalculateSum(int a, int b)
        {
            return a + b;
        }
        
        // ERROR: Division by zero
        public void DivideNumbers()
        {
            int result = 100 / 0;
        }
        
        // WARNING: Async method lacks await
        public async System.Threading.Tasks.Task<string> GetDataAsync()
        {
            return "No await here";
        }
        
        // ERROR: Invalid cast
        public void CastError()
        {
            object obj = "string";
            int number = (int)obj;
        }
        
        // WARNING: Empty catch block
        public void EmptyCatch()
        {
            try
            {
                throw new Exception("test");
            }
            catch
            {
                // Empty catch - warning
            }
        }
        
        // ERROR: Ambiguous reference
        public void UseList()
        {
            var list = new List<string>();
            list.Add(123); // Wrong type
        }
    }
}
