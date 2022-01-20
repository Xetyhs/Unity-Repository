using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructibleTiles : MonoBehaviour
{
    private Tilemap _destructibleTilemap;

    // Start is called before the first frame update
    void Start()
    {
        _destructibleTilemap = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in col.contacts)
            {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                _destructibleTilemap.SetTile(_destructibleTilemap.WorldToCell(hitPosition), null);
            }
            
        }
    }

    
}
