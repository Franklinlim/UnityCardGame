using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private void Dead() 
    {
        // Called from animation when it is complete
        // Kill unit after it dies
        Transform topParent = transform.parent;
        while (topParent.parent)
            topParent = topParent.parent;
        GameObject.Destroy(topParent.gameObject,0.5f);
    }
    public void Kill() {
        Dead();
    }
}
