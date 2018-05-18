using System;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace Donker.Extensions.Helpers
{
    public partial class GraphicsHelper
    {
        /// <summary>
        /// Creates a <see cref="FontFamily"/> object from the specified byte array.
        /// </summary>
        /// <param name="bytes">The bytes of the font to create.</param>
        /// <returns>The created <see cref="FontFamily"/> object.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="bytes"/> parameter is null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="bytes"/> parameter is empty.</exception>
        public static FontFamily CreateFontFromBytes(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException("bytes", "The byte array cannot be null.");
            if (bytes.Length == 0)
                throw new ArgumentException("The byte array cannot be empty.", "bytes");

            PrivateFontCollection pfc = new PrivateFontCollection();
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);

            try
            {
                IntPtr bytesPtr = handle.AddrOfPinnedObject();
                pfc.AddMemoryFont(bytesPtr, bytes.Length);
                return pfc.Families.FirstOrDefault();
            }
            finally
            {
                handle.Free();
                pfc.Dispose();
            }
        }
    }
}