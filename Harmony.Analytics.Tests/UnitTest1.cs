using Harmony.Model;
using System;
using Xunit;

namespace Harmony.Analytics.Tests
{
    public class ChunkMetaTests
    {
        [Fact]
        public void CreateChunkMeta_PerformanceTest()
        {
            int chunkSize = 2048;
            int iterations = 1000;

            var r = new System.Random();

            RawChunk[] data = new RawChunk[iterations];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = new RawChunk(chunkSize);
                double percentNull = r.NextDouble();
                for (int j = 0; j < chunkSize; j++)
                {
                    if (r.NextDouble() < percentNull)
                    {
                        //data[i].Data[j] = 
                    }
                }
            }
        }
    }
}
