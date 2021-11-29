using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Draw_UI : MonoBehaviour
{
    public int PlayerLife = 30;
    public int KillPoint = 0;
    public bool isDead;
    public Text text_life;
    public Text text_score;
    public GameObject Born;//重生的特效

    //单例
    private static Draw_UI instance;

    public static Draw_UI Instance
    {
        get => instance;
        set => instance = value;
    }


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            Reborn();

        GameObject.Find("Canvas/Text_life").GetComponent<Text>().text = "Life :" + PlayerLife.ToString();
        GameObject.Find("Canvas/Text_score").GetComponent<Text>().text = "Score :" + KillPoint.ToString();
        if(KillPoint == 10)
        {
            SceneManager.LoadScene("Congratulation");
        }
    }

    public void Reborn()
    {
        if (PlayerLife == 0)
        {
            SceneManager.LoadScene("Game over");
        }
        else
        {
            PlayerLife--;
            //实例化玩家
            GameObject player = Instantiate(Born, new Vector3(-2, -8, 0), Quaternion.identity);
            player.GetComponent<born_start>().createPlayer = true;
            isDead = false;
        }
    }
}
