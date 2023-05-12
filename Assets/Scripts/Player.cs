using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public Tilemap tileMap;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveCheck();
        CheckCurrentTile();
    }

    void CheckCurrentTile()
    {
        if (Input.GetKeyDown("space"))
        {
            Vector3 currentPos = this.transform.position;
            Vector3Int currentPosInt = new Vector3Int(Mathf.FloorToInt(currentPos.x), Mathf.FloorToInt(currentPos.y), Mathf.FloorToInt(currentPos.z));
            TileBase currentTile = tileMap.GetTile(currentPosInt);
            
        }
    }

    void MoveCheck()
    {
        int verticalDir = 0;
        if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
        {
            verticalDir = 1;
        }
        else if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
        {
            verticalDir = -1;
        }

        int horizDir = 0;
        if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
        {
            horizDir = 1;
        }
        else if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
        {
            horizDir = -1;
        }

        Vector3 newPos = this.transform.position + new Vector3(horizDir, verticalDir);
        this.transform.position = newPos;
    }

}
