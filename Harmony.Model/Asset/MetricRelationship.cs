using System;
using System.Collections.Generic;
using System.Text;

namespace Harmony.Model.Asset
{
    public class MetricRelationship
    {
        public MetricRelationshipTypeEnum Type { get; set; }
        public AssetRelationshipTypeEnum AssetRelationship { get; set; }
        public AssetType[] SourceAssetTypes { get; set; }
        public AssetType DestinationAssetType { get; set; }

        public Metric[] SourceMetrics { get; set; }
        public Metric[] DestinationMetrics { get; set; }

    }
}
