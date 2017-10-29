using System;
using System.IO;

namespace clby_ufop.Core.Misc
{
    public static class BinaryReaderExtensions
    {
        private const int ChunkSize = 1024 * 1024 * 4;
        private const int MaxSize = 1024 * 1024 * 1024;

        public static byte[] ReadAllBytes(this BinaryReader r)
        {
            byte[] array = new byte[ChunkSize];
            int num = 0;
            do
            {
                int num2 = r.Read(array, num, ChunkSize);
                num += num2;
                if (num2 <= 0)
                {
                    break;
                }
                else
                {
                    byte[] array2 = new byte[num + ChunkSize];
                    Buffer.BlockCopy(array, 0, array2, 0, num);
                    array = array2;
                }
            }
            while (num <= MaxSize - ChunkSize);

            return array;
        }

    }
}
