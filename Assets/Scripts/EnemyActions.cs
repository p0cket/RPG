using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    // There are many actions
    //  -walk
    //  -attack
    //  -Speak
    //  -animate
// //////////////////////////////////////////////////
    // if taken damage or another trigger (Like hitting walls), trigger other phase.

    public string[] actions;
    public int phase;

    public GameObject[] iceBlocks;
    public int nullCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        CheckPhase();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            phase += 1;
            CheckPhase();

        }

        for(int i = 0; i < iceBlocks.Length; i++)
        {

            // Debug.Log(iceBlocks[i]);
            if(iceBlocks[i] == null)
            {
                nullCount++;
            }
            
        }
        
        // Uncomment if you want to count blocks
        // Debug.Log("nullCount: " + nullCount + " and iceBlocks.Length: " + iceBlocks.Length);

        if(nullCount >= iceBlocks.Length)
        {
            Debug.Log("All Blocks Are Gone");
            //change the phase to the next one. phase 2! phase += 1;
        }

        nullCount = 0;

        //if every iceBlock[i] == null, set to next phase


        // switch (phase)
        // {
        // case 1:
        //     // Just Move
        //     // Debug.Log("Phase 1: Move");
        //     break;
        // case 2:
        //     // Move and shoot
        //     // Debug.Log("Phase 2: Shoot");
        //     // Deactivate Movement
        //     MoveBackAndForth.instance.activate = false;
        //     FiringController.instance.canFire = false;
        //     break;
        // case 3:
        //     // Debug.Log("Phase 3: Something Else");
        //     // Movement and no Fire
        //     MoveBackAndForth.instance.activate = true;
        //     FiringController.instance.canFire = false;
        //     break;
        // case 4:
        //     // Debug.Log("Phase 4");
        //     // No Movement and yes Fire
        //     MoveBackAndForth.instance.activate = false;
        //     FiringController.instance.canFire = true;
        //     break;
        // case 5:
        //     // Debug.Log("Phase 5");
        //     // Yes Movement & Yes Fire
        //     MoveBackAndForth.instance.activate = true;
        //     FiringController.instance.canFire = true;
        //     break;
        // case 6:
        //     // Debug.Log("Phase 6");
        //     // Deactivate Movement
        //     MoveBackAndForth.instance.activate = false;
        //     break;
        // case 7:
        //     // Debug.Log("Default");
        //     break;
        // }
    }

    public void CheckPhase()
    {
         switch (phase)
        {
        case 1:
            // Just Move
            Debug.Log("Phase 1: Move'n'shoot");
            MoveBackAndForth.instance.points = MoveBackAndForth.instance.phase1points;
            break;
        case 2:
            // Move and shoot
            Debug.Log("Phase 2: No Move No Shoot");
            // Deactivate Movement
            MoveBackAndForth.instance.activate = false;
            FiringController.instance.canFire = false;
            break;
        case 3:
            Debug.Log("Phase 3: Just Move 5x");
            // 5x Movement and no Fire
            MoveBackAndForth.instance.activate = true;
            FiringController.instance.canFire = false;
            // And 5 Times the speed
            MoveBackAndForth.instance.speed = MoveBackAndForth.instance.speed * 5;
            MoveBackAndForth.instance.points = MoveBackAndForth.instance.phase2points;
            break;
        case 4:
            Debug.Log("Phase 4: no Move, yes Fire");
            // No Movement and yes Fire
            MoveBackAndForth.instance.activate = false;
            FiringController.instance.canFire = true;
            FiringController.instance.fireRate = FiringController.instance.fireRate / 4f;
            break;
        case 5:
            Debug.Log("Phase 5: Reg Move, yes Fire");
            // Yes Movement & Yes Fire
            MoveBackAndForth.instance.activate = true;
            FiringController.instance.canFire = true;
            // And Back to regular speed (Not 5x)
            MoveBackAndForth.instance.points = MoveBackAndForth.instance.phase1points;
            MoveBackAndForth.instance.speed = MoveBackAndForth.instance.speed / 5;
            break;
        case 6:
            Debug.Log("Phase 6");
            // Deactivate Movement
            MoveBackAndForth.instance.activate = false;
            break;
        case 7:
            Debug.Log("Default");
            break;
        }
    }
}
