using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePackBehavController : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float DashSpeed = 0;

    [SerializeField]
    float MinAngle = 0;

    public bool Attacked = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void Attack(Transform playerPos)
    {
        // Face player and dash towards them dealing damage
        if (Vector3.Dot(transform.forward, (playerPos.position - transform.position).normalized) < MinAngle)
        {
            transform.LookAt(playerPos);
        }
        else
        {

            rb.AddForce(transform.forward * DashSpeed, ForceMode.Impulse);
            Attacked = true;
            StartCoroutine("ResetAttack");
        }


    }




    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(2.0f);
        Attacked = false;

    }

}
