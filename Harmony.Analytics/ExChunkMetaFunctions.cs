using Harmony.Model;
using System;

namespace Harmony.Analytics
{
    public static class ExChunkMetaFunctions
    {
        public static ChunkMeta CalculateChunkMeta(this RawChunk chunk, int maxGapAreas )
        {
            var result = new ChunkMeta(chunk.Size, maxGapAreas);

			int currentDataSize = 0;
			int currentGapsInHole = 0;
			int lastGapLocation = 0;
			bool inGap = false;
			bool inSpottyData = false;
			double ex = 0.0;
			double ex2 = 0.0;

			result.Max = ChunkMeta.NullValue;
			result.Min = ChunkMeta.NullValue;


			double lastValue = ChunkMeta.NullValue;

			for (int i = 0; i < chunk.Size; i++)
			{
				bool wasInSpottyData = inSpottyData;

				inGap = chunk.Data[i] == ChunkMeta.NullValue;

				if (inGap)
				{
					lastGapLocation = i;

					if (!wasInSpottyData && result.TotalGapAreas < maxGapAreas)
					{
						result.GapAreas[result.TotalGapAreas * 3] = i;
					}

					currentDataSize = 0;
					result.TotalGaps++;
					currentGapsInHole++;
					inSpottyData = true;
				}

				if (!inGap)
				{
					currentDataSize++;
					result.Sum += chunk.Data[i];

					if (result.Max == ChunkMeta.NullValue || chunk.Data[i] > result.Max)
						result.Max = chunk.Data[i];
					if (result.Min == ChunkMeta.NullValue || chunk.Data[i] < result.Min)
						result.Min = chunk.Data[i];

					ex += (chunk.Data[i] - lastValue);
					ex2 += ex * ex;

					if (chunk.Data[i] == lastValue)
                    {
						result.DuplicateValues++;
                    }

					if (wasInSpottyData)
					{
						if (result.TotalGapAreas == 0)
						{
							result.GapAreas[(result.TotalGapAreas * 3) + 1] = lastGapLocation;
							result.GapAreas[(result.TotalGapAreas * 3) + 2] = currentGapsInHole;
							inSpottyData = false;
							result.TotalGapAreas++;
							currentGapsInHole = 0;
						}
						else if (result.TotalGapAreas == maxGapAreas)
						{
							// Do nothing
						}
						else if (currentDataSize >=
														(chunk.Size - i)     // Remaining data left
														/
														(3 * (maxGapAreas - result.TotalGapAreas)) // Holes left to identify
								&&
									result.TotalGapAreas < maxGapAreas - 1
								)
						{
							result.GapAreas[(result.TotalGapAreas * 3) + 1] = lastGapLocation;
							result.GapAreas[(result.TotalGapAreas * 3) + 2] = currentGapsInHole;
							inSpottyData = false;
							result.TotalGapAreas++;
							currentGapsInHole = 0;

						}

					}


				}
			}

			if (inSpottyData)
			{
				result.GapAreas[(result.TotalGapAreas * 3) + 1] = lastGapLocation;
				result.GapAreas[(result.TotalGapAreas * 3) + 2] = currentGapsInHole;
				result.TotalGapAreas++;
			}

			int n = chunk.Size - result.TotalGaps;
			if (n > 0)
			{
				result.Mean = result.Sum / n;
				if (n > 1)
				{
					result.Variance = (ex2 - (ex * ex) / n) / (n - 1);
				}
			}

			return result;
        }
    }
}
