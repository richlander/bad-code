using System;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace BadCodeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // ERROR: Undefined variable
            Console.WriteLine(undefinedVariable);
            
            // WARNING: Unused variable
            int unusedNumber = 42;
            string unusedString = "never used";
            
            // ERROR: Type mismatch
            int wrongType = "This is a string, not an int";
            
            // WARNING: Deprecated method usage
            #pragma warning disable CS0618
            var oldMethod = ObsoleteMethod();
            #pragma warning restore CS0618
            
            // ERROR: Missing namespace/type
            var missingType = new NonExistentClass();
            
            // WARNING: Nullable reference warning
            string? nullableStr = null;
            Console.WriteLine(nullableStr.Length);
            
            // ERROR: Cannot convert type
            DoSomething("wrong parameter");
            
            // WARNING: Unreachable code
            return;
            Console.WriteLine("This will never execute");
        }
        
        [Obsolete("This method is obsolete")]
        static string ObsoleteMethod()
        {
            return "old";
        }
        
        static void DoSomething(int number)
        {
            Console.WriteLine(number);
        }
    }
    
    // ERROR: Missing implementation for abstract method (SIMPLIFIED)
    public abstract class BrokenClass
    {
        // Now it's abstract, but still problematic
        public abstract void DoSomething();
    }
    
    // WARNING: Field never assigned
    public class WarningClass
    {
        private string neverAssignedField;
        
        public void PrintField()
        {
            Console.WriteLine(neverAssignedField.ToUpper());
        }
    }
}
