using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridManager : Singleton<GridManager> {

	[SerializeField]
	private int m_Rows = 20;//How many Row You want
	[SerializeField]
	private int m_Cols = 20;//How many Column You want
    [SerializeField]
	private float m_TileSize = 1;//Tile Squre Size
	[SerializeField]
	private float m_PickingTile_Count = 10;// 10 Tile will assign

    [Header("variables for click")]
    public int m_Total_ClicksCount; // Total Click Count for player
    public int currentClickNumber;   // Current click number

    [Header("Lists for Holding Tiles And Items")]
    [SerializeField]
	private GameObject[] m_AllItem;//For Hold All Item(10) 
    [HideInInspector]
	public List<GameObject> m_AllTile;//For Hold All Tile
    [HideInInspector]
    public List<GameObject> m_AllTile_Selected;//For Hold Selected Tile(10)

	private int codeOfTile;//Number/Id For Tile

    [HideInInspector]
    public string nameOfObject;


	// Use this for initialization
	void Start () {
		m_AllTile = new List<GameObject> ();
        GenrateGrid();
	}

    /// <summary>
    /// function For Genrate grid
    /// </summary>
	private void GenrateGrid()
	{
		GameObject refrenceTile = (GameObject)Instantiate(Resources.Load("Tile"));//Load a prefab from resource folder and Instantiate 
        for (int row = 0; row < m_Rows; row++)
		{
			for(int col = 0; col < m_Cols; col++)
			{
				codeOfTile++;
				GameObject tile = (GameObject)Instantiate(refrenceTile,transform);
				m_AllTile.Add (tile);
				float posX = col * m_TileSize;
				float posY = row * -m_TileSize;				
				tile.transform.position = new Vector2(posX,posY);
				tile.name = "Tile_" + codeOfTile;
			}
		}
		Destroy(refrenceTile);
		float gridW = m_Cols * m_TileSize;
		float gridH = m_Rows * m_TileSize;
		transform.position = new Vector2 (-gridW / 2 + m_TileSize / 2, gridH / 2 - m_TileSize / 2);//For center allign grid
		PickRandomTile();
    }

    /// <summary>
    /// Assign tile in grid randomly
    /// </summary>
    /// <returns></returns>
	private GameObject PickRandomTile()
	{
		int count = -1;
		GameObject SelectedObject = null;
		for (int i = 0; i < m_PickingTile_Count; i++) {
            count =  Random.Range (0, m_AllTile.Count);
			SelectedObject = m_AllTile [count];
            m_AllTile_Selected.Add(SelectedObject);
            m_AllItem[i].transform.parent = SelectedObject.transform;
            m_AllItem[i].transform.localPosition = new Vector3(0,0,-0.1f);
        }
        return SelectedObject;
    }


    /// <summary>
    /// For Game reset /For Play Again
    /// </summary>
    public void ResetGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
