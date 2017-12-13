using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingScript : MonoBehaviour {

    public bool isPlanted = false;

    public bool CanPlant = false;

    public float Timer = -1;

    void Update () {


        if (Timer >= 0)
            Timer -= Time.deltaTime;

        if (Timer <= 0 && isPlanted)
        {
            PickTime();
        }


        //Can Plant
        if (CanPlant == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Planted();
                print("Planted");
            }
        }

	}


    void Planted()                          //On Planted
    {
        //CheckWhatsInHand
        /*
        if (WhatsInHand == Seed)
        {
            if (Seed = "Wheat")
                Timer = 110; 
            
            if (Seed = "Corn")
                Timer = 80;

            isPlanted = true;
            CanPlant = false;
            Seed--;
        }
        else
            //Print You Can Not Plant!                   
        */
    }

    void PickTime()
    {
        //Give Player Plant
        isPlanted = false;
        CanPlant = true;
    }
     

    //Check Player Loc
    void OnTriggerStay(Collider coll) //Is Player in Area
    {
        if (coll.gameObject.tag == "Player")
            CanPlant = true;
    }

    private void OnTriggerExit(Collider coll) //Player is Leaving
    {
        if (coll.gameObject.tag == "Player")
            CanPlant = false;
    }   
}
