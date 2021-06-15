using System;
using System.Collections.Generic;
using System.Text;

namespace Harmony.Model.Asset
{
    public class DataProducedEventArgs
    {
        public double[] DataSet { get; set; }
        public long[] AttributeIds { get; set; }
        public long SourceAssetId { get; set; }
        public long SourcePlantId { get; set; }
        public long SourceAssetType { get; set; }
        public long[] RecipientTypeFilter { get; set; }
        public MetricRelationshipTypeEnum[] RecipientRelationshipFilter { get; set; }

    }
}
