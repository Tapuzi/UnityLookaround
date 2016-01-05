// Note: This is not used.

using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class ClickHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject debugMousePlace = GameObject.FindGameObjectWithTag("Debug");

            debugMousePlace.transform.position = Input.mousePosition;
       }
    }
}