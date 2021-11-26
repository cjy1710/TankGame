using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_attack : MonoBehaviour
{

    public bool isPlayerBullet;//判断是否为玩家的子弹

    public float BulletMoveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * BulletMoveSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)//根据碰撞物体的标签来响应事件
        {
            case "wall_dirt":
                Destroy(collision.gameObject);//销毁
                Destroy(gameObject);//销毁子弹
                break;
            case "wall_iron":
                Destroy(gameObject);//销毁子弹
                break;
            case "wall_air":
                Destroy(gameObject);//销毁子弹
                break;
            case "base_home":
                Destroy(gameObject);//销毁子弹
                collision.SendMessage("HeartDie");
                break;
            case "tank_player":
                if (!isPlayerBullet)
                {
                    Destroy(gameObject);//销毁子弹
                    collision.SendMessage("TankDie");
                }
                break;
            case "enemy":
                if (isPlayerBullet)
                {
                    Destroy(gameObject);//销毁子弹
                    collision.SendMessage("TankDie");
                }
                break;
            default:
                break;
        }
    }

}
