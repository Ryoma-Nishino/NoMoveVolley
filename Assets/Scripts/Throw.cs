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
        // �����ʒu���擾
        Vector3 startPos = transform.position;

        // �ڕW�܂ł̋������v�Z
        float target_Distance = Vector3.Distance(startPos, target.position);

        // �����x���v�Z
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // X����Y���̑��x���v�Z
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // ��s���Ԃ��v�Z
        float flightDuration = target_Distance / Vx;

        // ���ˑ̂��΂�
        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            transform.position = new Vector3(startPos.x + Vx * elapse_time, startPos.y + Vy * elapse_time - (0.5f * gravity * Mathf.Pow(elapse_time, 2)), startPos.z);
            elapse_time += Time.deltaTime;
            yield return null;
        }
    }
}
