using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instance
{
    public string Name { get; set; }
    public int Stars { get; set; }
    public bool IsCompleted { get; set; }
    public Reward FirstClearReward { get; set; }
    public Reward ExtraStarReward { get; set; }
    public bool IsUnlocked { get; set; }

    public Instance(string name)
    {
        Name = name;
        Stars = 0;
        IsCompleted = false;
        FirstClearReward = null;
        ExtraStarReward = null;
        IsUnlocked = false;
    }

    public void CompleteInstance()
    {
        IsCompleted = true;
    }

    public void SetStars(int stars)
    {
        if (stars >= 0 && stars <= 3)
        {
            Stars = stars;
        }
    }

}

public class Reward
{
    public string Name { get; set; }

    public Reward(string name)
    {
        Name = name;
    }
}
