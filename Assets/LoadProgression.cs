using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadProgression : MonoBehaviour
{

////// maybe create a [System.Serializable] class Progression and then add
////// this line below
/// public BattleMove[] movesList;
// As a result you will have conditions that will cause instantiation of characters, any GameObject etc.

    // Create an array of Prefabs that will load if a quest or saved variable is set to true

    // public GameObject[] loadThis;
    // public string[] storyBeat;

    void Start()
    {
    }
    void Update()
    { 
    }
}

// To do the above comments, create a class like below
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [System.Serializable]
// public class BattleMove 
// {
//     public string moveName;
//     public int movePower;
//     public int moveCost;
//     public AttackEffect theEffect;

// }