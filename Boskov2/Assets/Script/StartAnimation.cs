using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    [SerializeField] GameObject gameAnim;
    [SerializeField] GameObject overAnim;
    [SerializeField] float speed;

    [Header("Speed Management")]
    [SerializeField] private float height;
    [SerializeField] private float highestPointCoord;
    [SerializeField] private float thickness;

    private NormalDistribution curve;
    private Vector2[] startPos = new Vector2[2];

    private void Start()
    {
        curve = new NormalDistribution(height, highestPointCoord, thickness);
        startPos[0] = gameAnim.transform.position;
        startPos[1] = overAnim.transform.position;
    }

    private void OnEnable()
    {
        StartCoroutine(StopThis());
    }


    private void Update()
    {
        anim();
    }

    private void anim()
    {
        float value = curve.GetValueFrom(gameAnim.transform.localPosition.x) + 1.002f;
        gameAnim.transform.Translate(Vector2.right * value * speed);
        overAnim.transform.Translate(Vector2.left * value * speed);
    }

    private IEnumerator StopThis()
    {
        yield return new WaitForSecondsRealtime(2);

        ResetPos();
        gameObject.SetActive(false);
    }

    private void ResetPos()
    {
        gameAnim.transform.position = startPos[0];
        overAnim.transform.position = startPos[1];
    }

}
