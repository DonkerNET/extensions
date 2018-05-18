using System;
using System.IO;

namespace Donker.Extensions.Helpers.FileHelper
{
    public static partial class FileHelper
    {
        /// <summary>
        /// <para>Checks if a path with the specified directory, name and extension already exists. If so, the first available path with the correct sequence number is returned instead.</para>
        /// <para>Output format with sequence number: {directory}\{name}({sequence number}).{extension}</para>
        /// <para>Example output with sequence number: C:\example(2).txt</para>
        /// </summary>
        /// <param name="directory">The directory of the file path to check.</param>
        /// <param name="name">The name of the file path to check.</param>
        /// <param name="extension">Optional. The extension of the file path to check.</param>
        /// <returns>The file path that is actually available, as a <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="directory"/> or <paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="directory"/> or <paramref name="name"/> is empty.</exception>
        public static string GetFirstAvailableFilePath(string directory, string name, string extension)
        {
            if (directory == null)
                throw new ArgumentNullException("directory", "The directory cannot be null.");
            if (directory.Length == 0)
                throw new ArgumentException("The directory cannot be empty.", "directory");
            if (name == null)
                throw new ArgumentNullException("name", "The name cannot be null.");
            if (name.Length == 0)
                throw new ArgumentException("The name cannot be empty.", "name");

            if (extension == null)
                extension = string.Empty;

            int number = ExtractNumberFromFileName(name, out name);
            string numberString = string.Empty;

            string fullPath;
            bool fileExists;

            do
            {
                fullPath = Path.Combine(directory, string.Concat(name, numberString, extension));
                fileExists = File.Exists(fullPath);
                if (fileExists)
                    numberString = string.Format("({0})", ++number);
            }
            while (fileExists);

            return fullPath;
        }

        /// <summary>
        /// <para>Checks if the path of the specified file already exists. If so, the first available path with the correct sequence number is returned instead.</para>
        /// <para>Output format with sequence number: {directory}\{name}({sequence number}).{extension}</para>
        /// <para>Example output with sequence number: C:\example(2).txt</para>
        /// </summary>
        /// <param name="fileInfo">The file for which to check the path.</param>
        /// <returns>The file path that is actually available, as a <see cref="string"/>.</returns>
        public static string GetFirstAvailableFilePath(FileInfo fileInfo)
        {
            if (fileInfo == null)
                throw new ArgumentNullException("fileInfo", "The file info cannot be null.");

            string directory = fileInfo.DirectoryName;
            string name = fileInfo.Name;
            string extension = fileInfo.Extension;

            if (!string.IsNullOrEmpty(extension))
                name = name.Substring(0, name.Length - extension.Length);

            return GetFirstAvailableFilePath(directory, name, extension);
        }

        /// <summary>
        /// <para>Checks if the specified file path already exists. If so, the first available path with the correct sequence number is returned instead.</para>
        /// <para>Output format with sequence number: {directory}\{name}({sequence number}).{extension}</para>
        /// <para>Example output with sequence number: C:\example(2).txt</para>
        /// </summary>
        /// <param name="filePath">The file path to check.</param>
        /// <returns>The file path that is actually available, as a <see cref="string"/>.</returns>
        public static string GetFirstAvailableFilePath(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException("filePath", "The file path cannot be null.");
            if (filePath.Length == 0)
                throw new ArgumentException("The file path cannot be empty.", "filePath");
            
            FileInfo fileInfo = new FileInfo(filePath);
            return GetFirstAvailableFilePath(fileInfo);
        }

        private static int ExtractNumberFromFileName(string name, out string strippedName)
        {
            const int defaultNumber = 1;

            strippedName = name;

            if (string.IsNullOrEmpty(name))
                return defaultNumber;

            int numEnd = name.Length - 1;

            if (name[numEnd] != ')')
                return defaultNumber;

            int numStart = name.LastIndexOf('(', numEnd) + 1;

            if (numStart == 0)
                return defaultNumber;

            string numberStr = name.Substring(numStart, numEnd - numStart);

            if (numberStr.Length == 0)
                return defaultNumber;

            int extractedNumber;

            if (!int.TryParse(numberStr, out extractedNumber))
                return defaultNumber;

            strippedName = strippedName.Substring(0, numStart - 1);

            if (strippedName.Length == 0)
            {
                strippedName = name;
                return defaultNumber;
            }

            return extractedNumber;
        }
    }
}