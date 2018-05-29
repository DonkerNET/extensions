using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;

namespace Donker.Extensions.ExtensionMethods.AssemblyExtensions
{
    public static partial class AssemblyExtensions
    {
        /// <summary>
        /// Retrieves the version of the .NET framework.
        /// </summary>
        /// <param name="assembly">The assembly to retrieve the .NET version for.</param>
        /// <returns>The version as a <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">The assembly is null.</exception>
        public static string GetFrameworkVersion(this Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException("assembly", "The assembly cannot be null.");

            object[] frameworkAttributes = assembly.GetCustomAttributes(typeof(TargetFrameworkAttribute), false);

            string frameworkVersion = frameworkAttributes
                .OfType<TargetFrameworkAttribute>()
                .Select(f => f.FrameworkName.Split(new[] { "Version=v" }, StringSplitOptions.None).LastOrDefault())
                .FirstOrDefault();

            return frameworkVersion;
        }
    }
}