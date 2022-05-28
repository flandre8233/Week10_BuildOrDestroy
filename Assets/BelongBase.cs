using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public interface IBelongBase
{
    Vector3Int[] GetBase();
    Vector3Int[] GetBaseNearByOpposite();
}

public abstract class BelongBase<T> : SingletonMonoBehavior<T>, IBelongBase
{
    [SerializeField] Tilemap Tilemap;
    protected abstract Belong BelongBy();
    public Vector3Int[] GetBase()
    {
        List<Vector3Int> Output = new List<Vector3Int>();
        BoundsInt bounds = Tilemap.cellBounds;
        TileBase[] allTiles = Tilemap.GetTilesBlock(bounds);
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null && BelongRule.NameToBelong(tile.name) == BelongBy())
                {
                    Output.Add(new Vector3Int(x, y, 0));
                }
            }
        }
        return Output.ToArray();
    }
    public Vector3Int[] GetBaseNearByOpposite()
    {
        List<Vector3Int> Output = new List<Vector3Int>();
        Vector3Int[] Base = GetBase();
        foreach (var item in Base)
        {
            foreach (Vector3Int NearBase in GetNearArray(item))
            {
                TileBase Target = Tilemap.GetTile(NearBase);
                if (Target && BelongRule.NameToBelong(Target.name) == BelongRule.GetOpposite(BelongBy()))
                {
                    Output.Add(item);
                    break;
                }
            }
        }
        return Output.ToArray();
    }
    Vector3Int[] GetNearArray(Vector3Int OrlPoint)
    {
        Vector3Int[] Near = new Vector3Int[4];
        Near[0] = new Vector3Int(OrlPoint.x + 1, OrlPoint.y, 0);
        Near[1] = new Vector3Int(OrlPoint.x, OrlPoint.y + 1, 0);
        Near[2] = new Vector3Int(OrlPoint.x - 1, OrlPoint.y, 0);
        Near[3] = new Vector3Int(OrlPoint.x, OrlPoint.y - 1, 0);
        return Near;
    }
}

