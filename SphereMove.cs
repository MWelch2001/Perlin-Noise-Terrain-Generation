using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class SphereMove : MonoBehaviour
{
    Vector3 playerInput;
    List<Transform> tiles = new List<Transform>();
    Transform tilePrefab;
    Transform currentTile;
    float speed = 0.1f;
    int tileOffset;
    void Start()
    {
        tilePrefab = Resources.Load<Transform>("Prefabs/tile");
        tileOffset = (int)tilePrefab.transform.position.x;
        spawnTile();
    }

    void Update()
    {
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.z = Input.GetAxis("Vertical");
        transform.localPosition += new Vector3(playerInput.x * speed, 0f, playerInput.z * speed);
        currentTile = getCurrentTile();
        if  (playerOutsideTile())
        {
            spawnTile();
        }
    }

    //bool currentTileChanged()
    //{
    //    if (transform.position.x > tiles[currentTile].transform.position.x + tileOffset || transform.position.x < tiles[currentTile].transform.position.x - tileOffset)
    //    {
    //        return false;
    //    }
    //    if (transform.position.y > tiles[currentTile].transform.position.y + tileOffset || transform.position.y < tiles[currentTile].transform.position.y - tileOffset)
    //    {
    //        return false;
    //    }
    //    return true;
    //}

    Transform getCurrentTile()
    {

        foreach (var tile in tiles)
        {

            if (transform.position.z <= tile.position.z + tileOffset && transform.position.z >= tile.position.z - tileOffset && transform.position.x <= tile.position.x + tileOffset && transform.position.x >= tile.position.x - tileOffset)
            {
                return tile;
            }
        }
        return null;
    }

    bool playerOutsideTile()
    {
        if (transform.position.x > currentTile.transform.position.x + tileOffset || transform.position.x < currentTile.transform.position.x - tileOffset)
        {
            return true;
        }
        if (transform.position.y > currentTile.transform.position.y + tileOffset || transform.position.y < currentTile.transform.position.y - tileOffset)
        {
            return true;
        }
            return false;
    }

    void spawnTile()
    {
        Transform tileClone = Instantiate(tilePrefab, new Vector3(transform.position.x + tileOffset, 0, transform.position.z + tileOffset), transform.rotation);
        tiles.Add(tileClone);
    }

}
