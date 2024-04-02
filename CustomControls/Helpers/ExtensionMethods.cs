using System.Drawing;

namespace SOS_Essential.CustomControls
{
    public static class ExtensionMethods
    {
        public static Color FromHex(this string hex)
        {
            return ColorTranslator.FromHtml(hex);
        }
    }
}
