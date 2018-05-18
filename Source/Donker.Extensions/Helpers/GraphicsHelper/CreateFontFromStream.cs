using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Donker.Extensions.Helpers
{
    public partial class GraphicsHelper
    {
        /// <summary>
        /// Creates a <see cref="FontFamily"/> object from the specified stream.
        /// </summary>
        /// <param name="stream">The stream containing the data of the font to create.</param>
        /// <returns>The created <see cref="FontFamily"/> object.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="stream"/> parameter is null.</exception>
        public static FontFamily CreateFontFromStream(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream", "The stream cannot be null.");

            int byteLength = (int)(stream.Length - stream.Position);
            byte[] bytes = new byte[byteLength];
            stream.Read(bytes, 0, byteLength);

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