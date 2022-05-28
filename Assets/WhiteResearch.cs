using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;
using System;
public class WhiteResearch : TimeRepeater<WhiteResearch>
{
    [SerializeField] TileBase CastleTileBase;
    [SerializeField] List<Vector3Int> CastleLocation = new List<Vector3Int>();
    [SerializeField] Tilemap Tilemap;
    [SerializeField] float Probability;

    public void InitCastle()
    {
        Vector3Int[] All = WhiteBase.instance.GetBase();
        foreach (Vector3Int item in All)
        {
            TileBase Target = Tilemap.GetTile(item);
            if (Target.name == "Castle")
            {
                CastleLocation.Add(item);
            }
        }
    }

    public int GetCastleCount()
    {
        return CastleLocation.Count;
    }

    public void TryRemoveCastle(Vector3Int Point)
    {
        TileBase Target = Tilemap.GetTile(Point);
        if (Target.name == "Castle")
        {
            CastleLocation.Remove(Point);
            ResourcesSpawner.Spawn("TankExplosionSound", 3f);
            CameraShake.shakeAmount += 0.05f * 4;
            CameraShake.shakeDuration += 0.08f * 4;
        }
    }

    protected override void OnTimeEnd()
    {
        Research();
    }
    void Research()
    {
        if (UnityEngine.Random.Range(0, 100) > Probability)
        {
            return;
        }

        Vector3Int[] All = WhiteBase.instance.GetBase();
        All = All.OrderBy(a => Guid.NewGuid()).ToArray();

        All = SubList(All.ToList(), CastleLocation).ToArray();
        foreach (var item in All)
        {
            if (!IsNearAllWhite(item))
            {
                continue;
            }
            if (IsNearHaveCastle(item))
            {
                continue;
            }
            Build(item);
            return;
        }
    }

    bool IsNearAllWhite(Vector3Int Point)
    {
        foreach (Vector3Int NearBase in GetBuildArray(Point))
        {
            TileBase Target = Tilemap.GetTile(NearBase);
            if (!Target || BelongRule.NameToBelong(Target.name) == Belong.Black || BelongRule.NameToBelong(Target.name) == Belong.Neutral)
            {
                return false;
            }
        }
        return true;
    }
    bool IsNearHaveCastle(Vector3Int Point)
    {
        foreach (var CastlePos in CastleLocation)
        {
            if (Vector3Int.Distance(Point, CastlePos) <= 3)
            {
                return true;
            }
        }
        return false;
    }


    List<Vector3Int> SubList(List<Vector3Int> List1, List<Vector3Int> List2)
    {
        foreach (var item in List2)
        {
            List1.Remove(item);
        }
        return List1;
    }

    void Build(Vector3Int Location)
    {
        CastleLocation.Add(Location);
        Tilemap.SetTile(Location, CastleTileBase);
    }

    Vector3Int[] GetBuildArray(Vector3Int OrlPoint)
    {
        Vector3Int[] Near = new Vector3Int[4];
        Near[0] = new Vector3Int(OrlPoint.x + 1, OrlPoint.y, 0);
        Near[1] = new Vector3Int(OrlPoint.x, OrlPoint.y + 1, 0);
        Near[2] = new Vector3Int(OrlPoint.x - 1, OrlPoint.y, 0);
        Near[3] = new Vector3Int(OrlPoint.x, OrlPoint.y - 1, 0);
        return Near;
    }

}
