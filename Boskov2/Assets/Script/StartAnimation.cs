using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    [SerializeField] GameObject gameAnim;
    [SerializeField] GameObject overAnim;
    [SerializeField] float speed;

    private NormalDistribution test = new NormalDistribution(-1, -115, 50);


    private void Update()
    {
        float value = test.GetValueFrom(gameAnim.transform.localPosition.x) +1.030f;
        gameAnim.transform.Translate(Vector2.right * value * speed);
        overAnim.transform.Translate(Vector2.left * value * speed);
    }

}
