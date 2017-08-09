using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public bool isPrimary;
    protected Vector3 target;

    public Vector3 Target
    {      
        set
        {
            target = value;
        }
    }

    public virtual bool Fire(bool primary)
    {
        return false;
    }

    public virtual void UpdateTarget(GameObject trg)
    {         
    }
}
