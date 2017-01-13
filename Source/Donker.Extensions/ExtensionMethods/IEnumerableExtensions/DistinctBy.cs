using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class IEnumerableExtensions
    {

        /// <summary>
        /// Distincts items from a collection by the value of a member.
        /// </summary>
        /// <typeparam name="TSource">The type of items in the collection.</typeparam>
        /// <typeparam name="TMember">The type of the member to distinct by.</typeparam>
        /// <param name="source">The collection to distinct.</param>
        /// <param name="expression">The expression that selected the member of the items.</param>
        /// <param name="comparer">The comparer to use when comparing the members of the items.</param>
        /// <returns>A filtered collection as <see cref="IEnumerable{TSource}"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="source"/> or <paramref name="expression"/> is null.</exception>
        /// <exception cref="ArgumentException">The expression returned a member of a different type than specified or did not refer to a valid field or property.</exception>
        public static IEnumerable<TSource> DistinctBy<TSource, TMember>(this IEnumerable<TSource> source, Expression<Func<TSource, TMember>> expression, IEqualityComparer<TMember> comparer)
        {
            if (source == null)
                throw new ArgumentNullException("source", "The source cannot be null.");
            if (expression == null)
                throw new ArgumentNullException("expression", "The expression cannot be null.");

            MemberExpression memberExpression = expression.Body as MemberExpression;

            if (memberExpression != null)
            {
                PropertyInfo propertyInfo = memberExpression.Member as PropertyInfo;

                if (propertyInfo != null)
                {
                    if (propertyInfo.PropertyType != typeof(TMember))
                        throw new ArgumentException("The expression returns a member of a different type than specified.", "expression");

                    HashSet<TMember> hashSet = new HashSet<TMember>(comparer);

                    foreach (TSource item in source)
                    {
                        TMember value = (TMember)propertyInfo.GetValue(item, null);
                        if (hashSet.Add(value))
                            yield return item;
                    }

                    yield break;
                }

                FieldInfo fieldInfo = memberExpression.Member as FieldInfo;

                if (fieldInfo != null)
                {
                    if (fieldInfo.FieldType != typeof(TMember))
                        throw new ArgumentException("The expression returns a member of a different type than specified.", "expression");

                    HashSet<TMember> hashSet = new HashSet<TMember>(comparer);

                    foreach (TSource item in source)
                    {
                        TMember value = (TMember)fieldInfo.GetValue(item);
                        if (hashSet.Add(value))
                            yield return item;
                    }

                    yield break;
                }
            }

            throw new ArgumentException("The expression does not refer to a valid field or property.");
        }

        /// <summary>
        /// Distincts items from a collection by the value of a member.
        /// </summary>
        /// <typeparam name="TSource">The type of items in the collection.</typeparam>
        /// <typeparam name="TMember">The type of the member to distinct by.</typeparam>
        /// <param name="source">The collection to distinct.</param>
        /// <param name="expression">The expression that selected the member of the items.</param>
        /// <returns>A filtered collection as <see cref="IEnumerable{TSource}"/>.</returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TMember>(this IEnumerable<TSource> source, Expression<Func<TSource, TMember>> expression)
        {
            return DistinctBy(source, expression, null);
        }
    }
}
