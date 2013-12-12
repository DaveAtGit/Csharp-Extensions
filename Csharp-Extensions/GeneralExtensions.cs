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

        /// <summary>
        /// Returns a string for pretty-printing.
        /// Consists of classname, fields and properties.
        /// </summary>
        /// <typeparam name="T">The object's type.</typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>Pretty string for output with public info about object.</returns>
        public static string GetInfoString<T>(this T obj) where T : new()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(typeof(T).Name + " {");

            int widthConst = 0;

            var fields = typeof(T).GetFields(System.Reflection.BindingFlags.Public);
            var props = typeof(T).GetProperties();

            if (fields.Length > 0)
                widthConst = fields.Max(f => f.Name.Length);
            if (props.Length > 0)
                widthConst = Math.Max(widthConst, props.Max(p => p.Name.Length));

            if (fields.Length > 0)
            {
                sb.AppendLine("  Fields:");
                foreach (var field in fields)
                    sb.AppendLine("\t" + field.Name.PadRight(widthConst) + " : " + field.GetValue(obj));
            }
            if (props.Length > 0)
            {
                sb.AppendLine("  Properties:");
                foreach (var prop in props)
                    sb.AppendLine("\t" + prop.Name.PadRight(widthConst) + " : " + prop.GetValue(obj, null));
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
