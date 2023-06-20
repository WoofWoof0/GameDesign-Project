using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JKFrame;
using Sirenix.OdinInspector;

/// <summary>
/// Configure generation probability of plant objects
/// </summary>
[CreateAssetMenu(fileName = "plant spawn config", menuName = "Config/plantObjects")]
public class PlantSpawnConfig : ConfigBase
{
    [SerializeField] public Dictionary<MapCoordinateType, List<MapPlantSpawnConfigModel>> spawnConfigDic = new Dictionary<MapCoordinateType, List<MapPlantSpawnConfigModel>>();
}

public class MapPlantSpawnConfigModel
{
    [LabelText("Do not generate")]
    public bool IsEmpty = false;
    [LabelText("Prefab")]
    public GameObject Prefab;
    [LabelText("Generation probability(Percent Type)")]
    public int Probability;
}
