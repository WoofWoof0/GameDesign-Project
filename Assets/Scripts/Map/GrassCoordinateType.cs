using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Set the type of points on the grass prefab
/// </summary>
public class GrassCoordinateType : MonoBehaviour
{
    public Dictionary<int, MapCoordinate> pointDic = new Dictionary<int, MapCoordinate>(); //Build a container to put MapCoordinate class
    [SerializeField] public Transform[] SpawnPoints;//Coordinate points on prefab Grass

    /// <summary>
    /// Put the position of spawn points on the Grass prefab in the dictionary
    /// </summary>
    public void AddCoordinate()
    {
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            pointDic.Add(i
                , new MapCoordinate()
                {
                    Position = SpawnPoints[i].position
                });
        }
    }

    /// <summary>
    /// Get dictionary pointDic value
    /// </summary>
    public MapCoordinate GetCoordinate(int index)
    {
        return pointDic[index];
    }

    /// <summary>
    /// Set the type of spawn points on the grass prefab to plant
    /// </summary>
    public void SetPointType(int pointIndex, MapCoordinateType mapCoordinateType)
    {
        MapCoordinate point = GetCoordinate(pointIndex);
        if (point.CoordinateType != mapCoordinateType)
        {
            point.CoordinateType = mapCoordinateType;
        }
    }
}
