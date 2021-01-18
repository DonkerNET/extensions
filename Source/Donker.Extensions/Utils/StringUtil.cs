using System.Text;

namespace Donker.Extensions.Utils
{
    public static class StringUtil
    {
        public static string PascalCaseToSnakeCase(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];

                if (i > 0 && char.IsUpper(c))
                    builder.Append('_');

                builder.Append(char.ToLower(c));
            }

            return builder.ToString();
        }

        public static string CamelCaseToSnakeCase(string value)
        {
            return PascalCaseToSnakeCase(value); // Does the same thing
        }

        public static string SnakeCaseToPascalCase(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            StringBuilder builder = new StringBuilder();

            bool nextIsUpper = true;

            foreach (char c in value)
            {
                if (nextIsUpper)
                {
                    builder.Append(char.ToUpper(c));
                    nextIsUpper = false;
                }
                else if (c == '_')
                {
                    nextIsUpper = true;
                }
                else
                {
                    builder.Append(c);
                }
            }

            return builder.ToString();
        }

        public static string SnakeCaseToCamelCase()
        {

        }
    }
}
