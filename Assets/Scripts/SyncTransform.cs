using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncTransform : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private BirdFactory birdFactory;
    public GameObject Target => target;
    [SerializeField] private float posZ;
    private void Update()
    {
        transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z - posZ);
        if(target == null)
        {
           SetTarget( birdFactory.GetComponentInChildren<Bird>().gameObject);
        }
    }
    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }
}
