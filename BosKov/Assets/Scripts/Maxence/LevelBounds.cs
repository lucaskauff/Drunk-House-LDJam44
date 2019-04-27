using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BosKov
{
    public class LevelBounds : MonoBehaviour
    {
        void OnTriggerExit2D(Collider2D other)
        {
            GameObject player = other.transform.parent.gameObject;

            if (player.CompareTag("Player")) { Destroy(player); }
        }
    }
}
