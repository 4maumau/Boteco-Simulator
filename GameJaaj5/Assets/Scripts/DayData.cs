using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Day", menuName = "Dia")]
public class DayData : ScriptableObject
{
    public List<int> delayBetweenSpawn;
}
