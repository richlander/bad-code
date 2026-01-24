using System;
using Newtonsoft.Json;

namespace BadCodeApp
{
    public class JsonProcessor
    {
        // ERROR: Invalid generic constraint (FIXED to show other errors)
        public T ProcessData<T>(string json) where T : class
        {
            // ERROR: Wrong method name (case sensitive)
            var obj = JsonConvert.deserializeObject<T>(json);
            
            // WARNING: Possible null reference
            return obj;
        }
        
        // ERROR: Duplicate method signature (RENAMED to allow compilation)
        public void Process(string data)
        {
            Console.WriteLine(data);
        }
        
        public void ProcessData(string data)
        {
            Console.WriteLine("Different: " + data);
        }
        
        // ERROR: Invalid array access
        public void ArrayError()
        {
            int[] numbers = new int[5];
            numbers[10] = 100; // Will compile but runtime error
            
            // ERROR: Cannot assign to read-only property
            var json = new { Name = "Test" };
            json.Name = "Changed";
        }
        
        // WARNING: Comparing value type to null
        public bool CheckNull(int value)
        {
            return value == null;
        }
    }
}
