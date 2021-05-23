using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    public Material mPicker;
    public FlexibleColorPicker fcp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mPicker.color = fcp.color;
    }

    void OnClick()
    {
        //mPicker = fcp.transform.GetChild(8).GetChild(0).GetComponent<CanvasRenderer>().GetMaterial();
    }
}
