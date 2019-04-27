using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BosKov
{
    public class Enemy1Behaviour : MonoBehaviour
    {
        [Header("My Components")]
        [SerializeField] SpriteRenderer mySpriteRend = default;
        [SerializeField] Collider2D myCollider = default;

        [Header("Serializable")]
        [SerializeField] float enemySpeed = 1;

        [Header("Public")]
        public Transform targetPoint = null;
        public bool isFired = false;

        private bool isFiredCheck = false;

        private void Update()
        {
            if (isFired)
            {
                if (!isFiredCheck)
                {
                    mySpriteRend.enabled = true;
                    myCollider.enabled = true;

                    isFiredCheck = true;
                }

                MoveTowardsTarget();

                if (transform.position == targetPoint.position)
                {
                    Destroy(gameObject);
                }
            }
        }

        private void MoveTowardsTarget()
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, enemySpeed * Time.deltaTime);
        }
    }
}