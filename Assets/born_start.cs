using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class born_start : MonoBehaviour
{
    public bool createPlayer;//是否产生玩家
    public GameObject playerPrefab;//玩家的预制体
    public GameObject[] enemyPrefabList;//敌人预制体的列
   // public GameObject[] enemyPrefabList2 = new GameObject[3];//敌人预制体的列

    // Start is called before the first frame update
    void Start()
    {
        Invoke("TankBorn", 1f);//延迟调用1s后产生坦克
        Destroy(gameObject, 1f); //延迟1s销毁出生特效
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void TankBorn()//产生坦克
    {
        if (createPlayer)
            Instantiate(playerPrefab, transform.position, Quaternion.identity);//实例化玩家
        else
        {
            int num = Random.Range(0, 2);
            Instantiate(enemyPrefabList[num], transform.position, Quaternion.identity);//实例化敌人
        }
    }
}