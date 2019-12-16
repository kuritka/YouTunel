using System;
using System.IO;

namespace YouTunelPutty20._Client.Extensions
{
    public static class DisposableExtensions
    {
        public static void CloseIfNotNull(this IDisposable toDispose)
        {
            if (toDispose != null)
            {
                toDispose.Dispose();
            }
        }


        public static void CloseIfNotNull(this Stream toClose)
        {
            if (toClose == null ||  toClose.CanSeek == false) return;
            {
                toClose.Close();
            }
        }

    }
}
