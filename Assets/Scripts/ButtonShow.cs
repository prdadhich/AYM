using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine.UI;
public class ButtonShow : MonoBehaviour
{
    public GameObject Yes;
    public GameObject No;

    // Start is called before the first frame update
    void Start()
    {
        Yes.SetActive(false);
        No.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleShow()
    {
        Yes.SetActive(!Yes.activeSelf);
        No.SetActive(!No.activeSelf);

    }
}
