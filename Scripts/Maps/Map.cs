using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public string Name { get; set; }
    public List<Instance> Instances { get; set; }

    public Map(string name)
    {
        Name = name;
        Instances = new List<Instance>();
    }
}


