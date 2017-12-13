using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightTimer : MonoBehaviour {

    public float Timer;
	
	void Update () {
        transform.Rotate(Timer * Time.deltaTime, 0, 0);
	}
}
