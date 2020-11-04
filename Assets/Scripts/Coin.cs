using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // 旋轉速度
    float spinSpeed = 2f; 

    void Start()
    {
        
    }

    void Update()
    {
        // 累加角度 = 目前角度 + 旋轉速度 * 100(放大) * deltaTime(fps補償)
        float rz = transform.rotation.eulerAngles.z + (spinSpeed * 100) * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, rz));
    }
}
