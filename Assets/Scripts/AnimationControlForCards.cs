 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class AnimationControlForCards : MonoBehaviour
{
    protected Vuforia.TrackableBehaviour mTrackableBehaviour;
    public Animator animatorc;
  //  public Transform moonPhaseButton;
    public Transform wolf;
    public Transform playbtn;
    public AudioSource asource;
    public AudioClip aclip;
    public Sprite pausesprite;
    public Sprite playsprite;
    int l = 0;
    int mp = -1;
    // Start is called before the first frame update
    void Start()
    {
        string name = NewBehaviourScriptForCards.trackablename();

        // mTrackableBehaviour = GetComponent<Vuforia.TrackableBehaviour>();
        animatorc = wolf.GetComponent<Animator>();

        //  anim = GetComponent<Animation>();
    }
    private void OnDestroy()
    {
        //playbtn.GetComponent<Image>().sprite = pausesprite;
    }

    public void playanim()
    {
        name = NewBehaviourScriptForCards.trackablename();


        Debug.Log(name);
        if (!asource.isPlaying)
        {
          
                if (name == "wolf")
                {
                    animatorc.speed = 0;
                    animatorc.Play("Wolf3", -1, 0f);
                    animatorc.speed = 1;
                    asource.PlayOneShot(aclip);
                }
           
        
        }

        playbtn.GetComponent<Image>().sprite = pausesprite;
        //playbtn.GetComponentInChildren<Text>().text = "pause";
        Button btn = playbtn.GetComponent<Button>();
        btn.onClick.AddListener(pauseanim);
    }

    public void pauseanim()
    {
        string name = NewBehaviourScriptForCards.trackablename();
        if (name == "wolf")
        {
            animatorc.speed = 0;
            asource.Stop();

            // asource.Stop();
            //anim.Stop();
        }

        playbtn.GetComponent<Image>().sprite = playsprite;
        //playbtn.GetComponentInChildren<Text>().text = "play";
        Button btn = playbtn.GetComponent<Button>();
        btn.onClick.AddListener(playanim);
    }
     

    }
   

           
           
            /*
             animator.Play("SolarSystemAnim2", -1, 0f);
             animator.speed = 1;
             asource.PlayOneShot(aclip);
             */
        





    

  
    /*public void moonPhase(int mp)
    {

        if (mp == -1)
        {
            asource.Stop();
            animator2.gameObject.SetActive(false);
            moonphases.gameObject.SetActive(true);
            asource.PlayOneShot(aclip5);
            playbtn.GetComponent<Image>().sprite = pausesprite;
            mp = 1;
            moonPhaseButton.GetComponent<Image>().sprite = all;

        }
        else
        {
            asource.Stop();
            animator2.gameObject.SetActive(true);
            moonphases.gameObject.SetActive(false);
            asource.PlayOneShot(aclip4);
            mp = -1;
            playbtn.GetComponent<Image>().sprite = pausesprite;
            moonPhaseButton.GetComponent<Image>().sprite = moonphase;
        }

    }*/

