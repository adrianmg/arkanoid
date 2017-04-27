using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEditor;
using UnityEngine;

[Tiled2Unity.CustomTiledImporter]
class CustomTiledImporterForBlocks : Tiled2Unity.ICustomTiledImporter
{
    int layerBlock = LayerMask.NameToLayer("Block");

    public void HandleCustomProperties(GameObject gameObject, IDictionary<string, string> customProperties)
    {

        if (layerBlock > 0 && gameObject.layer == layerBlock)
        {
            gameObject.name = "BlockTile";

            GameObject collider = gameObject.GetComponentInChildren<Collider2D>().gameObject;
            collider.name = "Block";
            Block block = collider.AddComponent<Block>();
            block.hits = Int16.Parse(customProperties["hits"]);
        }
    }

    public void CustomizePrefab(GameObject prefab)
    {
        // Do nothing
    }
}

