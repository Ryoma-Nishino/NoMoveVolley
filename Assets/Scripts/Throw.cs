using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Transform target;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;

    public void Start()
    {
        StartCoroutine(SimulateProjectile());
    }

    IEnumerator SimulateProjectile()
    {
        // 初期位置を取得
        Vector3 startPos = transform.position;

        // 目標までの距離を計算
        float target_Distance = Vector3.Distance(startPos, target.position);

        // 初速度を計算
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // X軸とY軸の速度を計算
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // 飛行時間を計算
        float flightDuration = target_Distance / Vx;

        // 投射体を飛ばす
        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            transform.position = new Vector3(startPos.x + Vx * elapse_time, startPos.y + Vy * elapse_time - (0.5f * gravity * Mathf.Pow(elapse_time, 2)), startPos.z);
            elapse_time += Time.deltaTime;
            yield return null;
        }
    }
}
