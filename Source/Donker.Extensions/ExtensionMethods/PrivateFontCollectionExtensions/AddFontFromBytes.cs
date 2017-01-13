using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class PrivateFontCollectionExtensions
    {
        /// <summary>
        /// Creates a <see cref="FontFamily"/> object from an array of bytes and adds it to the collection.
        /// </summary>
        /// <param name="privateFontCollection">The <see cref="PrivateFontCollection"/> to add the font to.</param>
        /// <param name="bytes">The font bytes to create the <see cref="FontFamily"/> from.</param>
        /// <returns>The newly added <see cref="FontFamily"/> object.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="privateFontCollection"/> or <paramref name="bytes"/> parameter is null.</exception>
        public static FontFamily AddFontFromBytes(this PrivateFontCollection privateFontCollection, byte[] bytes)
        {
            if (privateFontCollection == null)
                throw new ArgumentNullException("privateFontCollection", "The private font collection cannot be null.");
            if (bytes == null)
                throw new ArgumentNullException("bytes", "The byte array cannot be null.");

            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            
            try
            {
                IntPtr bytesPtr = handle.AddrOfPinnedObject();
                privateFontCollection.AddMemoryFont(bytesPtr, bytes.Length);
            }
            finally
            {
                handle.Free();
            }

            int lastIndex = privateFontCollection.Families.Length - 1;
            return privateFontCollection.Families[lastIndex];
        }
    }
}
