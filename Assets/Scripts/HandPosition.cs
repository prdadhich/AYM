using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;
public class HandPosition : MonoBehaviour
{
    private UnityEngine.Vector3 position;
    public GameObject cylinder;
    bool isRotating = false;
    private float _time = 0;



    public List<int> prize;
    public List<AnimationCurve> animationCurves;
    // public List<AnimationCurve> animationCurves;

    private bool spinning;
    private float anglePerItem;
    private int randomTime;
    private int itemNumber;
    // Start is called before the first frame update


    

    void Start()
    {
        anglePerItem = 360 / prize.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (Microsoft.MixedReality.Toolkit.Input.HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose))
        {
            position = pose.Position;
            //Debug.Log(position);
        }
         

        /*    if(spinning)
        {
            randomTime = Random.Range(1, 4);
            itemNumber = Random.Range(0, prize.Count);
            float maxAngle = 360 * randomTime + (itemNumber * anglePerItem);

            StartCoroutine(SpinTheWheel(5 * randomTime, maxAngle));
           // StartCoroutine("rotatecylinder");

        }
        */


    }

    /* public void RotationStart()
     {
         isRotating = true;
         spinning = true;
         _time = 5000;

         Debug.Log("Rotation");

     }

     IEnumerator rotatecylinder()
     {

         Quaternion target = Quaternion.Euler(-90, 0, 7660);
         cylinder.transform.rotation = Quaternion.Slerp(cylinder.transform.rotation, (cylinder.transform.rotation)*target, Time.deltaTime * 5);
         yield  return new WaitForSecondsRealtime(5);
         isRotating = false;
     }



     IEnumerator SpinTheWheel(float time, float maxAngle)
     {
         spinning = true;

         float timer = 0.0f;
         float startAngle = cylinder.transform.eulerAngles.z;
         maxAngle = maxAngle - startAngle;

         int animationCurveNumber = Random.Range(0, animationCurves.Count);
         Debug.Log("Animation Curve No. : " + animationCurveNumber);

         while (timer < time)
         {
             //to calculate rotation
             float angle = maxAngle * animationCurves[animationCurveNumber].Evaluate(timer / time);
             cylinder.transform.eulerAngles = new Vector3(0.0f, 0.0f, angle + startAngle);
             timer += Time.deltaTime;
             yield return 0;
         }

         cylinder.transform.eulerAngles = new Vector3(0.0f, 0.0f, maxAngle + startAngle);
         spinning = false;

         Debug.Log("Prize: " + prize[itemNumber]);//use prize[itemNumnber] as per requirement
     }*/



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Right IndexTip ")
        {
            Microsoft.MixedReality.Toolkit.Input.HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose);
            Debug.Log(pose.Position);

        }
    }





}

