using System;
using System.Data;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class IDbCommandExtensions
    {
        /// <summary>
        /// Creates a new parameter without a value using the specified parameters, adds it to the command and returns it.
        /// </summary>
        /// <param name="cmd">The command to create and add the new parameter for.</param>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="columnName">Optional. The name of the source column mapped to the dataset.</param>
        /// <param name="type">Optional. The database type of the parameter's value.</param>
        /// <returns>The newly created <see cref="IDbDataParameter"/> object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cmd"/> or <paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty.</exception>
        public static IDbDataParameter AddParameter(this IDbCommand cmd, string name, string columnName, DbType? type)
        {
            if (cmd == null)
                throw new ArgumentNullException("cmd", "The command cannot be null.");
            if (name == null)
                throw new ArgumentNullException("name", "The name cannot be null.");
            if (name.Length == 0)
                throw new ArgumentException("The name cannot be empty.", "name");

            IDbDataParameter param = cmd.CreateParameter();
            param.ParameterName = name;

            if (type.HasValue)
                param.DbType = type.Value;

            if (!string.IsNullOrEmpty(columnName))
                param.SourceColumn = columnName;

            cmd.Parameters.Add(param);
            return param;
        }

        /// <summary>
        /// Creates a new parameter without a value using the specified parameters, adds it to the command and returns it.
        /// </summary>
        /// <param name="cmd">The command to create and add the new parameter for.</param>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="columnName">Optional. The name of the source column mapped to the dataset.</param>
        /// <returns>The newly created <see cref="IDbDataParameter"/> object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cmd"/> or <paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty.</exception>
        public static IDbDataParameter AddParameter(this IDbCommand cmd, string name, string columnName)
        {
            return AddParameter(cmd, name, columnName, null);
        }

        /// <summary>
        /// Creates a new parameter without a value using the specified parameters, adds it to the command and returns it.
        /// </summary>
        /// <param name="cmd">The command to create and add the new parameter for.</param>
        /// <param name="name">The name of the parameter.</param>
        /// <returns>The newly created <see cref="IDbDataParameter"/> object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cmd"/> or <paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty.</exception>
        public static IDbDataParameter AddParameter(this IDbCommand cmd, string name)
        {
            return AddParameter(cmd, name, null, null);
        }

        /// <summary>
        /// Creates a new parameter with value using the specified parameters, adds it to the command and returns it.
        /// </summary>
        /// <param name="cmd">The command to create and add the new parameter for.</param>
        /// <param name="name">The name of the parameter.</param>
        /// /// <param name="value">The value to add to the parameter.</param>
        /// <param name="columnName">Optional. The name of the source column mapped to the dataset.</param>
        /// <returns>The newly created <see cref="IDbDataParameter"/> object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cmd"/> or <paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty.</exception>
        public static IDbDataParameter AddParameterWithValue<TValue>(this IDbCommand cmd, string name, TValue value, string columnName)
        {
            if (cmd == null)
                throw new ArgumentNullException("cmd", "The command cannot be null.");
            if (name == null)
                throw new ArgumentNullException("name", "The name cannot be null.");
            if (name.Length == 0)
                throw new ArgumentException("The name cannot be empty.", "name");

            IDbDataParameter param = cmd.CreateParameter();
            param.ParameterName = name;

            if (Equals(value, null))
                param.Value = DBNull.Value;
            else
                param.Value = value;

            if (!string.IsNullOrEmpty(columnName))
                param.SourceColumn = columnName;

            cmd.Parameters.Add(param);
            return param;
        }

        /// <summary>
        /// Creates a new parameter with value using the specified parameters, adds it to the command and returns it.
        /// </summary>
        /// <param name="cmd">The command to create and add the new parameter for.</param>
        /// <param name="name">The name of the parameter.</param>
        /// /// <param name="value">The value to add to the parameter.</param>
        /// <returns>The newly created <see cref="IDbDataParameter"/> object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cmd"/> or <paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty.</exception>
        public static IDbDataParameter AddParameterWithValue<TValue>(this IDbCommand cmd, string name, TValue value)
        {
            return AddParameterWithValue(cmd, name, value, null);
        }
    }
}