
using System;
using UnityEngine;

public class EnemyGuardTrigger : MonoBehaviour
{
    public Action<GameObject> TriggerEnter;
    public Action<GameObject> TriggerExit;

    private void OnTriggerEnter2D(Collider2D other)
    {
      if(other?.GetComponentInParent<PlayerControls>())   TriggerEnter?.Invoke(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other?.GetComponentInParent<PlayerControls>()) TriggerExit?.Invoke(other.gameObject);
    }
}


