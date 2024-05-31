using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newAttackEndNode", menuName = "Dialogue/EndNodes/DeafultAttackEndNode", order = 1)]
public class AttackEndNode : EndNode
{
    public override void OnChosen(GameObject npc)
    {
        npc.GetComponent<MovementController>().Attack();
    }
}
