using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enabled))]
public class SlingShot : MonoBehaviour
{
    [SerializeField] private LineRenderer rope;
    [SerializeField] private BirdFactory birdFactory;
    [SerializeField] private Bird bird;
    private Vector3 birdFactoryPosition;
    private Rigidbody RbBird;

    private float viewX;
    private float viewY;
    /// <summary>
    /// Скорость перемещения птички при прицеливании на клавиши направления
    /// </summary>
    [SerializeField] private float speedView;
    /// <summary>
    /// Сила натяжения резинки
    /// </summary>
    [SerializeField] private float forceTension = 0.01f;
    [SerializeField] private float maxForceTension;
    /// <summary>
    /// Начальная позиция птички
    /// </summary>
    private Vector3 startPositionBird;

    /// <summary>
    /// Кэшированное прицеливание
    /// </summary>
    private Vector3 lookTrack;
    public Vector3 LookTrack => lookTrack;
    /// <summary>
    /// Можно ли стрелять
    /// </summary>
    private bool Shoot = true;

    [Header("Buttons")]
    [SerializeField] private ButtonUi w,s,a,d,forceTensionClick;
    public ButtonUi ForceTensionClick => forceTensionClick;
    [SerializeField] private GameObject buttonTension;
   
    [SerializeField] private float speedTentesion;
    private void Start()
    {
        bird = birdFactory.GetComponentInChildren<Bird>();
        RbBird = birdFactory.GetComponentInChildren<Rigidbody>();
        birdFactoryPosition = birdFactory.transform.position;
        startPositionBird = bird.transform.position;
        viewX = 0;
        viewY = 0;
        forceTension = 0f;
        speedTentesion = 1;
    }
    private void Update()
    {
        
        if (!bird)
        {
            bird = birdFactory.Prefab;
            //forceTension = 0.01f;
        }
        //if (Application.platform == RuntimePlatform.Android)
        //{
        //    //ControlerAndroid();
        //}
        //else
        //{
            if (Shoot == true && forceTensionClick.isClick == true)
            {
                if (forceTension < maxForceTension && forceTension != 0)
                {
                    forceTension += Time.deltaTime;
                }
                else
                {
                    forceTension = 0f;
                }
                if (w.isClick == false && s.isClick == false && a.isClick == false && 
                    d.isClick == false && forceTensionClick.isClick == false)
                {
                    ResetBird();
                }
                Mathf.Clamp(viewY, -3, 3);

                bird.transform.Translate(viewX * Time.deltaTime, viewY * Time.deltaTime, -forceTension * Time.deltaTime * speedTentesion);

                rope.SetPosition(1, new Vector3(bird.transform.position.x + 0.6f, bird.transform.position.y, bird.transform.position.z - 0.35f));
                rope.SetPosition(2, new Vector3(bird.transform.position.x, bird.transform.position.y, bird.transform.position.z - 0.7f));
                rope.SetPosition(3, new Vector3(bird.transform.position.x - 0.6f, bird.transform.position.y, bird.transform.position.z - 0.35f));

                bird.transform.LookAt(new Vector3(startPositionBird.x, bird.transform.position.y, startPositionBird.z));
                lookTrack = new Vector3(startPositionBird.x, bird.transform.position.y, startPositionBird.z);
            }
            else if (forceTensionClick.isClick == false && speedTentesion == 0)
            {
                ResetBird();
                rope.SetPosition(1, birdFactoryPosition);
                rope.SetPosition(2, birdFactoryPosition);
                rope.SetPosition(3, birdFactoryPosition);
                Shoot = false;
                speedTentesion = 1;
                ///выключаем клавишу пока не сработает корутина
                
                buttonTension.SetActive(false);
            StartCoroutine(corBoolShit());
        }
        //}
    }
    /// <summary>
    /// bool Shoot = true
    /// </summary>
    /// <returns></returns>
    IEnumerator corBoolShit()
    {
        yield return new WaitForSeconds(7f);
        Shoot = true;
        buttonTension.SetActive(true);

    }
    //private void ControlerAndroid()
    //{
    //    if (Shoot == true && forceTensionClick.isClick == true)
    //    {
    //        Mathf.Clamp(viewY, -3, 3);
    //        bird.transform.Translate(viewX * Time.deltaTime, viewY * Time.deltaTime, -forceTension * Time.deltaTime);

    //        rope.SetPosition(1, new Vector3(bird.transform.position.x + 0.6f, bird.transform.position.y, bird.transform.position.z - 0.35f));
    //        rope.SetPosition(2, new Vector3(bird.transform.position.x, bird.transform.position.y, bird.transform.position.z - 0.7f));
    //        rope.SetPosition(3, new Vector3(bird.transform.position.x - 0.6f, bird.transform.position.y, bird.transform.position.z - 0.35f));

    //        bird.transform.LookAt(new Vector3(startPositionBird.x, bird.transform.position.y, startPositionBird.z));
    //        lookTrack = new Vector3(startPositionBird.x, bird.transform.position.y, startPositionBird.z);
    //    }
    //    if(Shoot == false || forceTensionClick.isClick == false)
    //    {
    //        ResetBird();
    //        rope.SetPosition(1, birdFactory.transform.position);
    //        rope.SetPosition(2, birdFactory.transform.position);
    //        rope.SetPosition(3, birdFactory.transform.position);
            
    //        StartCoroutine(corBoolShit());
    //    }
    //}
    public void W()
    {
        viewY = 1;
        print("W");
    }
    public void S()
    {
        viewY = -1;
        print("S");
    }
    public void A()
    {
        viewX = -1;
        print("A");
    }
    public void D()
    {
        viewX = 1;
        print("D");
    }
    public void ForceTension()
    {
        if (forceTension < maxForceTension && forceTensionClick.isClick == true && Shoot == true)
        {
            forceTension += Time.deltaTime;
            if(forceTension >= maxForceTension)
            {
                forceTension = 0f;
                speedTentesion = 0f;
            }
        }
        else
        {
            forceTension = 0f;
            speedTentesion = 0f;
            Shoot = false;
        }
    }
    public void ResetBird()
    {
        viewX = 0;
        viewY = 0;

        forceTension = 0f;
    }
}
    
