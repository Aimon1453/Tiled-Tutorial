using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2.0f;
    public float timer = 3.0f;

    private Vector3 direction = Vector3.right;
    private float timerCounter;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        timerCounter = timer;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        timerCounter -= Time.deltaTime;
        if (timerCounter <= 0f)
        {
            // 反向移动
            direction = -direction;
            timerCounter = timer;
        }
    }

    // 外部设置平台参数
    public void SetPlatform(float newSpeed, float newTimer)
    {
        speed = newSpeed;
        timer = newTimer;
        timerCounter = timer;
    }

    private void OnDrawGizmos()
    {
        if (speed > 0 && timer > 0)
        {
            float distance = speed * timer;
            Vector3 start = Application.isPlaying ? startPosition : transform.position;
            Vector3 end = start + Vector3.right * distance;

            Gizmos.color = Color.green;
            Gizmos.DrawLine(start, end);
            Gizmos.DrawWireCube(start, Vector3.one * 0.5f);
            Gizmos.DrawWireCube(end, Vector3.one * 0.5f);
        }
    }
}
