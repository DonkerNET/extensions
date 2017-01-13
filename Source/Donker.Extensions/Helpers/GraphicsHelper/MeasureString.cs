using System;
using System.Drawing;

namespace Donker.Extensions.Helpers
{
    public static partial class GraphicsHelper
    {
        /// <summary>
        /// Measures a text for a specific font without having to specify a <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="text">The text to measure.</param>
        /// <param name="font">The font to measure the text with.</param>
        /// <returns>A <see cref="SizeF"/> object with the width and height of the text.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="font"/> is null.</exception>
        public static SizeF MeasureStringF(string text, Font font)
        {
            if (font == null)
                throw new ArgumentNullException("font", "The font cannot be null.");

            SizeF size;

            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                size = g.MeasureString(text, font);
            }

            return size;
        }

        /// <summary>
        /// Measures a text for a specific font without having to specify a <see cref="Graphics"/> object and rounds up the width and height if <paramref name="ceiling"/> is <c>true</c>.
        /// </summary>
        /// <param name="text">The text to measure.</param>
        /// <param name="font">The font to measure the text with.</param>
        /// <param name="ceiling">If <c>true</c>, the width and height will be rounded up; otherwise, down.</param>
        /// <returns>A <see cref="Size"/> object with the width and height of the text, rounded according to the <paramref name="ceiling"/> parameter.</returns>
        public static Size MeasureString(string text, Font font, bool ceiling)
        {
            SizeF sizeF = MeasureStringF(text, font);

            int width = ceiling ? (int)Math.Ceiling(sizeF.Width) : (int)sizeF.Width;
            int height = ceiling ? (int)Math.Ceiling(sizeF.Height) : (int)sizeF.Height;
            
            Size size = new Size(width, height);
            return size;
        }

        /// <summary>
        /// Measures a text for a specific font without having to specify a <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="text">The text to measure.</param>
        /// <param name="font">The font to measure the text with.</param>
        /// <returns>A <see cref="Size"/> object with the width and height of the text.</returns>
        public static Size MeasureString(string text, Font font)
        {
            return MeasureString(text, font, false);
        }
    }
}