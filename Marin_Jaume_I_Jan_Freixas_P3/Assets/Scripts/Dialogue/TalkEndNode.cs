using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newTalkEndNode", menuName = "Dialogue/EndNodes/DeafultTalkEndNode", order = 1)]
public class TalkEndNode : EndNode
{
    public override void OnChosen(GameObject npc)
    {
        npc.GetComponent<MovementController>().Talk();
    }
}
