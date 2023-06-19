using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyEventHandler : MonoBehaviour 
{
    public Creature target;
    public Creature self;

    public bool IsDamaged { get; set; }

    public float Distance { get => Vector3.Distance(target.transform.position, self.transform.position); }
    public Vector3 Direction { get => target.transform.position - self.transform.position; }

    public bool IsInLine
    {
        get
        {
            return Physics.Linecast(self.transform.position + new Vector3(0, 1, 0), target.transform.position + new Vector3(0, 1, 0));
        }
    }
}
