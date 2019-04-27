using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BosKov
{
    public class PlayerController : MonoBehaviour
    {
        float moveValue;
        [SerializeField] float speed;

        void Update()
        {
            Move();
        }

        void Move()
        {
            moveValue = Input.GetAxisRaw("Vertical");
            transform.Translate(new Vector3(0, moveValue * speed * Time.deltaTime, 0));
        }
    }
}

