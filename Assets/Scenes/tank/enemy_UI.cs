using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_UI : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float moveSpeed = 3;        //the tank move speed
    private Vector3 bulletEuluerAngels;
    private SpriteRenderer sr;
    public Sprite[] tankSprite;     //up right down left

   // private bool isDefended = true;//玩家是否无敌状态
   // private float defendTimeVal = 0;//玩家无敌时间

    public GameObject explosionPrefab;//爆炸特效的预制体
   // public GameObject defendPrefab;//保护特效的预制体

    private float DirChangeTime =2;//改变方向的时间间隔
    private float rl;
    private float ud;

    private float timeVal = 0f;//子弹发射计时器
    private float timeValE;//敌人子弹发射计时器


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
        //设置攻击时间间隔
        if (timeVal >= timeValE)
        {
            Attack();
            timeValE = Random.Range(0, 2);
        }
        else
            timeVal += Time.deltaTime;

    }

    private void FixedUpdate()
    {
        move();
        /*
        if (isDefended)
        {
            defendPrefab.SetActive(true);//无敌则显示护盾特效
            defendTimeVal += Time.deltaTime;
            if (defendTimeVal >= 3)//无敌时间过了就设置状态为不无敌
            {
                defendPrefab.SetActive(false);//取消护盾显示
                isDefended = false;
                defendTimeVal = 0;
            }
        }*/
    }
    //Player's move
    void move()
    {
        
        if (DirChangeTime >= 1)
        {
            int num = Random.Range(0, 9);
            if (num > 4 && num <= 6)//坦克向下走
            {
                ud = -1;
                rl = 0;
            }
            else if (num > 6 && num <= 8)//坦克向上走
            {
                ud = 1;
                rl = 0;
            }
            else if (num > 0 && num <= 2) //坦克向左走
            {
                ud = 0;
                rl = -1;
            }
            else if (num > 2 && num <= 4)//坦克向下走
            {
                ud = 0;
                rl = 1;
            }
            DirChangeTime = 0;
           // moveSpeed = Random.Range(5, 8);
        }
        else
            DirChangeTime += Time.fixedDeltaTime;
           // Debug.Log("fixedDeltatimetime:" + Time.fixedDeltaTime);
        //开始移动

        transform.Translate(Vector3.right * rl * moveSpeed * Time.fixedDeltaTime, Space.World);//垂直移动

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

        transform.Translate(Vector3.up * ud * moveSpeed * Time.fixedDeltaTime, Space.World);//垂直移动

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
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEuluerAngels));
        timeVal = 0;
    }



    private void TankDie()//坦克的死亡方法
    {
        // if (isDefended)//如果玩家无敌则不会死亡
        // return;
        Draw_UI.Instance.KillPoint ++;
        //产生爆炸特效
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        //死亡
        Destroy(gameObject);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)//碰撞检测
    {
        if (collision.gameObject.tag == "wall_iron")//如果两个敌人碰到一起就让他们方向发生改变，不用挤到一起
            DirChangeTime = 2;
        else if (collision.gameObject.tag == "tank_player")
            DirChangeTime = 2;
        else if (collision.gameObject.tag == "enemy")
            DirChangeTime = 2;
    }

}
