using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePointRange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyBase>().OutLineOn();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyBase>().OutLineOff();

        }
    }
}
