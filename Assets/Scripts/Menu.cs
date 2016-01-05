using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Menu : MonoBehaviour {
	public void LoadScene(string SceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
    }

    public void Calibrate()
    {
        if (Framework.RunningOnPc())
        {
            Framework.Calibration = GameObject.FindGameObjectWithTag("Debug").transform.rotation;
        }
        else
        {
            Input.gyro.enabled = true;
            Framework.Calibration = Input.gyro.attitude;
        }
    }
}
