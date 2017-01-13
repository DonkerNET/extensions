using System.Data;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class IDbConnectionExtensions
    {
        private static IDbCommand CreateCommand(IDbConnection conn, CommandType commandType, string commandText, IDbTransaction transaction)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandType = commandType;
            if (transaction != null)
                cmd.Transaction = transaction;
            if (commandText != null)
                cmd.CommandText = commandText;
            return cmd;
        }

        /// <summary>
        /// Creates a new text command and also sets the connection and other specified parameters.
        /// </summary>
        /// <param name="conn">The connection to create the command for.</param>
        /// <param name="commandText">Optional. The command text to set right away.</param>
        /// <param name="transaction">Optional. The transaction the command should use.</param>
        /// <returns>The created <see cref="IDbCommand"/> object.</returns>
        public static IDbCommand CreateTextCommand(this IDbConnection conn, string commandText, IDbTransaction transaction)
        {
            return CreateCommand(conn, CommandType.Text, commandText, transaction);
        }

        /// <summary>
        /// Creates a new text command and also sets the connection and other specified parameters.
        /// </summary>
        /// <param name="conn">The connection to create the command for.</param>
        /// <param name="commandText">Optional. The command text to set right away.</param>
        /// <returns>The created <see cref="IDbCommand"/> object.</returns>
        public static IDbCommand CreateTextCommand(this IDbConnection conn, string commandText)
        {
            return CreateCommand(conn, CommandType.Text, commandText, null);
        }

        /// <summary>
        /// Creates a new text command and also sets the connection and other specified parameters.
        /// </summary>
        /// <param name="conn">The connection to create the command for.</param>
        /// <returns>The created <see cref="IDbCommand"/> object.</returns>
        public static IDbCommand CreateTextCommand(this IDbConnection conn)
        {
            return CreateCommand(conn, CommandType.Text, null, null);
        }

        /// <summary>
        /// Creates a new stored procedure command and also sets the connection and other specified parameters.
        /// </summary>
        /// <param name="conn">The connection to create the command for.</param>
        /// <param name="commandText">Optional. The command text to set right away.</param>
        /// <param name="transaction">Optional. The transaction the command should use.</param>
        /// <returns>The created <see cref="IDbCommand"/> object.</returns>
        public static IDbCommand CreateSprocCommand(this IDbConnection conn, string commandText, IDbTransaction transaction)
        {
            return CreateCommand(conn, CommandType.StoredProcedure, commandText, transaction);
        }

        /// <summary>
        /// Creates a new stored procedure command and also sets the connection and other specified parameters.
        /// </summary>
        /// <param name="conn">The connection to create the command for.</param>
        /// <param name="commandText">Optional. The command text to set right away.</param>
        /// <returns>The created <see cref="IDbCommand"/> object.</returns>
        public static IDbCommand CreateSprocCommand(this IDbConnection conn, string commandText)
        {
            return CreateCommand(conn, CommandType.StoredProcedure, commandText, null);
        }

        /// <summary>
        /// Creates a new stored procedure command and also sets the connection and other specified parameters.
        /// </summary>
        /// <param name="conn">The connection to create the command for.</param>
        /// <returns>The created <see cref="IDbCommand"/> object.</returns>
        public static IDbCommand CreateSprocCommand(this IDbConnection conn)
        {
            return CreateCommand(conn, CommandType.StoredProcedure, null, null);
        }
    }
}