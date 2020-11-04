using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 軌道位置列舉
public enum Rail {
    Center,
    Left,
    Right
}

public class Player : MonoBehaviour
{
    // 紀錄觸控一開始的座標（用於後面計算拖曳方向）
    Vector2 startTouchPos;

    // 角色目標軌道
    Rail desireRail = Rail.Center;


    // 遊戲迴圈
    void Update()
    {
        // 處理移動方向
        UpdateDesireRail();

        // 更新角色位置
        UpdatePosition();
    }

    // 處理移動方向
    private void UpdateDesireRail()
    {
        // 如果有觸碰 (touches陣列有內容)
        if (Input.touches.Length > 0)
        {
            // 觸碰開始（只執行一次）
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                // 紀錄觸碰座標
                startTouchPos = Input.touches[0].position;
            }

            // 觸碰結束（只執行一次）
            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                // 計算觸碰滑動距離
                Vector2 delta = startTouchPos - Input.touches[0].position;

                // 左右滑動
                if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y) )
                {
                    if (delta.x > 0)
                        GoLeft();
                    else
                        GoRight();
                }

                // 上下滑動
                else
                {
                    if (delta.y < 0)
                        Jump();
                }
            }
        }
    }

    // 更新角色位置
    private void UpdatePosition()
    {
        // 將目標軌道轉換為座標
        float dx = 0;
        if (desireRail == Rail.Center)
            dx = 0;
        else if(desireRail == Rail.Left)
            dx = -2;
        else if(desireRail == Rail.Right)
            dx = 2;

        // 變更角色座標
        float x = transform.position.x + (dx - transform.position.x) / 5; // 漸進式移動
        float y = transform.position.y;  // 不變
        float z = transform.position.z;  // 不變
        transform.position = new Vector3(x, y, z);
    }

    // 向左
    private void GoLeft()
    {
        if (desireRail == Rail.Center)
            desireRail = Rail.Left;
        else if (desireRail == Rail.Right)
            desireRail = Rail.Center;
    }

    // 向右
    private void GoRight()
    {
        if (desireRail == Rail.Center)
            desireRail = Rail.Right;
        else if (desireRail == Rail.Left)
            desireRail = Rail.Center;
    }

    // 跳躍
    private void Jump()
    {
        Debug.Log("Jump!"); // 還沒實作
    }
}
