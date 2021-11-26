using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.167f);//在0.167s的爆炸后删除特
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
