using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private void Dead() 
    {
        Transform topParent = transform.parent;
        while (topParent.parent)
            topParent = topParent.parent;
        GameObject.Destroy(topParent.gameObject,0.5f);
    }
    public void Kill() {
        Dead();
    }
}
