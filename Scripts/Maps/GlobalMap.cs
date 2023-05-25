using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMap
{
    public List<Map> Maps { get; set; }

    public GlobalMap()
    {
        Maps = new List<Map>();
    }

    public void AddMap(Map map)
    {
        Maps.Add(map);
    }
}
