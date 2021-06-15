using System;

namespace Harmony.Model
{
    public class RawChunk
    {
        public int Size { get; private set; }

        public double[] Data { get; set; }

        public RawChunk(int size)
        {
            Size = size;
            Data = new double[size];
        }
    }
}
