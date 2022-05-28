using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;
public class TilemapData : SingletonMonoBehavior<TilemapData>
{
    [SerializeField]
    TileBase[] Bases;

    [SerializeField] Tilemap Tilemap;

    public List<SaveTile> ToSaveTile()
    {
        List<SaveTile> output = new List<SaveTile>();
        BoundsInt bounds = Tilemap.cellBounds;
        TileBase[] allTiles = Tilemap.GetTilesBlock(bounds);
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    SaveTile Target = new SaveTile();
                    Target.X = x;
                    Target.Y = y;
                    Target.Index = BelongRule.ToObjIndex(tile.name);
                    output.Add(Target);
                }
            }
        }
        return output;
    }

    public void ReadTile(List<SaveTile> LoadedFile)
    {
        foreach (var item in LoadedFile)
        {
            BoundsInt bounds = Tilemap.cellBounds;
            Tilemap.SetTile(new Vector3Int(item.X, item.Y, 0), Bases[item.Index]);
        }
        WhiteResearch.instance.InitCastle();
        TileChangeListener.instance.OnChanged(new Vector3Int());
    }

}

public enum Belong
{
    White,
    Black,
    Neutral
}

public static class BelongRule
{
    public static Belong GetOpposite(Belong belong)
    {
        switch (belong)
        {
            case Belong.White:
                return Belong.Black;
            case Belong.Black:
                return Belong.White;
            default:
                return Belong.Neutral;
        }
    }

    public static Belong NameToBelong(string Name)
    {
        switch (Name)
        {
            case "BlackGround":
                return Belong.Black;
            case "WhiteGround":
                return Belong.White;
            case "Castle":
                return Belong.White;
            default:
                return Belong.Neutral;
        }
    }

    public static int ToObjIndex(string Name)
    {
        switch (Name)
        {
            case "BlackGround":
                return 1;
            case "WhiteGround":
                return 0;
            case "Castle":
                return 3;
            default:
                return 2;
        }
    }

}