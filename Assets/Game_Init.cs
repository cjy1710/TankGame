using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Init : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //0.老家 1.墙 2.障碍 3.出生效果 4.河流 5.草 6.空气墙
    public GameObject[] item;//初始地图所需物体的数组

    private void Awake()//对地图进行实例化
    {
        
        //实例化边界的空气墙
        for (int i = -11; i < 12; i++)
        {
            CreateItem(item[6], new Vector3(i, 9, 0), Quaternion.identity);//上面的围墙
            CreateItem(item[6], new Vector3(i, -9, 0), Quaternion.identity);//下面的围墙
        }

        for (int i = -9; i < 9; i++)
        {
            CreateItem(item[6], new Vector3(-11, i, 0), Quaternion.identity);//左边的围墙
            CreateItem(item[6], new Vector3(11, i, 0), Quaternion.identity);//右边的围墙
        }
        //实例化玩家
        GameObject player = Instantiate(item[3], new Vector3(-2, -8, 0), Quaternion.identity);
        itemPosList.Add(new Vector3(-2, -8, 0));//将玩家的位置添加到列表中
        player.GetComponent<born_start>().createPlayer = true;

        //实例化敌人
        CreateItem(item[3], new Vector3(-10, 8, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(0, 8, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(10, 8, 0), Quaternion.identity);

        InvokeRepeating("CreateEnemy", 5f, 10f);//延迟调用，第一次4s后随机产生敌人，随后每隔5s产生敌人
        //实例化老家
        CreateItem(item[0], new Vector3(0, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(-1, -8, 0), Quaternion.identity);//老家旁边的保护墙
        CreateItem(item[1], new Vector3(1, -8, 0), Quaternion.identity);//老家旁边的保护墙
        CreateItem(item[1], new Vector3(-1, -7, 0), Quaternion.identity);//老家旁边的保护墙
        CreateItem(item[2], new Vector3(0, -7, 0), Quaternion.identity);//老家旁边的保护墙
        CreateItem(item[1], new Vector3(1, -7, 0), Quaternion.identity);//老家旁边的保护墙
        //实例化场景
        for (int i = 0; i < 20; i++)//每个种类产生20个
        {
            CreateItem(item[1], CreatePosRandomly(), Quaternion.identity);//实例化墙
            CreateItem(item[1], CreatePosRandomly(), Quaternion.identity);//实例化墙
            CreateItem(item[1], CreatePosRandomly(), Quaternion.identity);//实例化墙
            CreateItem(item[2], CreatePosRandomly(), Quaternion.identity);//实例化障碍
            CreateItem(item[4], CreatePosRandomly(), Quaternion.identity);//实例化河流
            CreateItem(item[5], CreatePosRandomly(), Quaternion.identity);//实例化草
        }
     
    }

    private void CreateItem(GameObject obj, Vector3 pos, Quaternion qua)//创建物体到Map里
    {
        GameObject createObj = Instantiate(obj, pos, qua);//实例化游戏物体
        createObj.transform.SetParent(gameObject.transform);//设置父物体
    }

    public List<Vector3> itemPosList = new List<Vector3>();//用于存放已经生成的位置

    private Vector3 CreatePosRandomly()//产生随机位置
    {
        //约束最外围的边界不产生物体，确保可以通行(x=-10,10,y=-8,8)
        while (true)
        {
            Vector3 tempPos = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);//产生一个随即位置
            for (int i = 0; i < itemPosList.Count; i++) //判断列表中是否存在该位置
            {
                if (tempPos == itemPosList[i])
                    continue;
            }
            return tempPos;
        }
    }

    private void CreateEnemy()//产生敌人
    {
        int num = Random.Range(0, 3);
        Vector3 enemyPos = new Vector3();
        if (num == 0)
            enemyPos = new Vector3(-10, 8, 0);
        else if (num == 1)
            enemyPos = new Vector3(0, 8, 0);
        else if (num == 2)
            enemyPos = new Vector3(10, 8, 0);
        CreateItem(item[3], enemyPos, Quaternion.identity);//在随机位置产生敌人

    }

}
