using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GodInterference : SingletonMonoBehavior<GodInterference>
{
    public int Interventions;

    [SerializeField] Tilemap Tilemap;

    Belong MouseDownBelong;

    void Update()
    {
        TileBase MouseTuleBase = Tilemap.GetTile(GetMouseCellPos());
        if (!MouseTuleBase || BelongRule.NameToBelong(MouseTuleBase.name) == Belong.Neutral)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            MouseDownBelong = BelongRule.NameToBelong(Tilemap.GetTile(GetMouseCellPos()).name);
        }

        if (Input.GetMouseButton(0))
        {
            if (MouseDownBelong == BelongRule.NameToBelong(Tilemap.GetTile(GetMouseCellPos()).name))
            {
                if (MouseDownBelong == Belong.White)
                {
                    BlackInvasion.instance.ForceRaid(Tilemap.WorldToCell(GetMouseCellPos()));
                    Interventions++;
                }
                else
                {
                    WhiteInvasion.instance.ForceRaid(Tilemap.WorldToCell(GetMouseCellPos()));
                    Interventions++;
                }
            }
        }
    }

    Vector3Int GetMouseCellPos()
    {
        Vector3 MouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int CellPos = Tilemap.WorldToCell(MouseWorldPos);
        return new Vector3Int(CellPos.x, CellPos.y, 0);
    }

}
