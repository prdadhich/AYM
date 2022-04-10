using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class PlayVideo : MonoBehaviour
{

    private VideoClip English;
    private VideoClip Arabic;
    private VideoPlayer videoPlayer;

    private bool _isEnglish = false;
    private bool _isArabic = false;


    public GameObject Audio;
    public GameObject VideoButton;

    PlayAudio _audio;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        English = Resources.Load<VideoClip>("English") as VideoClip;
        Arabic = Resources.Load<VideoClip>("Arabic") as VideoClip;
        
        _audio = Audio.GetComponent<PlayAudio>();
        VideoButton.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_isArabic || _isEnglish)
        {

           StartCoroutine(nameof (VideoEnded));
        }
    }

    public void isEnglish()
    {
        videoPlayer.clip = English;
        videoPlayer.Play();
        VideoButton.SetActive(true);

        if (_isArabic)
        {
            _isEnglish = false;

        }
        else
        { 
        _isEnglish = true;

        }


    }
    public void isArabic()
    {
        if (_isEnglish)
        {
        _isArabic = false;

        }
        else
        {
            _isArabic = true;

        }
        videoPlayer.clip = Arabic;
        videoPlayer.Play();
        VideoButton.SetActive(true);



    }

    IEnumerator  VideoEnded()
    {



        yield return new WaitForSecondsRealtime(45);
        if(!videoPlayer.isPlaying)
            _audio.PlaySignUp();
            _isEnglish = false;
            _isArabic=false;
        
    }


    public void Pause()
    {
        videoPlayer.Pause();
        videoPlayer.Stop();
        _audio.PlaySignUp();


    }


    public void OpenBrowser()
    {

        Application.OpenURL("www.google.com");
    }

}
