using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsExtensions
{
    public static class GeneralExtensions
    {
        /// <summary>
        /// Easy and save method to raise
        /// an event. Encapsules the null-check.
        /// </summary>
        /// <typeparam name="T">EventArgs-type</typeparam>
        /// <param name="handler">The event itself.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="ev">The EventArgs.</param>
        public static void Raise<T>(this EventHandler<T> handler, object sender, T ev) where T : EventArgs
        {
            if (handler != null)
                handler.Invoke(sender, ev);
        }
    }
}
