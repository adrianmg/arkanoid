using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEditor;
using UnityEngine;

[Tiled2Unity.CustomTiledImporter]
public class CustomTiledImporterForBlocks : Tiled2Unity.ICustomTiledImporter
{
    int layerBlock = LayerMask.NameToLayer("Block");

    public void HandleCustomProperties(GameObject gameObject, IDictionary<string, string> customProperties)
    {

        if (layerBlock > 0 && gameObject.layer == layerBlock)
        {

            // Renaming
            gameObject.name = "BlockTile";

            GameObject collider = gameObject.GetComponentInChildren<Collider2D>().gameObject;
            collider.name = "Block";
            Block block = collider.AddComponent<Block>();

            // Hits value
            block.Hits = GameManager.BlockHitsBase;
            string hits;

            if (customProperties.TryGetValue("hits", out hits))
            {
                block.Hits = Int16.Parse(customProperties["hits"]);
            }

            // Score value
            block.Score = GameManager.BlockScoreBase;
            string score;

            if (customProperties.TryGetValue("score", out score))
            {
                block.Score = Int16.Parse(customProperties["score"]);
            }
        }
    }

    public void CustomizePrefab(GameObject prefab)
    {
        // Do nothing
    }
}

