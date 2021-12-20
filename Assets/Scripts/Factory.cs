using UnityEngine;

public class Factory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform pointToSpawn;
    [SerializeField] private Transform positionParent;
    [SerializeField] private T prefab;
    public T Prefab => prefab;

    public T GetNewInstance()
    {
        Vector3 pos = new Vector3(pointToSpawn.position.x, pointToSpawn.position.y,
            pointToSpawn.position.z);

         prefab = Instantiate(prefab, pos, Quaternion.identity, positionParent);
        prefab.gameObject.GetComponent<Bird>().enabled = true;
        return prefab;
    }
}