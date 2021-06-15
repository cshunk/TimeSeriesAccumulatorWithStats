using System;
using System.Collections.Generic;
using System.Text;

namespace Harmony.Model.Asset
{
    public class Asset
    {
        public AssetType AssetType { get; set; }

        public Guid AssetUid { get; set; }

        public string AssetPath { get; set; }

        public Asset Parent { get; set; }

        public IEnumerable<Asset> Children { get; set; }
    }
}
