using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingScript : MonoBehaviour {

    //If Water Bool
    private bool isWater;

    //Random Timer
    private float Timer;
    private bool TimeIsUp = false;

    //Fishes
    private string[] Fishes = {"Salmon", "Shad", "Trout", "Perch", "Char", "Pike"};
    private string Fish;
    private float weight;

    //isCaught
    private bool isFishing = false;

    //Add Random Objects? ------------

	void Update () {

        //Check to see if Player is moving
        if (RPGMovementSystem.IsMoving == false)
        {
            //<Check if Fishing Rod is Equiped>

            //Start Fishing --------------------------
            if (Input.GetKeyDown(KeyCode.F) && isFishing == false)
            {
                if (isWater == true)
                {
                    isFishing = true;
                    RandomGenerator();
                    print("Fishing");
                    //PlayFishingAnim
                }
            }

            //Catch Logic ---------------------------

            if (Timer >= 0)
                Timer -= Time.deltaTime;

            if (Timer <= 2 && Timer >= 0 && TimeIsUp == true && isFishing == true)
            {
                if (Input.GetKey(KeyCode.F))
                {
                    //PlayFishOnAnim
                    TimeIsUp = false;
                    Catch();
                }
            }

            if (Timer < 0)
                //StopFishingAnim
                isFishing = false;
                TimeIsUp = false;
        }
        else
        {
            Timer = 0;
            TimeIsUp = false;
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Water")
        {
            isWater = true;
            print("Water");
        }         
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Water")
        {
            isWater = false;
            print("Leaving");
        }
    }

    void RandomGenerator()
    {
        Timer = Random.Range(0, 40);
        Fish = Fishes[Random.Range(0, Fishes.Length)];
        weight = Random.Range(2, 10);
        TimeIsUp = true;
    }

    void Catch()
    {        
        //Play Caught Anim
        print("You Caught a: " + Fish + " , It Weighed: " + weight);
        //Add Fish to Inventory
    }
}
