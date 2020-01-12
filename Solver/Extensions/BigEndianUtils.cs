﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Solver.Extensions
{
    public static class BigEndianUtils
    {
        public static int ReadBigInt32(this BinaryReader br)
        {
            var bytes = br.ReadBytes(sizeof(Int32));
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
    }
}
