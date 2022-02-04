using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;


public class CheckCollision : MonoBehaviour
{
    
   //public Collider green;
    private bool isCollsiion = false;
    private GameObject hand;
    private Vector3 collPos;
    private Vector3 newCollPos;
    private Vector3 oldDir;
    private Vector3 newDir;
    private Vector3 rotAxis = new Vector3(0, 0, -1);

    CheckTrigger trigger;
    public GameObject arrow;

    public Collider[] winner;
   //public  CheckTrigger trigger;

    public List<int> prize;
    public List<AnimationCurve> animationCurves;
    // public List<AnimationCurve> animationCurves;

    private bool spinning;
    private float anglePerItem;
    private int randomTime;
    private int itemNumber;
    private bool firstTime = true;
    // Start is called before the first frame update
    void Start()
    {
        anglePerItem = 360 / 7;
        /*foreach(var col in winner)
        {
            col.enabled = false;
        }*/
        trigger = arrow.GetComponent<CheckTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isCollsiion && hand!=null )
        {
            Microsoft.MixedReality.Toolkit.Input.HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose);
            oldDir = collPos - this.transform.position;
            newDir = pose.Position - this.transform.position;
           var dot = Vector3.Dot(oldDir, newDir);
            var magOld = Vector3.Magnitude(oldDir);
            var magNew = Vector3.Magnitude(newDir);
            var angle = Mathf.Acos((dot) / (magOld * magNew));
            transform.rotation = Quaternion.AngleAxis(angle* Mathf.Rad2Deg, rotAxis);
                
        }
        if (spinning && isCollsiion == false)
        {
            randomTime = Random.Range(1, 4);
            itemNumber = Random.Range(0, prize.Count);
            float maxAngle = 360 * randomTime + (itemNumber* anglePerItem);

            StartCoroutine(SpinTheWheel(5 * randomTime, maxAngle));
           // Invoke("GameFinished",8*randomTime*Time.deltaTime);
            // StartCoroutine("rotatethis");

        }

    }
    /* private void OnCollisionEnter(Collision other)
     {
         Debug.Log($"Hit by: {other.gameObject.name} {Time.time}");
     }
    */

     private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.name == "Right IndexTip" && firstTime)
         {
            //Microsoft.MixedReality.Toolkit.Input.HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose);
            isCollsiion = true;
            hand= collision.gameObject;
            collPos = collision.gameObject.transform.position;
            // Debug.Log(collision.gameObject.transform.position);

         }
     }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Right IndexTip")
        {
            // Microsoft.MixedReality.Toolkit.Input.HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose);
            isCollsiion = false;
            hand = null;
            spinning = true;
            firstTime = false;
            

           // Debug.Log(collision.gameObject.transform.position);

        }
    }

    

    IEnumerator SpinTheWheel(float time, float maxAngle)
    {
        // spinning = true;
        firstTime = false;
        float timer = 0.0f;
        float startAngle = this.transform.eulerAngles.z;
        maxAngle = maxAngle - startAngle;
        float angle = 0;
        int animationCurveNumber = Random.Range(0, animationCurves.Count);
       // Debug.Log("Animation Curve No. : " + animationCurveNumber);

        while (timer < time)
        {
            //to calculate rotation
             angle = maxAngle * animationCurves[animationCurveNumber].Evaluate(timer / time);
            //this.transform.eulerAngles = new Vector3(0.0f, 0.0f, angle + startAngle);
            this.transform.Rotate(0.0f, 0.0f, (angle + startAngle));

            timer += Time.deltaTime;
           yield return 0;
          
        }

      //  this.transform.eulerAngles = new Vector3(0.0f, 0.0f, maxAngle + startAngle);
        spinning = false;

        yield return new WaitForSecondsRealtime(20);
       // if(trigger != null)
        trigger.GameFinished();
        

        //Debug.Log("Prize: " + prize[itemNumber]);//use prize[itemNumnber] as per requirement


    }



}
