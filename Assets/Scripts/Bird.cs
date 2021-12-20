using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody ribody;
    /// <summary>
    /// ћаксимальна€ скорость которую можно набрать
    /// </summary>
    [SerializeField] private float maxSpeed;
    [SerializeField]private float speed = 3.5f;
    private GameObject factoryBird;
    private void Start()
    {
        gameObject.GetComponent<Bird>().enabled = true;
        ribody = GetComponent<Rigidbody>();
        ribody.isKinematic = true;
        factoryBird = gameObject.GetComponentInParent<BirdFactory>().gameObject;
    }
    void Update()
    {
        //if (Application.platform == RuntimePlatform.Android)
        //{
        if (Input.GetMouseButton(0))
        {
            print("true");
            if (speed > maxSpeed)
            {
            }
            else
            {
                speed += Time.deltaTime;
            }
        }
        else if (Input.GetMouseButtonUp(0))
            {
            print("false");
                ribody.isKinematic = false;
                Vector3 dir = factoryBird.transform.position - gameObject.transform.position;
                ribody.AddForce(dir * speed, ForceMode.Impulse);
            }
        //}
        //else
        //{
            //if (Input.GetKey(KeyCode.Space) || tentesionClick.ForceTentesionClick == true)
            //{
            //    if (speed <= maxSpeed)
            //    {
            //        speed += Time.deltaTime;
            //    }
            //}
            //if (Input.GetKeyUp(KeyCode.Space)|| tentesionClick.ForceTentesionClick == false)
            //{
            //    ribody.isKinematic = false;
            //    Vector3 dir = factoryBird.transform.position - gameObject.transform.position;
            //    ribody.AddForce(dir * speed, ForceMode.Impulse);
            //}
        //}
    }
}
