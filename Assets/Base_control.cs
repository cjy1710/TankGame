using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
public class Base_control : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;//渲染的组件
    public Sprite HeartBroken;//死亡图                            
    public GameObject explosionPrefab;//爆炸特效的预制体

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();//获取渲染的组件

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HeartDie()//老家中枪，游戏结束
    {
        spriteRenderer.sprite = HeartBroken;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Thread.Sleep(2000);
        SceneManager.LoadScene("Game over");
    }
  
}
