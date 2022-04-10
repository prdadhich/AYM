using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    CheckCollision checkCollison;
    public GameObject wheelObject;

    private  Collider Arrow;
    public Collider wheel;

   [HideInInspector]
   public string WinWhat = null;

   
    // Start is called before the first frame update
    void Start()
    {
        checkCollison = wheelObject.GetComponent<CheckCollision>(); 
        Arrow = GetComponent<Collider>(); 
        //wheel = GetComponent<Collider>();   
        Arrow.enabled = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private  int count = 0;

    public  void GameFinished()
    {

        /*foreach (var col in CheckCollision.winner)
        {
            col.enabled = true;
        }*/

        //Debug.Log("Prize: " + prize[itemNumber]);

        Arrow.enabled = true;
        if (wheel.enabled)
        {
            wheel.enabled = false;

        }
        else
        {

        }
        
    }

    

    private void OnTriggerStay(Collider other)
    {
            

        if (count <2 )
        {
            Debug.Log("check trigger"+other.gameObject.name);
            count++;
            WinWhat = other.gameObject.name;    

            if(other.gameObject.name == "blue")
            {

                count = 0;
                checkCollison.firstTime = true;
            }


        }
    }
}
