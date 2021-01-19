using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapObject : MonoBehaviour {
    public delegate void HitToObject();



    public static event HitToObject _HitThroughSpace;

    int currentSelctionTile = 0;
    void Start()
    {
        Invoke("AssignGridToSnap",0.5f);
    }

    void AssignGridToSnap()
    {
        if (GridManager.Instance.m_AllTile != null)
            this.transform.localPosition = new Vector3(GridManager.Instance.m_AllTile[currentSelctionTile].transform.localPosition.x, GridManager.Instance.m_AllTile[currentSelctionTile].transform.localPosition.y, GridManager.Instance.m_AllTile[currentSelctionTile].transform.localPosition.z);
        CancelInvoke();
    }

    void Update()
    {
        //Detect when the up arrow key is pressed down
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentSelctionTile >= 20)
            {
                currentSelctionTile = currentSelctionTile - 20;
                this.transform.localPosition = new Vector3(GridManager.Instance.m_AllTile[currentSelctionTile].transform.localPosition.x, GridManager.Instance.m_AllTile[currentSelctionTile].transform.localPosition.y, GridManager.Instance.m_AllTile[currentSelctionTile].transform.localPosition.z);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentSelctionTile <= 379)
            {
                currentSelctionTile = currentSelctionTile + 20;
                this.transform.localPosition = new Vector3(GridManager.Instance.m_AllTile[currentSelctionTile].transform.localPosition.x, GridManager.Instance.m_AllTile[currentSelctionTile].transform.localPosition.y, GridManager.Instance.m_AllTile[currentSelctionTile].transform.localPosition.z);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentSelctionTile >= 20)
            {
                currentSelctionTile--;
                this.transform.localPosition = new Vector3(GridManager.Instance.m_AllTile[currentSelctionTile].transform.localPosition.x, GridManager.Instance.m_AllTile[currentSelctionTile].transform.localPosition.y, GridManager.Instance.m_AllTile[currentSelctionTile].transform.localPosition.z);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentSelctionTile++;
            this.transform.localPosition = new Vector3(GridManager.Instance.m_AllTile[currentSelctionTile].transform.localPosition.x, GridManager.Instance.m_AllTile[currentSelctionTile].transform.localPosition.y, GridManager.Instance.m_AllTile[currentSelctionTile].transform.localPosition.z);
        }

        if (Input.GetKeyDown("space"))
        {
            if(this.transform.localPosition == new Vector3(GridManager.Instance.m_AllTile[currentSelctionTile].transform.localPosition.x, GridManager.Instance.m_AllTile[currentSelctionTile].transform.localPosition.y, GridManager.Instance.m_AllTile[currentSelctionTile].transform.localPosition.z))
            {
                GridManager.Instance.nameOfObject = GridManager.Instance.m_AllTile[currentSelctionTile].transform.name;
                _HitThroughSpace();
            }
        }
    }
}
