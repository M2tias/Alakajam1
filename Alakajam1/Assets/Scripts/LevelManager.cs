using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<LevelID> levels = new List<LevelID>();
    [SerializeField]
    private int currentLevelID = 0;
    [SerializeField]
    public float levelXOffset = 0;
    [SerializeField]
    public float levelYOffset = 0;
    [SerializeField]
    private Transform LevelContainer;

    private Level currentLevel;

    public static Dictionary<int, GameObject> tiles;

    public static LevelManager main;
    void Awake()
    {

        if (GameObject.FindGameObjectsWithTag("LevelManager").Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            this.tag = "LevelManager";
            main = this;
        }

    }

    // Use this for initialization
    void Start()
    {
        tiles = new Dictionary<int, GameObject>()
        {
            { 81, Resources.Load("black", typeof(GameObject)) as GameObject },
            { 20, Resources.Load("dark_overworld_floor", typeof(GameObject)) as GameObject },
            { 4, Resources.Load("light_overworld_floor", typeof(GameObject)) as GameObject },
            { 99, Resources.Load("fade_out_bottom", typeof(GameObject)) as GameObject },
            { 135, Resources.Load("fade_out_bottom_funky", typeof(GameObject)) as GameObject },
            { 162, Resources.Load("fade_out_bottom_open", typeof(GameObject)) as GameObject },
            { 129, Resources.Load("fade_out_bottom_right_angle", typeof(GameObject)) as GameObject },
            { 133, Resources.Load("fade_out_bottom_right_outer_angle", typeof(GameObject)) as GameObject },
            { 66, Resources.Load("fade_out_left", typeof(GameObject)) as GameObject },
            { 132, Resources.Load("fade_out_left_bottom_angle", typeof(GameObject)) as GameObject },
            { 148, Resources.Load("fade_out_left_bottom_outer_angle", typeof(GameObject)) as GameObject },
            { 151, Resources.Load("fade_out_left_funky", typeof(GameObject)) as GameObject },
            { 163, Resources.Load("fade_out_left_open", typeof(GameObject)) as GameObject },
            { 146, Resources.Load("fade_out_left_right", typeof(GameObject)) as GameObject },
            { 131, Resources.Load("fade_out_left_top_angle", typeof(GameObject)) as GameObject },
            { 147, Resources.Load("fade_out_left_top_outer_angle", typeof(GameObject)) as GameObject },
            { 98, Resources.Load("fade_out_right", typeof(GameObject)) as GameObject },
            { 134, Resources.Load("fade_out_right_funky", typeof(GameObject)) as GameObject },
            { 161, Resources.Load("fade_out_right_open", typeof(GameObject)) as GameObject },
            { 82, Resources.Load("fade_out_top", typeof(GameObject)) as GameObject },
            { 145, Resources.Load("fade_out_top_bottom", typeof(GameObject)) as GameObject },
            { 150, Resources.Load("fade_out_top_funky", typeof(GameObject)) as GameObject },
            { 164, Resources.Load("fade_out_top_open", typeof(GameObject)) as GameObject },
            { 130, Resources.Load("fade_out_top_right_angle", typeof(GameObject)) as GameObject },
            { 149, Resources.Load("fade_out_top_right_outer_angle", typeof(GameObject)) as GameObject },
            { 37, Resources.Load("overworld_door", typeof(GameObject)) as GameObject },
            { 6, Resources.Load("overworld_roof", typeof(GameObject)) as GameObject },
            { 38, Resources.Load("overworld_roof_left", typeof(GameObject)) as GameObject },
            { 54, Resources.Load("overworld_roof_left_end", typeof(GameObject)) as GameObject },
            { 39, Resources.Load("overworld_roof_right", typeof(GameObject)) as GameObject },
            { 55, Resources.Load("overworld_roof_right_end", typeof(GameObject)) as GameObject },
            { 5, Resources.Load("overworld_wall_bottom", typeof(GameObject)) as GameObject },
            { 10, Resources.Load("overworld_wall_bottom_left_roof", typeof(GameObject)) as GameObject },
            { 26, Resources.Load("overworld_wall_bottom_right_roof", typeof(GameObject)) as GameObject },
            { 21, Resources.Load("overworld_wall_top", typeof(GameObject)) as GameObject },
            { 9, Resources.Load("overworld_wall_top_left_roof", typeof(GameObject)) as GameObject },
            { 25, Resources.Load("overworld_wall_top_right_roof", typeof(GameObject)) as GameObject },
            { 36, Resources.Load("overworld_well", typeof(GameObject)) as GameObject },
            { 52, Resources.Load("underworld_door_top", typeof(GameObject)) as GameObject },
            { 83, Resources.Load("underworld_door_bottom", typeof(GameObject)) as GameObject },
            { 67, Resources.Load("underworld_door_left", typeof(GameObject)) as GameObject },
            { 84, Resources.Load("underworld_door_right", typeof(GameObject)) as GameObject },
            { 68, Resources.Load("underworld_floor", typeof(GameObject)) as GameObject },
            { 53, Resources.Load("underworld_wall_top", typeof(GameObject)) as GameObject },
            { 103, Resources.Load("underworld_wall_bottom", typeof(GameObject)) as GameObject },
            { 85, Resources.Load("underworld_wall_bottom_right_angle", typeof(GameObject)) as GameObject },
            { 165, Resources.Load("underworld_wall_bottom_right_outer_angle", typeof(GameObject)) as GameObject },
            { 87, Resources.Load("underworld_wall_left", typeof(GameObject)) as GameObject },
            { 69, Resources.Load("underworld_wall_left_bottom_angle", typeof(GameObject)) as GameObject },
            { 86, Resources.Load("underworld_wall_left_top_angle", typeof(GameObject)) as GameObject },
            { 167, Resources.Load("underworld_wall_left_bottom_outer_angle", typeof(GameObject)) as GameObject },
            { 71, Resources.Load("underworld_wall_right", typeof(GameObject)) as GameObject },
            { 101, Resources.Load("underworld_wall_top_right_angle", typeof(GameObject)) as GameObject },
            { 166, Resources.Load("underworld_wall_top_left_outer_angle", typeof(GameObject)) as GameObject },
            { 168, Resources.Load("underworld_wall_top_right_outer_angle", typeof(GameObject)) as GameObject }
        };

        //Debug.Log("fine");
        if (currentLevel == null)
        {
            currentLevel = new Level(levels[currentLevelID + 1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public GameObject Instantiate(GameObject obj)
    {
        GameObject inst = Instantiate(obj, LevelContainer, false);
        return inst;
    }

    public float GetXOffset()
    {
        return levelXOffset;
    }

    public float GetYOffset()
    {
        return levelYOffset;
    }
}

[Serializable]
public class LevelID
{
    public LevelID() { }
    public string ID;
    public string File;
}

public class Level
{
    List<List<GameObject>> tiles = new List<List<GameObject>>();
    public string ID { get { return level.ID; } }
    private LevelID level;

    public Level(LevelID level)
    {
        Debug.Log("ok");
        this.level = level;
        parseLevel(level.File);
    }

    public GameObject getTile(int x, int y)
    {
        return tiles[y][x];
    }

    private void parseLevel(string filename)
    {
        List<string> file = System.IO.File.ReadAllLines("Assets/Maps/"+filename).ToList();

        List<GameObject> row = new List<GameObject>();
        bool csv_flag = false;
        Debug.Log("hi!"+file.Count);
        foreach (string line in file)
        {
            if (!csv_flag && line.Contains("data="))
            {
                csv_flag = true;
                continue;
            }
            else if(csv_flag && line == "")
            {
                csv_flag = false;
                break;
            }
            else if (csv_flag)
            {
                //List<GameObject> tiles = new List<GameObject>();
                string tmp = line;
                if(line.Last() == ',')
                {
                    tmp = line.Substring(0, line.Count() - 1);
                }
                List<string> parts = tmp.Split(new char[] { ',' }).ToList();

                foreach (string part in parts)
                {
                    if(!LevelManager.tiles.ContainsKey(Int32.Parse(part)))
                    {
                        Debug.Log(part);
                    }
                    GameObject tile = LevelManager.main.Instantiate(LevelManager.tiles[Int32.Parse(part)]);
                    float xOffset = LevelManager.main.GetXOffset();
                    float yOffset = LevelManager.main.GetYOffset();

                    tile.transform.position = new Vector3(xOffset + row.Count, yOffset - tiles.Count, 0);

                    row.Add(tile);
                }
            }

            if (row.Count > 0)
            {
                tiles.Add(row);
            }
            row.Clear();
        }
    }
}

/*public class Tile
{

}*/

public enum TileType
{
    Floor,
    Wall,
    Roof,
    Door
}