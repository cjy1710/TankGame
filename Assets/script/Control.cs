using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Control : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float moveSpeed = 10;        //the tank move speed
    private Vector3 bulletEuluerAngels;
    private SpriteRenderer sr;
    public Sprite[] tankSprite;     //up right down left
    public float temp = 0;

    //private bool isDefended = true;//玩家是否无敌状态
   // private float defendTimeVal = 0;//玩家无敌时间

    public GameObject explosionPrefab;//爆炸特效的预制体
    //public GameObject defendPrefab;//保护特效的预制体

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("在Update中执行");
        //Debug.Log("time:" + Time.time);
        // Debug.Log("deltatime" + Time.deltaTime);
        //Debug.Log("fixedtime:" + Time.fixedTime);
        //Debug.Log("fixedDeltatimetime:" + Time.fixedDeltaTime); 
    }

    private void FixedUpdate()
    {
        move();
        /*
        if (isDefended)
        {
            Instantiate(defendPrefab, transform.position, transform.rotation);
            defendTimeVal += Time.deltaTime;
            /*
            defendPrefab.SetActive(true);//无敌则显示护盾特效
            defendTimeVal += Time.deltaTime;
            if (defendTimeVal >= 3)//无敌时间过了就设置状态为不无敌
            {
                defendPrefab.SetActive(false);//取消护盾显示
                isDefended = false;
                defendTimeVal = 0;
            }
        } */ 
        if (temp >= 0.4f)
        {
            Attack();
        }
        else
        {
            temp += Time.fixedDeltaTime;
        }
    }
    //Player's move
    void move()
    {

        //right and left 
        float rl = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * moveSpeed * rl * Time.deltaTime, Space.World);

        if (rl < 0)
        {
            sr.sprite = tankSprite[2];
            bulletEuluerAngels = new Vector3(0, 0, 90);
        }
        else if (rl > 0)
        {
            sr.sprite = tankSprite[3];
            bulletEuluerAngels = new Vector3(0, 0, -90);
        }
        /*
			priority
			if you press the Button "W" and "A" at one time,we will priority "A" or "D"
		*/
        if (rl != 0)
            return;

        //up and down
        float ud = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * moveSpeed * ud * Time.deltaTime, Space.World);

        if (ud < 0)
        {
            sr.sprite = tankSprite[1];
            bulletEuluerAngels = new Vector3(0, 0, -180);
        }
        else if (ud > 0)
        {
            sr.sprite = tankSprite[0];
            bulletEuluerAngels = new Vector3(0, 0, 0);
        }

    }
    /*
    private void attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }*/


    //Tank attack
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEuluerAngels));
            temp = 0;
        }
    }

    

    private void TankDie()//坦克的死亡方法
    {
      //  if (isDefended)//如果玩家无敌则不会死亡
        //    return;
        Draw_UI.Instance.isDead = true;
        //产生爆炸特效
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        //死亡
        Destroy(gameObject);
    }




}
