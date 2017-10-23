using System;
using System.IO;

namespace Donker.Extensions.Helpers.FileHelper
{
    public static partial class FileHelper
    {
        /// <summary>
        /// <para>Checks if a path with the specified directory, name and extension already exists and returns the first available path instead.</para>
        /// <para>Output format: {directory}\{name}({number}).{extension}</para>
        /// <para>Example output: C:\example(1).txt</para>
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

            int number = 0;
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
        /// <para>Checks if the path of the specified file already exists and returns the first available path instead.</para>
        /// <para>Output format: {directory}\{name}({number}).{extension}</para>
        /// <para>Example output: C:\example(1).txt</para>
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
        /// <para>Checks if the specified file path already exists and returns the first available path instead.</para>
        /// <para>Output format: {directory}\{name}({number}).{extension}</para>
        /// <para>Example output: C:\example(1).txt</para>
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
    }
}