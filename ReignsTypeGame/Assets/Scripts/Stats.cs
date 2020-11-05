using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    //min/max stat values
    public static int STAT_MIN = 0;
    public static int STAT_MAX = 100;

    private int fireStat;

    public Stats(int fireStatsAmount)
    {
        setFireStat(fireStatsAmount);
    }
    public void setFireStat(int fireStatAmount)
    {
        //setting attack stat and making sure it's between the set min/max values
        fireStat = Mathf.Clamp(fireStatAmount,STAT_MIN,STAT_MAX);
    }
    public int getFireStat()
    {
        return fireStat;
    }
}
