using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameM : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Transform FireBall;
    private Vector3 nextFireBallSpawn = new Vector3(5, 5, 0);

    private Vector3 nextFireBallSpawn2 = new Vector3(160, 5, 0);
    public Transform SnowBall;
    private Vector3 nextSnowBallSpawn = new Vector3(50, 5, 0);
    public Transform lava;
    private Vector3 nextLavaSpawn ;
    public Transform snow;
    private Vector3 nextSnowSpawn ;
    public Material snowskybox;
    public Material fireskybox;
    private float randZ;
    private int it = 0;
    private int it2 = 0;
    bool Sw= false;
    bool an = true;
    [SerializeField] float turnSpeed=10f;

    void Start()
    {
        StartCoroutine(spawnLava());
        nextLavaSpawn =  new Vector3(58, lava.position.y, 0);
        nextSnowSpawn = new Vector3(58, snow.position.y, 0);
    }

    void Update()
    {

    }
    IEnumerator spawnLava()
    {
        yield return new WaitForSeconds(1);

        
        // Instantiate(lava, nextLavaSpawn, lava.rotation);
        for (int i = 0; i < 2; i++)
            {
                nextFireBallSpawn.x += 2;
                for (int j = 0; j < 2; j++)
                {
                    randZ = Random.Range(-4, 5);
                    nextFireBallSpawn.z = randZ;
                    Instantiate(FireBall, nextFireBallSpawn, FireBall.rotation);
                }
            }
        nextLavaSpawn.x += 10;
        it++;
        if (it < 10)
            StartCoroutine(spawnLava());
        else
        {
            StopCoroutine(spawnLava());
            StartCoroutine(spawnSnow());
            nextLavaSpawn.x = nextSnowSpawn.x;
            nextFireBallSpawn.x = nextSnowBallSpawn.x;
            RenderSettings.skybox = snowskybox;
        }
    }
    IEnumerator spawnSnow()
    {
        yield return new WaitForSeconds(1);
        
        // Instantiate(snow, nextSnowSpawn, snow.rotation);
        Time.timeScale = 2f;
        SwitchGravity();

        for (int i = 0; i < 2; i++)
        {
            nextSnowBallSpawn.x += 2;
            for (int j = 0; j < 2; j++)
            {
                randZ = Random.Range(-4, 5);
                nextSnowBallSpawn.z = randZ;
                Instantiate(SnowBall, nextSnowBallSpawn, SnowBall.rotation);
            }
        }
        nextSnowSpawn.x += 10;
        it2++;
        if(it2 < 30)
            StartCoroutine(spawnSnow());
        else
        {
            StartCoroutine(spawnLava2());
            SwitchGravityToLava();
            
            StopCoroutine(spawnSnow());
            RenderSettings.skybox = fireskybox;
        }
    }
    IEnumerator spawnLava2()
    {
        yield return new WaitForSeconds(1);

        SwitchGravityToLava();
        // Instantiate(lava, nextLavaSpawn, lava.rotation);
        for (int i = 0; i < 2; i++)
            {
                nextFireBallSpawn2.x += 2;
                for (int j = 0; j < 2; j++)
                {
                    randZ = Random.Range(-4, 5);
                    nextFireBallSpawn2.z = randZ;
                    Instantiate(FireBall, nextFireBallSpawn2, FireBall.rotation);
                }
            }
        nextLavaSpawn.x += 10;
        it++;
        if (it < 30)
            StartCoroutine(spawnLava2());
        else
        {
            StopCoroutine(spawnLava2());
            
            nextLavaSpawn.x = nextSnowSpawn.x;
            // nextFireBallSpawn.x = nextSnowBallSpawn.x;
         
        }
    }
    void SwitchGravity()
    {
        // if(!Sw)
        // {
        //     player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        //     Invoke("OnGround" , 3f);
        //     Sw = true;
        // }
        // if(an)
        // {
        //     Invoke("OnGround" , 3f);
        //     an = false;
        // }
        
        
        
        Vector3 next = new Vector3(268.388f, -132.388f , 312.594f);
        Physics.gravity = new Vector3(0, 9.81f, 0);
        // player.GetComponent<Animator>().enabled = true;
        
        player.transform.localEulerAngles =  Vector3.Slerp(player.transform.localRotation.eulerAngles, next , turnSpeed);
        player.GetComponent<playerMove>().yourJumpForce = -player.GetComponent<playerMove>().yourJumpForce;
        player.GetComponent<playerMove>().h_inputswitch = true;
        Debug.Log(player.GetComponent<playerMove>().h_inputswitch);
        
    }
    void SwitchGravityToLava()
    {
        // if(Sw)
        // {
        //     // player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            
        //     Sw = false;
            
        // }
        // if(!an)
        // {
        //     Invoke("OnGround" , 3f);
        //     an = true;
        // }
        
        
        // Invoke("OnGround" , 1f);
       
       Vector3 next = new Vector3(-90 , 0, 0);
        Physics.gravity = new Vector3(0, -9.81f, 0);
        // player.GetComponent<Animator>().enabled = true;
        
        player.transform.localEulerAngles =  Vector3.Slerp(player.transform.localRotation.eulerAngles, next , turnSpeed);
        player.GetComponent<playerMove>().yourJumpForce = -player.GetComponent<playerMove>().yourJumpForce;
        player.GetComponent<playerMove>().h_inputswitch = false;
        Debug.Log(player.GetComponent<playerMove>().h_inputswitch);
        
    }
    void OnGround()
    {
         player.GetComponent<Animator>().enabled = false;
    }
}
