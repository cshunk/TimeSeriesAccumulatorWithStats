using System;
using System.Collections.Generic;
using System.Text;

namespace Harmony.Model
{
    public class ChunkMeta
    {
        public static readonly double NullValue = double.MaxValue - 1;

        private int _chunkSize;
        private int _maxGapAreas;


        public int TotalGapAreas { get; set; }
        public int TotalGaps { get; set; }
        public int[] GapAreas { get; set; }
        public int DuplicateValues { get; set; }

        public double Max { get; set; }
        public double Min { get; set; }
        public double Mean { get; set; }
        public double Sum { get; set; }
        public double Variance { get; set; }

        public ChunkMeta(int chunkSize, int maxGapAreas)
        {
            _chunkSize = chunkSize;
            _maxGapAreas = maxGapAreas;
        }

    }
}
