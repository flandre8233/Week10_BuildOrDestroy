using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Invasion<T> : TimeRepeater<T>
{
    [SerializeField] Tilemap Tilemap;
    [SerializeField] Tile Tile;
    [SerializeField] protected float Probability;

    protected abstract IBelongBase GetTargetBase();

    protected override void OnTimeEnd()
    {
        Raid();
    }

    void Raid()
    {
        Vector3Int[] AllNear = GetTargetBase().GetBaseNearByOpposite();
        if (AllNear.Length <= 0)
        {
            print("Nothing can be Invasion");
            GameoverListener.instance.OnGameOver();
            return;
        }
        foreach (var item in AllNear)
        {
            if (Random.Range(0, 100) <= Probability)
            {
                ForceRaid(item);
            }
        }
    }

    public void ForceRaid(Vector3Int CellPos)
    {
        if (Tilemap.GetTile(CellPos) == null)
        {
            return;
        }

        WhiteResearch.instance.TryRemoveCastle(CellPos);

        Tilemap.SetTile(CellPos, Tile);
        TileChangeListener.instance.OnChanged(CellPos);
        ResourcesSpawner.Spawn("Explosion", Tilemap.GetCellCenterWorld(CellPos), 2f);
        CameraShake.shakeAmount += 0.05f;
        CameraShake.shakeDuration += 0.08f;
    }
}
