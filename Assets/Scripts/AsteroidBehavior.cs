using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class AsteroidBehavior : MonoBehaviour
{
    public float Speed = 1.0f;
    public float HitRange = 1.0f;

    private GameObject Player { get; set; }

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
    void Destroy()
    {
        Destroy(this.gameObject);
    }

	void Update ()
    {
        if (Player != null)
        {
            this.transform.Translate((Player.transform.position - this.transform.position).normalized * Speed);
            if ((Player.transform.position - this.transform.position).magnitude <= HitRange)
                Destroy();
        }
    }

    void OnMouseDown()
    {
        Destroy();
    }
}
