using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerData
{
    public int highScore;
    public playerData(player player)
    {
        highScore = player.highScore;
    }
}
