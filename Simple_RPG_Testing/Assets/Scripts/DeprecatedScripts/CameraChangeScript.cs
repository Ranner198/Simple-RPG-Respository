using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeScript : MonoBehaviour {

    public Transform[] CameraPositions;

    public Transform Player;

    public int CurrentLocation = 0;

    public void Update()
    {
      
        
        if (CurrentLocation <= -1)
            CurrentLocation = 1;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CurrentLocation--;
        }
 
        transform.position = CameraPositions[CurrentLocation].transform.position;

        if (CurrentLocation > 0)
            transform.LookAt(Player);
            
    }
}
