using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int maxTerrainCount; //initial matrix range; Maximum number of terrain blocks
    [SerializeField] private int minDistanceFromPlayer;//Distance from player to the largest terrain block
    [SerializeField] private List<TerrainData> terrainDatas= new List<TerrainData>(); //water,grass,road
    [SerializeField] private Transform terrainHolder;

    public List<GameObject> currentTerrains = new List<GameObject>();//for deleting redundant terrain blocks
    [HideInInspector]public Vector3 currentPosition = new Vector3(0, 0, 0); //only need to know current position

    //[SerializeField] public int spawnSeed;//random seed
    //[SerializeField] public PlantSpawnConfig spawnConfig;
    //[SerializeField] private GrassCoordinateType grassCoordinateType;

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain(true, new Vector3(0,0,0));
        }
        maxTerrainCount = currentTerrains.Count;//make maxTerrainCount a bit flexible
    }


    /// <summary>
    /// When the distance between the front terrain block and the player is too small, terrain blocks are generated. When the number of current terrain blocks exceeds the maximum number, the last terrain block is eliminated
    /// </summary>
    /// <param name="isStart">It is used to control the generation of a certain amount of terrians at the beginning, and check whether redundant terrian blocks should be deleted after the start</param>
    /// <param name="playerPosition">to know player's location that can decide whether it should spawn new terrain</param>
    public void SpawnTerrain(bool isStart, Vector3 playerPosition) 
    {
        if (((currentPosition.x - playerPosition.x) < minDistanceFromPlayer) || isStart) 
        { 
            int whichTerrain = Random.Range(0, terrainDatas.Count);//which one to spawn
            int terrainInSuccession = Random.Range(1, terrainDatas[whichTerrain].maxInSuccession);//Generate several objects in succession

            for (int i = 0; i < terrainInSuccession; i++)
            {
                GameObject terrain = Instantiate(terrainDatas[whichTerrain].possibleTerrain[Random.Range(0, terrainDatas[whichTerrain].possibleTerrain.Count)], currentPosition, Quaternion.identity, terrainHolder); //set parent to a transform
                currentTerrains.Add(terrain);//Terrains objects generated each time are placed here
                if (!isStart)
                {
                    if (currentTerrains.Count > maxTerrainCount)
                    {
                        Destroy(currentTerrains[0]);
                        currentTerrains.RemoveAt(0);
                    }
                }
                currentPosition.x++;
            }
        }
    }

//    #region scene plant
//    /// <summary>
//    /// Generate Map Objects
//    /// </summary>
//    private void SpawnPlantObject(GrassCoordinateType grassCoordinateType, PlantSpawnConfig spawnConfig, int spawnSeed)
//    {
//        //Use seeds for random generation
//        Random.InitState(spawnSeed);
//        int pointSize = grassCoordinateType.SpawnPoints.Length;

//        //Random once for each point
//        for (int i = 0; i < pointSize; i++)
//        {
//            MapCoordinate mapCoordinate = grassCoordinateType.GetCoordinate(i);
//            List<MapPlantSpawnConfigModel> configModels = spawnConfig.spawnConfigDic[mapCoordinate.CoordinateType];

//            //Ensure that the config probability sum is 100
//            int randValue = Random.Range(1, 101);//The actual number of hits is from 1 to 100
//            float temp = 0;
//            int spawnConfigIndex = 0;
//            //Assume that there are three objects with probabilities of 30, 20 and 50 respectively. The configModels.Count of the first cycle is 3. temp is 30. If it can reach the third cycle, it will hit 100%
//            for (int j = 0; j < configModels.Count; j++)
//            {
//                temp += configModels[j].Probability;
//                if (randValue < temp)
//                {
//                    //hit
//                    spawnConfigIndex = i;
//                    break;
//                }
//            }

//            //Items to be generated finally
//            MapPlantSpawnConfigModel spawnModel = configModels[spawnConfigIndex];
//            //Instantiate items if it not empty. If it is empty do nothing
//            if (spawnModel.IsEmpty == false)
//            {
//                GameObject gameObject = GameObject.Instantiate(spawnModel.Prefab, mapCoordinate.Position, Quaternion.identity, transform);
//            }
//        }
//    }
}

public enum MapCoordinateType
{
    Plant,
}

public class MapCoordinate
{
    [SerializeField] public Vector3 Position;
    [SerializeField] public MapCoordinateType CoordinateType;
}
//#endregion