using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileSlots : MonoBehaviour{

    private int countToCheckTwoTile = 0;


    void Start()
    {
        SnapObject._HitThroughSpace += CheckForItemThroughSpaceBar;
    }

    void OnDisable()
    {
        SnapObject._HitThroughSpace -= CheckForItemThroughSpaceBar;
    }

    void CheckForItemThroughSpaceBar()
    {
        if (GridManager.Instance.currentClickNumber <= GridManager.Instance.m_Total_ClicksCount)
        {
            if(GridManager.Instance.nameOfObject == this.gameObject.name)
            {
                TileWithItem(this.gameObject);
                GridManager.Instance.currentClickNumber++;
            }
        }
    }


    /// <summary>
    /// Click Down Event For Each Tile
    /// </summary>
    public void OnMouseDown()
    {
        GridManager.Instance.currentClickNumber++;
        if (GridManager.Instance.currentClickNumber <= GridManager.Instance.m_Total_ClicksCount)
        {
            TileWithItem(this.gameObject);
        }
    }
    /// <summary>
    /// Tile With Item Makes Red
    /// </summary>
    private void TileWithItem(GameObject item)
    {
        if(item.transform.childCount > 0)//Check Clicked Tile has Item 
        {
            item.transform.GetComponent<SpriteRenderer>().color = Color.red;
            TwoTileWithItem(item);
        }
        else
        {
            TileWithoutItemOrTwoTile(item);
        }
    }

    
    /// <summary>
    /// Two Tile with One Item
    /// </summary>
    private void TwoTileWithItem(GameObject item)
    {
        for (int i = 0; i < GridManager.Instance.m_AllTile_Selected.Count; i++)
        {
            if (item.gameObject.name == GridManager.Instance.m_AllTile_Selected[i].name)
            {
                countToCheckTwoTile++;
                if(countToCheckTwoTile > 1)//Check In (m_AllTile_Selected) this list has same Tile  
                {
                    item.transform.GetComponent<SpriteRenderer>().color = Color.yellow;
                }
            }
        }
    }

    /// <summary>
    /// Blank Tile.....
    /// </summary>
    private void TileWithoutItemOrTwoTile(GameObject item)
    {
        for (int i = 0; i < GridManager.Instance.m_AllTile_Selected.Count; i++)
        {
            if (item.gameObject.name != GridManager.Instance.m_AllTile_Selected[i].name)//Check Clicked Tile has not random tile and item(Blcnk)
            {
                item.transform.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }
}
