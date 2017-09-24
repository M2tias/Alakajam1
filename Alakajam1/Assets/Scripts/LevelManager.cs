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
    [SerializeField]
    private Transform Player;
    [SerializeField]
    private GameObject Cat;

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
            { 168, Resources.Load("underworld_wall_bottom_right_outer_angle", typeof(GameObject)) as GameObject },
            { 87, Resources.Load("underworld_wall_left", typeof(GameObject)) as GameObject },
            { 69, Resources.Load("underworld_wall_left_bottom_angle", typeof(GameObject)) as GameObject },
            { 86, Resources.Load("underworld_wall_left_top_angle", typeof(GameObject)) as GameObject },
            { 167, Resources.Load("underworld_wall_left_bottom_outer_angle", typeof(GameObject)) as GameObject },
            { 71, Resources.Load("underworld_wall_right", typeof(GameObject)) as GameObject },
            { 101, Resources.Load("underworld_wall_top_right_angle", typeof(GameObject)) as GameObject },
            { 166, Resources.Load("underworld_wall_top_left_outer_angle", typeof(GameObject)) as GameObject },
            { 165, Resources.Load("underworld_wall_top_right_outer_angle", typeof(GameObject)) as GameObject },
            { 12, Resources.Load("object_floor_broken", typeof(GameObject)) as GameObject },
            { 28, Resources.Load("object_floor_filled", typeof(GameObject)) as GameObject },
            { 29, Resources.Load("object_rock", typeof(GameObject)) as GameObject },
            { 13, Resources.Load("object_button", typeof(GameObject)) as GameObject },
            { 41, Resources.Load("object_bars", typeof(GameObject)) as GameObject },
            { 59, Resources.Load("object_bars_door", typeof(GameObject)) as GameObject },
            { 60, Resources.Load("object_bars_open", typeof(GameObject)) as GameObject },
            { 61, Resources.Load("object_bars_overlap", typeof(GameObject)) as GameObject },
            { 73, Resources.Load("object_book_earth", typeof(GameObject)) as GameObject },
            { 89, Resources.Load("object_book_water", typeof(GameObject)) as GameObject },
            { 105, Resources.Load("object_book_air", typeof(GameObject)) as GameObject },
            { 121, Resources.Load("object_book_fire", typeof(GameObject)) as GameObject },
            { 56, Resources.Load("object_barrel", typeof(GameObject)) as GameObject },
            { 42, Resources.Load("object_barrel_broken", typeof(GameObject)) as GameObject },
            { 11, Resources.Load("object_ditch", typeof(GameObject)) as GameObject },
            { 27, Resources.Load("object_ditch_filled", typeof(GameObject)) as GameObject },
            { 43, Resources.Load("object_flame_left", typeof(GameObject)) as GameObject },
            { 44, Resources.Load("object_flame_middle", typeof(GameObject)) as GameObject },
            { 45, Resources.Load("object_flame_right", typeof(GameObject)) as GameObject },
            { 74, Resources.Load("object_wall_breakable_top", typeof(GameObject)) as GameObject },
            { 75, Resources.Load("object_wall_broken_top", typeof(GameObject)) as GameObject },
            { 90, Resources.Load("object_wall_breakable_bottom", typeof(GameObject)) as GameObject },
            { 91, Resources.Load("object_wall_broken_bottom", typeof(GameObject)) as GameObject },
            { 57, Resources.Load("object_guard", typeof(GameObject)) as GameObject },
            { 58, Resources.Load("object_charred", typeof(GameObject)) as GameObject },
            { 65, Resources.Load("object_priest", typeof(GameObject)) as GameObject },
            { 106, Resources.Load("object_stone", typeof(GameObject)) as GameObject }
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
        if (currentLevel != null && currentLevel.ID == "Overworld")
        {
            Cat.SetActive(true);
        }
        else
        {
            Cat.SetActive(false);
        }
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

    public void ChangeLevel(string mapId)
    {
        foreach (Transform child in LevelContainer.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        currentLevel = new Level(levels.Where(x => x.ID == mapId).FirstOrDefault());
    }

    public string GetLevelID(int index)
    {
        if(index > levels.Count-1)
        {
            return "";
        }
        return levels[index].ID;
    }

    public void SetPlayerPosition(Vector3 pos)
    {
        Player.position = pos;
    }

    public Transform GetContainer()
    {
        return LevelContainer;
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
    private bool overWorld = false;

    public Level(LevelID level)
    {
        this.level = level;
        overWorld = level.File == "Overworld.txt"; //kek
        parseLevel(level.File);
    }

    public GameObject getTile(int x, int y)
    {
        return tiles[y][x];
    }

    private void parseLevel(string filename)
    {
        //temporary variables for pairing objects in a very stupid way
        Dictionary<int, Tile> doorPair = new Dictionary<int, Tile>();
        GameObject doorButton = null; //either jail door or floor button, pair them together
        GameObject bars = null; //bars is set to this so jail door's left neighbour can be paired to it

        string map = Resources.Load<TextAsset>("Maps/" + filename.Substring(0, filename.IndexOf('.'))).text;
        List<string> file = map.Replace("\r", "").Split(new char[] { '\n' }).ToList();//.ToList();

        List<GameObject> row = new List<GameObject>();
        bool map_flag = false;
        bool obj_flag = false;
        int obj_y = 0;
        foreach (string line in file)
        {
            if (!map_flag && line.Contains("type=Map"))
            {
                map_flag = true;
                continue;
            }
            if ((map_flag || obj_flag) && line.Contains("data="))
            {
                continue;
            }
            else if (map_flag && line == "")
            {
                map_flag = false;
                //break;
            }
            else if (map_flag)
            {
                //List<GameObject> tiles = new List<GameObject>();
                string tmp = line;
                if (line.Last() == ',')
                {
                    tmp = line.Substring(0, line.Count() - 1);
                }
                List<string> parts = tmp.Split(new char[] { ',' }).ToList();

                foreach (string part in parts)
                {
                    if (!LevelManager.tiles.ContainsKey(Int32.Parse(part)))
                    {
                        Debug.Log(part);
                    }
                    GameObject tile = LevelManager.main.Instantiate(LevelManager.tiles[Int32.Parse(part)]);
                    tile.isStatic = true;
                    float xOffset = LevelManager.main.GetXOffset();
                    float yOffset = LevelManager.main.GetYOffset();

                    tile.transform.position = new Vector3(xOffset + row.Count, yOffset - tiles.Count, 0);

                    row.Add(tile);
                }
            }
            else if (!map_flag && !obj_flag && line.Contains("type=Objects"))
            {
                obj_flag = true;
                obj_y = 0;
                continue;
            }
            else if (obj_flag && line == "")
            {
                map_flag = false;
                //break;
            }
            else if (obj_flag)
            {
                string tmp = line;
                if (line.Last() == ',')
                {
                    tmp = line.Substring(0, line.Count() - 1);
                }
                List<string> parts = tmp.Split(new char[] { ',' }).ToList();
                int obj_x = 0;

                foreach (string part in parts)
                {
                    int id = Int32.Parse(part);
                    if (id <= 255 && id >= 241)
                    {
                        if (!overWorld)
                        {
                            //jos numero -> getTile(x, y) -> aseta pari (miten?)
                            Tile door = getTile(obj_x, obj_y).GetComponent<Tile>();
                            if (doorPair.ContainsKey(id))
                            {
                                door.SetDoorPair(doorPair[id]);
                                doorPair.Remove(id);
                            }
                            else
                            {
                                doorPair.Add(id, door);
                            }
                        }
                        else
                        {
                            Tile door = getTile(obj_x, obj_y).GetComponent<Tile>();
                            door.SetMapID(LevelManager.main.GetLevelID(id - 240));
                            //set world to id-241
                        }
                    }
                    else if(id == 256)
                    {
                        float xOffset = LevelManager.main.GetXOffset();
                        float yOffset = LevelManager.main.GetYOffset();
                        LevelManager.main.SetPlayerPosition(new Vector3(xOffset + obj_x, yOffset - obj_y, 0));
                    }
                    else
                    {
                        //jos kissa/pappi/tms -> luo instanssi ja heitä containeriin
                        if(LevelManager.tiles.ContainsKey(id))
                        {
                            GameObject tile = LevelManager.main.Instantiate(LevelManager.tiles[Int32.Parse(part)]);
                            SpriteRenderer r = tile.GetComponent<SpriteRenderer>();
                            if (r != null) r.sortingOrder = 2;
                            float xOffset = LevelManager.main.GetXOffset();
                            float yOffset = LevelManager.main.GetYOffset();

                            tile.transform.position = new Vector3(xOffset + obj_x, yOffset - obj_y, 0);

                            if(id == 41)
                            {
                                bars = tile;
                            }
                            else if(id == 13 || id == 59)
                            {
                                if(doorButton == null)
                                {
                                    doorButton = tile;
                                }
                                else
                                {
                                    if (doorButton.tag == "JailDoor")
                                    {
                                        doorButton.GetComponent<JailDoor>().SetButton(tile);
                                        tile.GetComponent<FloorButton>().SetDoor(doorButton);
                                    }
                                    else
                                    {
                                        doorButton.GetComponent<FloorButton>().SetDoor(tile);
                                        tile.GetComponent<JailDoor>().SetButton(doorButton);
                                    }
                                }

                                if(id == 59 && bars != null)
                                {
                                    tile.GetComponent<JailDoor>().SetOverlap(bars);
                                }
                            }
                        }
                    }
                    obj_x++;
                }
                obj_y++;
            }

            if (row.Count > 0)
            {
                tiles.Add(row);
            }
            row = new List<GameObject>();
        }

        //one door should be without pair. it takes back to the overWorld
        if (doorPair.Count > 0 && !overWorld)
        {
            doorPair.ToList()[0].Value.GetComponent<Tile>().SetMapID("Overworld");
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