using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BoseKov
{
    [ExecuteInEditMode]
    public class Cursor_Range : MonoBehaviour
    {
        [SerializeField] Transform curvePoint;
        [SerializeField] TextMeshProUGUI yRange;
        [SerializeField] TextMeshProUGUI xRange;

        int yOutput = 0;
        int xOutput = 0;

        // Start is called before the first frame update
        void Start()
        {
            yRange = GetComponentInChildren<TextMeshProUGUI>();
            xRange = GetComponentInChildren<TextMeshProUGUI>();

        }

        // Update is called once per frame
        void Update()
        {
            Y_XRange();

        }

        void Y_XRange()
        {
            yOutput = Mathf.RoundToInt(curvePoint.localPosition.y * 1000);
            yRange.text = yOutput.ToString();

            xOutput += Mathf.RoundToInt(Time.deltaTime * 10);
            xRange.text = xOutput.ToString();
        }
    }
}
