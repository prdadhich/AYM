using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioClip folloMeAudioClip;
    private AudioClip thankAudioClip;
    private AudioClip helloAudioClip;
    private AudioClip knowMoreAudioClip;
    private AudioClip Discount10;
    private AudioClip Discount25;
    private AudioClip Discount50;
    private AudioClip TryAgain;
    private AudioClip NextTime;
    private AudioClip Ethereum;
    private AudioClip FreeAnnual;
    private AudioClip SignUp;

    private bool winAudioFirst = true;


    private int indexTranform = 0;

    private bool _isgameStart = false;
    

    private AudioSource audioSource;


    public  Transform[] WhichLocation;
    public GameObject GetWin;
    
    
    CheckTrigger winname;
    ButtonShow toggle;
  
    public static Transform LocationTransform;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        folloMeAudioClip = Resources.Load<AudioClip>("FolloMe") as AudioClip;
        thankAudioClip = Resources.Load<AudioClip>("Thankyou") as AudioClip;
        knowMoreAudioClip = Resources.Load<AudioClip>("Knowmore") as AudioClip;
        helloAudioClip = Resources.Load<AudioClip>("Hello") as AudioClip;
        Discount50 = Resources.Load<AudioClip>("Discount50") as AudioClip;
        Discount10 = Resources.Load<AudioClip>("Discount10") as AudioClip;
        Discount25 = Resources.Load<AudioClip>("Discount25") as AudioClip;
        TryAgain = Resources.Load<AudioClip>("TryAgain") as AudioClip;
        NextTime = Resources.Load<AudioClip>("NextTime") as AudioClip;
        Ethereum = Resources.Load<AudioClip>("Ethereum") as AudioClip;
        FreeAnnual = Resources.Load<AudioClip>("Annual") as AudioClip;
        SignUp = Resources.Load<AudioClip>("SignUp") as AudioClip;



        LocationTransform = this.transform;
        winname = GetWin.GetComponent<CheckTrigger>(); 
        toggle= GetComponent<ButtonShow>();
       
        

    }
    private void Awake()
    {
        _isgameStart = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (_isgameStart)
        {
            StartCoroutine(nameof(PlayHello));

        }
        if (winname.WinWhat != "" && winAudioFirst == true)
        {


            if (winname.WinWhat.Equals("green"))
            {
                audioSource.clip = Discount10;

            }
            if (winname.WinWhat.Equals("yellow"))
            {
                audioSource.clip = Ethereum;

            }
            if (winname.WinWhat.Equals("red"))
            {
                audioSource.clip = FreeAnnual;

            }
            if (winname.WinWhat.Equals("white"))
            {
                audioSource.clip = NextTime;

            }
            if (winname.WinWhat.Equals("blue"))
            {
                audioSource.clip = TryAgain;

            }
            if (winname.WinWhat.Equals("orange"))
            {
                audioSource.clip = Discount50;

            }
            if (winname.WinWhat.Equals("lightblue"))
            {
                audioSource.clip = Discount25;

            }
            StartCoroutine(nameof(PlayWin));
           Debug.Log("kya yaar "+ winname.WinWhat);

        }
     
      
    }


    public void PlaySignUp()
    {

        audioSource.clip = SignUp;
        audioSource.Play();
       // toggle.ToggleShow();


    }

    IEnumerator PlayHello()
    {
        _isgameStart = false;
        if (helloAudioClip != null)
            audioSource.clip = helloAudioClip;
        yield return new WaitForSecondsRealtime(4f);
        audioSource.Play();
        yield return new WaitForSecondsRealtime(helloAudioClip.length);
        LocationTransform = WhichLocation[indexTranform];
       


    }
    private void UpdateLocation()
    {
        LocationTransform = WhichLocation[indexTranform];
    }

  

    private void ExitGame()
    {
        audioSource.clip = thankAudioClip;
        audioSource.Play();
    
    }

    public void  Yes()
    {
        indexTranform++;
        UpdateLocation();
        if(indexTranform > WhichLocation.Length)
        {
            ExitGame();
        }

        

    }

    public void No()
    {
        ExitGame();
        
    }


     IEnumerator PlayWin()
    {


       // yield return new WaitForSecondsRealtime(3);
        winAudioFirst = false;

        //yield return new WaitForSeconds(5);
      
        audioSource.Play();

        yield return new WaitForSeconds(4);
       

        audioSource.clip = knowMoreAudioClip;
        audioSource.Play();
        yield return new WaitForSeconds(3);
        toggle.ToggleShow();



    }


}
