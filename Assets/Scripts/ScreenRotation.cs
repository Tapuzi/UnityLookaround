using UnityEngine;
using System.Collections;

public class ScreenRotation : MonoBehaviour {

    private Transform Camera;

	// Use this for initialization
	void Start () {
        Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
	
	// Update is called once per frame
	void Update () {
        Quaternion current_orientation;
        Quaternion Calibration = Framework.Calibration;
        if (Framework.RunningOnPc())
            current_orientation = GameObject.FindGameObjectWithTag("Debug").transform.rotation;
        else
        {
            current_orientation = Input.gyro.attitude;
        }
        Camera.transform.localRotation = Quaternion.Inverse(Framework.Calibration) *current_orientation;

        Camera.transform.eulerAngles = new Vector3(
            -Camera.transform.eulerAngles.x,
            -Camera.transform.eulerAngles.y,
            Camera.transform.eulerAngles.z);
    }

}
