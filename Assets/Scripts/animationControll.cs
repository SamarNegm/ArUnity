using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class animationControll : MonoBehaviour
{
    protected Vuforia.TrackableBehaviour mTrackableBehaviour;
    public Animator animator;
    public Animator animator1;
    public Animator animator2;
    public Animator animator4;
    public Animator animator6;
    public Transform moonPhaseButton;
    public AudioClip aclip2;
    public Transform solarsystem2;
    public Transform solarsystem1;
    public Transform earthOrbit;
    public Transform earthOrbit2;
    public Transform moonphases;
    public Transform watercases;
    public Transform playbtn;
    public AudioSource asource;
    public AudioClip aclip;
    public AudioClip aclip3;
    public AudioClip aclip4;
    public AudioClip aclip5;
    public AudioClip aclip6;
    public AudioClip aclip7;
    public AudioClip aclip8;
 
    public VideoPlayer videoplayer;
    public VideoPlayer videoplayerLandmarks;
    public AudioClip audioClipArabic1;
    public AudioClip audioClipArabic2;
    public AudioClip audioClipArabic3;
    public AudioClip audioClipArabic4;
    public AudioClip audioClipArabic5;
    public AudioClip audioClipArabic6;
    public AudioClip audioClipArabic7;
    public AudioClip audioClipArabic8;
    // Animation anim;
    public Sprite pausesprite;
    public Sprite playsprite;
    public Sprite moonphase;
    public Sprite all;
    int l = 0; //languge is english or the initial languge for the model
    int mp = -1;
    // Start is called before the first frame update
    void Start()
    {
        string name = NewBehaviourScript.trackablename();

        // mTrackableBehaviour = GetComponent<Vuforia.TrackableBehaviour>();
        animator = solarsystem2.GetComponent<Animator>();
        animator1 = solarsystem1.GetComponent<Animator>();
        animator2 = earthOrbit.GetComponent<Animator>();
        animator4 = earthOrbit2.GetComponent<Animator>();
        animator6 = watercases.GetComponent<Animator>();
       
        moonphases.gameObject.SetActive(false);
        //  anim = GetComponent<Animation>();
    }
    private void OnDestroy()
    {
        //playbtn.GetComponent<Image>().sprite = pausesprite;
    }

    public void playanim()
    {
        name = NewBehaviourScript.trackablename();


        Debug.Log(name);
        if (!asource.isPlaying)
        {
            if (l == 0)
            {
                if (name == "solarsystem2")
                {

                    animator1.Play("SolarSystemAnim", -1, 0f);
                    animator1.speed = 1;
                    asource.PlayOneShot(aclip);
                }
                else if (name == "solarsystem1")
                {
                    animator.Play("SolarSystemAnim2", -1, 0f);
                    animator.speed = 1;
                    asource.PlayOneShot(aclip2);

                }
                else if (name == "earthorbit2")
                {
                    animator4.Play("dayandnight", -1, 0f);
                    animator4.speed = 1;
                    asource.PlayOneShot(aclip3);

                }
               

                else if (name == "earthOrbit")
                {
                    if (mp == -1)
                    {
                        moonphases.gameObject.SetActive(false);
                        animator2.gameObject.SetActive(true);
                        animator2.Play("moon", -1, 0f);
                        animator2.speed = 1;
                        asource.PlayOneShot(aclip4);
                    }
                    else
                    {
                        asource.PlayOneShot(aclip5);
                    }

                }
                else if (name == "watercase2")
                {
                    animator6.Play("watercases", -1, 0f);
                    animator6.speed = 1;
                    asource.PlayOneShot(aclip6);

                }
                else if (name == "watervapor")
                {
                    videoplayer.Play();
                }
                else if (name == "landscape")
                {
                    videoplayer.Play();
                    //asource.Play();
                    asource.PlayOneShot(aclip7);
                }
                else if (name == "landmarks")
                {
                    videoplayerLandmarks.Play();
                    //asource.Play();
                    asource.PlayOneShot(aclip8);
                }
            }
            else
            {
                  if (name == "solarsystem2")
                    {
                        animator1.speed = 0;
                        animator1.Play("SolarSystemAnim", -1, 0f);
                        animator1.speed = 1;
                        asource.PlayOneShot(audioClipArabic2);
                    }
                    else if (name == "solarsystem1")
                    {
                        animator.speed = 0;
                        animator.Play("SolarSystemAnim2", -1, 0f);
                        animator.speed = 1;
                        asource.PlayOneShot(audioClipArabic1);

                    }
                else if (name == "landscape")
                {
                    videoplayer.Stop();
                    videoplayer.Play();
                    asource.PlayOneShot(audioClipArabic7);

                }
                else if (name == "landmarks")
                {
                    videoplayerLandmarks.Stop();
                    videoplayerLandmarks.Play();
                    asource.PlayOneShot(audioClipArabic8);

                }
                else if (name == "watercase2")
                {
                    animator6.Play("watercases", -1, 0f);
                    animator6.speed = 1;
                    asource.PlayOneShot(audioClipArabic6);

                }
           
                else if (name == "earthorbit2")
                    {
                        animator4.speed = 0;
                        animator4.Play("dayandnight", -1, 0f);
                        animator4.speed = 1;
                        asource.PlayOneShot(audioClipArabic3);

                    }
                else if (name == "earthOrbit")
                {

                    if (mp == -1)
                    {
                        moonphases.gameObject.SetActive(false);
                        animator2.speed = 0;
                        animator2.gameObject.SetActive(true);
                        animator2.Play("moon", -1, 0f);
                        animator2.speed = 1;
                        asource.PlayOneShot(audioClipArabic4);
                    }
                    else
                    {
                        asource.PlayOneShot(audioClipArabic5);
                    }

                }

                /*
                 animator.Play("SolarSystemAnim2", -1, 0f);
                 animator.speed = 1;
                 asource.PlayOneShot(aclip);
                 */


            }

            /*
             animator.Play("SolarSystemAnim2", -1, 0f);
             animator.speed = 1;
             asource.PlayOneShot(aclip);
             */
        }
        playbtn.GetComponent<Image>().sprite = pausesprite;
        //playbtn.GetComponentInChildren<Text>().text = "pause";
        Button btn = playbtn.GetComponent<Button>();
        btn.onClick.AddListener(pauseanim);

    }
    public void pauseanim()
    {
        string name = NewBehaviourScript.trackablename();
        if (l == 0)
        {

            if (name == "solarsystem2")
            {
                animator1.speed = 0;
                asource.Stop();

                // asource.Stop();
                //anim.Stop();
            }

            else if (name == "solarsystem1")
            {
                animator.speed = 0;
                asource.Stop();

            }
            else if (name == "earthorbit2")
            {
                animator4.speed = 0;
                asource.Stop();

            }
          
            else if (name == "earthOrbit")
            {
                animator2.speed = 0;
                asource.Stop();
                ;

            }
            else if (name == "watercase2")
            {
                animator6.speed = 0;
                asource.Stop();
                ;

            }
            else if (name == "watervapor")
            {
                videoplayer.Pause();
            }
            else if (name == "landscape")
            {
                videoplayer.Stop();
                asource.Stop();

            }
            else if (name == "landmarks")
            {
                videoplayerLandmarks.Stop();
                asource.Stop();

            }
        }
        else
        {
            
                if (name == "solarsystem2")
                {
                    animator1.speed = 0;

                asource.Stop();
                }
            else if (name == "watercase2")
            {
                animator6.speed = 0;
                asource.Stop();
                ;

            }
         
            else if (name == "solarsystem1")
                {
                animator.speed = 0;

                asource.Stop();

            }
                else if (name == "earthorbit2")
                {
                animator4.speed = 0;

                asource.Stop();

            }
            else if (name == "earthOrbit")
            {

                animator2.speed = 0;
                asource.Stop();
                ;

            }
            else if (name == "landscape")
            {
                videoplayer.Stop();
                asource.Stop();

            }
            else if (name == "landmarks")
            {
                videoplayerLandmarks.Stop();
                asource.Stop();

            }
            /*
             animator.Play("SolarSystemAnim2", -1, 0f);
             animator.speed = 1;
             asource.PlayOneShot(aclip);
             */

        }

        /*animator.speed = 0;
        asource.Stop();
        */

        playbtn.GetComponent<Image>().sprite = playsprite;
        //playbtn.GetComponentInChildren<Text>().text = "play";
        Button btn = playbtn.GetComponent<Button>();
        btn.onClick.AddListener(playanim);

    }
    public void switchLanguge()
    {
        l = 1;
        playbtn.GetComponent<Image>().sprite = pausesprite;
        //playbtn.GetComponentInChildren<Text>().text = "pause";
        Button btn = playbtn.GetComponent<Button>();
        btn.onClick.AddListener(pauseanim);
        asource.Stop();

        string name = NewBehaviourScript.trackablename();
        Debug.Log(name);
        if (!asource.isPlaying)
        {
            if (name == "solarsystem2")
            {
                animator1.speed = 0;
                animator1.Play("SolarSystemAnim", -1, 0f);
                animator1.speed = 1;
                asource.PlayOneShot(audioClipArabic2);
            }
            else if (name == "watercase2")
            {
                animator6.speed = 0;
                animator6.Play("watercases", -1, 0f);
                animator6.speed = 1;
                asource.PlayOneShot(audioClipArabic6);

            }
            else if (name == "solarsystem1")
            {
                animator.speed = 0;
                animator.Play("SolarSystemAnim2", -1, 0f);
                animator.speed = 1;
                asource.PlayOneShot(audioClipArabic1);

            }
            else if (name == "earthorbit2")
            {
                animator4.speed = 0;
                animator4.Play("dayandnight", -1, 0f);
                animator4.speed = 1;
                asource.PlayOneShot(audioClipArabic3);

            }
            else if (name == "landscape")
            {
                videoplayer.Stop();
                videoplayer.Play();
                asource.PlayOneShot(audioClipArabic7);

            }
            else if (name == "landmarks")
            {
                videoplayerLandmarks.Stop();
                videoplayerLandmarks.Play();
                asource.PlayOneShot(audioClipArabic8);

            }
            else if (name == "earthOrbit")
            {

                if (mp == -1)
                {
                    moonphases.gameObject.SetActive(false);
                    animator2.speed = 0;
                    animator2.gameObject.SetActive(true);
                    animator2.Play("moon", -1, 0f);
                    animator2.speed = 1;
                    asource.PlayOneShot(audioClipArabic4);
                }
                else
                {
                    asource.PlayOneShot(audioClipArabic5);
                }

            }
            /*
             animator.Play("SolarSystemAnim2", -1, 0f);
             animator.speed = 1;
             asource.PlayOneShot(aclip);
             */
        }
    }
    public void switchEnglish()
    {
        l = 0;
        playbtn.GetComponent<Image>().sprite = pausesprite;
        //playbtn.GetComponentInChildren<Text>().text = "pause";
        Button btn = playbtn.GetComponent<Button>();
        btn.onClick.AddListener(pauseanim);
        asource.Stop();

        string name = NewBehaviourScript.trackablename();
        Debug.Log(name);
        if (!asource.isPlaying)
        {
            if (name == "solarsystem2")
            {
                animator1.speed = 0;
                animator1.Play("SolarSystemAnim", -1, 0f);
                animator1.speed = 1;
                asource.PlayOneShot(aclip);
            }
            else if (name == "solarsystem1")
            {
                animator.speed = 0;
                animator.Play("SolarSystemAnim2", -1, 0f);
                animator.speed = 1;
                asource.PlayOneShot(aclip2);

            }
            else if (name == "landscape")
            {
                videoplayer.Stop();
                videoplayer.Play();
                asource.PlayOneShot(aclip7);

            }
            else if (name == "landmarks")
            {
                videoplayerLandmarks.Stop();
                videoplayerLandmarks.Play();
                asource.PlayOneShot(aclip8);

            }
            else if (name == "watercase2")
            {
                animator6.speed = 0;
                animator6.Play("watercases", -1, 0f);
                animator6.speed = 1;
                asource.PlayOneShot(aclip6);

            }
            else if (name == "earthorbit2")
            {
                animator4.speed = 0;
                animator4.Play("dayandnight", -1, 0f);
                animator4.speed = 1;
                asource.PlayOneShot(aclip3);

            }
            else if (name == "earthOrbit")
            {
                if (mp == -1)
                {
                    moonphases.gameObject.SetActive(false);
                    animator2.speed = 0;
                    animator2.gameObject.SetActive(true);
                    animator2.Play("moon", -1, 0f);
                    animator2.speed = 1;
                    asource.PlayOneShot(aclip4);
                }
                else
                {
                    asource.PlayOneShot(aclip5);
                }

            }
            /*
             animator.Play("SolarSystemAnim2", -1, 0f);
             animator.speed = 1;
             asource.PlayOneShot(aclip);
             */
        }





    }

    public void moonPhase()
    {
        Debug.Log(mp);
        if (mp == -1)
        {
            asource.Stop();
            animator2.gameObject.SetActive(false);
            moonphases.gameObject.SetActive(true);
            asource.PlayOneShot(aclip5);
            mp = 1;
            playbtn.GetComponent<Image>().sprite = pausesprite;
            moonPhaseButton.GetComponent<Image>().sprite = all;
            Button btn = playbtn.GetComponent<Button>();
            btn.onClick.AddListener(pauseanim);

        }
        else
        {
            asource.Stop();
            animator2.gameObject.SetActive(true);
            animator2.Play("moon", -1, 0f);
            animator2.speed = 1;
            moonphases.gameObject.SetActive(false);
            asource.PlayOneShot(aclip4);
            mp = -1;
            playbtn.GetComponent<Image>().sprite = pausesprite;
            moonPhaseButton.GetComponent<Image>().sprite = moonphase;
            Button btn = playbtn.GetComponent<Button>();
            btn.onClick.AddListener(pauseanim);
        }
    
    }
    
}
