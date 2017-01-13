using System;
using System.Linq;
using System.Reflection;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class GenericExtensions
    {
        /// <summary>
        /// Checks if the object's type has a custom attribute specified.
        /// </summary>
        /// <typeparam name="TObject">The type of the object to check.</typeparam>
        /// <typeparam name="TAttribute">The type of the <see cref="Attribute"/> to find.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <param name="inherit">If <value>true</value>, specifies that inherited attributes should also be accounted for.</param>
        /// <returns><value>true</value> if the attribute was found; otherwise, <value>false</value>.</returns>
        public static bool HasAttribute<TObject, TAttribute>(this TObject obj, bool inherit)
            where TAttribute : Attribute
        {
            Type objectType = typeof(TObject);
            object[] attributes = objectType.GetCustomAttributes(inherit);
            return attributes.Any(attribute => attribute is TAttribute);
        }

        /// <summary>
        /// Checks if the object's type has a custom attribute specified. Also searches for inherited attributes.
        /// </summary>
        /// <typeparam name="TObject">The type of the object to check.</typeparam>
        /// <typeparam name="TAttribute">The type of the <see cref="Attribute"/> to find.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <returns><value>true</value> if the attribute was found; otherwise, <value>false</value>.</returns>
        public static bool HasAttribute<TObject, TAttribute>(this TObject obj)
            where TAttribute : Attribute
        {
            return HasAttribute<TObject, TAttribute>(obj, true);
        }

        /// <summary>
        /// Checks if the object's type has a custom attribute specified.
        /// </summary>
        /// <typeparam name="TObject">The type of the object to check.</typeparam>
        /// <typeparam name="TAttribute">The type of the <see cref="Attribute"/> to find.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <param name="attribute">The attribute to find.</param>
        /// <param name="inherit">If <value>true</value>, specifies that inherited attributes should also be accounted for.</param>
        /// <returns><value>true</value> if the attribute was found; otherwise, <value>false</value>.</returns>
        public static bool HasAttribute<TObject, TAttribute>(this TObject obj, TAttribute attribute, bool inherit)
            where TAttribute : Attribute
        {
            return HasAttribute<TObject, TAttribute>(obj, inherit);
        }

        /// <summary>
        /// Checks if the object's type has a custom attribute specified. Also searches for inherited attributes.
        /// </summary>
        /// <typeparam name="TObject">The type of the object to check.</typeparam>
        /// <typeparam name="TAttribute">The type of the <see cref="Attribute"/> to find.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <param name="attribute">The attribute to find.</param>
        /// <returns><value>true</value> if the attribute was found; otherwise, <value>false</value>.</returns>
        public static bool HasAttribute<TObject, TAttribute>(this TObject obj, TAttribute attribute)
            where TAttribute : Attribute
        {
            return HasAttribute<TObject, TAttribute>(obj, true);
        }

        /// <summary>
        /// Checks if the object's type has certain type attributes specified.
        /// </summary>
        /// <typeparam name="TObject">The type of the object to check.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <param name="attributeFlags">One or more type attributes to find.</param>
        /// <returns><value>true</value> if the attribute was found; otherwise, <value>false</value>.</returns>
        public static bool HasAttribute<TObject>(this TObject obj, TypeAttributes attributeFlags)
        {
            Type objectType = typeof(TObject);
            TypeAttributes objectAttributes = objectType.Attributes;
            return (objectAttributes & attributeFlags) == attributeFlags;
        }

        /// <summary>
        /// Checks if the object's type has certain generic parameter attributes specified.
        /// </summary>
        /// <typeparam name="TObject">The type of the object to check.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <param name="attributeFlags">One or more generic parameter attributes to find.</param>
        /// <returns><value>true</value> if the attribute was found; otherwise, <value>false</value>.</returns>
        public static bool HasAttribute<TObject>(this TObject obj, GenericParameterAttributes attributeFlags)
        {
            Type objectType = typeof(TObject);
            GenericParameterAttributes objectAttributes = objectType.GenericParameterAttributes;
            return (objectAttributes & attributeFlags) == attributeFlags;
        }
    }
}