using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    
    public delegate void DelegateDestroy();
    public event DelegateDestroy OnDestroy;
    public SlingShot slingShot;

    private void OnCollisionEnter(Collision collision)
    {
        var c = collision.gameObject.GetComponent<Bird>();
        if (c)
        {
            Destroy(c.gameObject);
            slingShot.ResetBird();
            OnDestroy();
        }
    }
}
