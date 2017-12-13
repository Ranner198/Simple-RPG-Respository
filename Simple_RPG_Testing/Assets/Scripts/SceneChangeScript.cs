using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChangeScript : MonoBehaviour {

    //Get Next Teleporter Location
    public Transform NextPosition;

    //Player Pos
    public Transform Player;

    //ForFade
    public Texture2D FadeOutTexture2D;
    public float TransitionSpeed = 0.5f;
    private int drawDepth = -1000; //Lower Num = Higher the hiarchy on the render
    private float alpha = 1.0f;
    private int fadeDir = -1; //Which way to fade
    public float MyTimer = 2;
    private float Timer;
    private bool hasFaded = false;

    void Update()
    {
        if (Timer >= 0)
        {
            Timer -= Time.deltaTime;            
        }

        if (Timer <= 1 && Timer >= .25f && hasFaded == true)
            OnCall();

        if (Timer <= 0 && hasFaded == true)
        {
            hasFaded = false;
            Backwards(-1);
        }
    }

    void OnCollisionEnter(Collision coll)
    {       
        if (coll.gameObject.tag == "Player")
        {
            //Call     
            Timer = MyTimer;
            BeginFade(1);            
            hasFaded = true;
        }
    }

    //Changing Locations
    void OnGUI()
    {
        //Fade
        alpha += fadeDir * TransitionSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        //set color
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), FadeOutTexture2D);
    }

    
    public float BeginFade(int direction)               //Fadeout
    {
        fadeDir = direction;
        return (TransitionSpeed);       
    }

    public float Backwards(int dir2)                    //Fadein
    {
        fadeDir = dir2;
        return (TransitionSpeed);
    }

    void OnCall()
    {
        //MovePlayer To Position        
        Player.transform.position = NextPosition.transform.position;
        RPGMovementSystem.shouldReset = true;
    }  
}
