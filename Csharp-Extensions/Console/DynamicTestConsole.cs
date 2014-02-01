using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsExtensions.Console
{
    /// <summary>
    /// A dynamic method to list all
    /// <code>public static</code> methods 
    /// of the given classe. Those then can
    /// be executed by typing the corresponding
    /// number.<para />
    /// Use <code>Comment</code>-Attributes
    /// to write a comment to those methods.
    /// This makes the identification much easier.
    /// </summary>
    public static class DynamicTestConsole
    {
        /// <summary>
        /// Reads all <code>public static</code> methods
        /// of <code>T</code>, lists them and waits for
        /// the users input.
        /// </summary>
        /// <typeparam name="T">The class to be analyzed.
        /// Most likely the Program.cs, from which the
        /// Method is called.</typeparam>
        public static void Start<T>()
        {
            var methods = typeof(T).GetMethods(System.Reflection.BindingFlags.Static
                | System.Reflection.BindingFlags.Public);
            for (int i = 0; i < methods.Length; i++)
                if (methods[i].GetCustomAttributes(typeof(ObsoleteAttribute), false).Length == 0)
                    System.Console.WriteLine("{0,2}) {1} // {2}", i + 1, methods[i].Name,
                        ((Comment)methods[i].GetCustomAttributes(typeof(Comment), false)[0]).Message
                            ?? "No comment set.");

            int inp = 0;
            bool rl = int.TryParse(System.Console.ReadLine(), out inp);
            System.Console.WriteLine();
            if (rl && inp > 0 && inp <= methods.Length)
                methods[inp - 1].Invoke(null, null);
            else
                System.Console.WriteLine("Invalid input");

            System.Console.WriteLine();
            System.Console.WriteLine("<Enter> to restart.");
            System.Console.WriteLine("<ESC>   to exit.");
            if (System.Console.ReadKey().Key == ConsoleKey.Enter)
            {
                System.Console.Clear();
                Start<T>();
            }
            return;
        }

        /// <summary>
        /// Simple Comment-Attribute for use
        /// with the DynamicTestConsole.<para />
        /// For use, just put <code>[Comment("Your comment here")]</code>
        /// above the desired method. It then will be
        /// displayed in the list, given by DynamicTestConsole.Start&lt;T&gt;().
        /// </summary>
        [AttributeUsage(AttributeTargets.Method)]
        public sealed class Comment : Attribute
        {
            public string Message { get; set; }

            /// <summary>
            /// Create a comment.
            /// </summary>
            /// <param name="message">The message to be displayed.</param>
            public Comment(string message)
            {
                Message = message;
            }
        }
    }
}
