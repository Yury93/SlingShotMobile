using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySnowMan : MonoBehaviour
{
    [SerializeField] private Rigidbody[] snowman;
    

    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < snowman.Length; i++)
        {
            if (snowman[i])
            {
                snowman[i].isKinematic = false;
            }
            else
            {
                Destroy(gameObject, 3);
            }

        }
        Destroy(gameObject, 3f);
    }
    private void OnCollisionExit(Collision collision)
    {
        PlayerMetrics.Instance.UpdateScore(1);
    }
}
