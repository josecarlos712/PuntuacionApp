using UnityEngine;
using UnityEngine.UI;
using System;

public class ColorPicker : MonoBehaviour
{
    public Material mPicker;
    public FlexibleColorPicker fcp;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponentInChildren<Button>().onClick.AddListener(OnClick);
        mPicker.color = Color.white;
    }
    // Update is called once per frame
    void Update()
    {
        Color c = fcp.color;
        //Color c = UnityEngine.Random.ColorHSV();
        mPicker.color = c;
    }

    void OnClick()
    {
        Debug.Log("Cambio de color");
        //mPicker = fcp.transform.GetChild(8).GetChild(0).GetComponent<CanvasRenderer>().GetMaterial();
    }
}
