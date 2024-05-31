using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewEndNode", menuName ="Dialogue/EndNodes/DeafultEndNode", order =1)]
public class EndNode : DialogueNode
{
    public virtual void OnChosen(GameObject npc)
    {
        Debug.Log("This is the end");
    }
}
