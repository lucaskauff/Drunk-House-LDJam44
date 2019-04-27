using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BosKov
{
    [ExecuteInEditMode]
    public class Cursor_Range : MonoBehaviour
    {
        [SerializeField] Transform curvePoint;
        [SerializeField] Image yCursor;
        [SerializeField] TextMeshProUGUI yRange;
        [SerializeField] TextMeshProUGUI xRange;

        Vector3 transY;

        int yOutput = 0;
        int xOutput = 0;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Y_XRange();

        }

        void Y_XRange()
        {
            transY = yCursor.transform.localPosition;
            transY.y = curvePoint.localPosition.y;
            yCursor.transform.localPosition = transY;

            yOutput = Mathf.RoundToInt(curvePoint.localPosition.y * 1000);
            yRange.text = yOutput.ToString();

            xOutput += Mathf.RoundToInt(Time.deltaTime * 10);
            xRange.text = xOutput.ToString();

            if (curvePoint.localPosition.y > 0)
            { yRange.color = new Color(0, 1, 0); }
            else
            { yRange.color = new Color(1, 0, 0); }
        }
    }
}
