using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Collector")){
        }
    }
}
