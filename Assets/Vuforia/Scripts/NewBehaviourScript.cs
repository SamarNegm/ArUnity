using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using System;
using UnityEngine.Video;
using UnityEngine;
/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
///
/// Changes made to this file could be overwritten when upgrading the Vuforia version.
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
public class NewBehaviourScript : MonoBehaviour, ITrackableEventHandler
{
    #region PROTECTED_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;



    // public AudioSource asource;
    // public AudioClip aclip;

    public VideoPlayer videoplayer;
    public VideoPlayer videoplayer2;
    public VideoPlayer videoplayer3;
    public VideoPlayer videoplayer4;
    public VideoPlayer videoplayer5;
    public VideoPlayer videoplayer6;
    public Animator animator;
    public Transform hamo3d;
    public Transform moonphases;
    // public Transform playbtn;
    public AudioSource asource;
    public AudioClip aclip;
    public Transform canvas;
    public Button arabic;
    public Button english;
    public Button pauseBtn;
    public Sprite pausesprite;

    public Button moonPhases;
    // Animation anim;
    public static string name1;

    #endregion // PROTECTED_MEMBER_VARIABLES

 
    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        //videoplayer = GetComponent<VideoPlayer>();
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        //anim = GetComponent<Animation>();
        animator = hamo3d.GetComponent<Animator>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        canvas.gameObject.SetActive(false);
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;
        
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + 
                  " " + mTrackableBehaviour.CurrentStatus +
                  " -- " + mTrackableBehaviour.CurrentStatusInfo);

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
            
            name1 = mTrackableBehaviour.TrackableName;
            if (mTrackableBehaviour.TrackableName == "solarsystem2")
            {
                canvas.gameObject.SetActive(true);
                arabic.gameObject.SetActive(true);
                english.gameObject.SetActive(true);
                moonPhases.gameObject.SetActive(false);
                animator.Play("SolarSystemAnim", -1, 0f);
                animator.speed = 1;
                asource.PlayOneShot(aclip);
         
            }
            else if (mTrackableBehaviour.TrackableName == "solarsystem1")
            {
                canvas.gameObject.SetActive(true);
                arabic.gameObject.SetActive(true);
                english.gameObject.SetActive(true);
                moonPhases.gameObject.SetActive(false);
                animator.Play("SolarSystemAnim2", -1, 0f);
                animator.speed = 1;
                asource.PlayOneShot(aclip);
              

            }
            else if (mTrackableBehaviour.TrackableName == "earthorbit2")
            {
                canvas.gameObject.SetActive(true);
                moonPhases.gameObject.SetActive(false);
                arabic.gameObject.SetActive(true);
                english.gameObject.SetActive(true);
                animator.Play("dayandnight", -1, 0f);
                animator.speed = 1;
                asource.PlayOneShot(aclip);
             

            }
            else if (mTrackableBehaviour.TrackableName == "watercase2")
            {
                canvas.gameObject.SetActive(true);
                moonPhases.gameObject.SetActive(false);
                arabic.gameObject.SetActive(true);
                english.gameObject.SetActive(true);
                animator.Play("watercases", -1, 0f);
                animator.speed = 1;
                asource.PlayOneShot(aclip);

            }
       
            else if (mTrackableBehaviour.TrackableName == "earthOrbit")
            {
                canvas.gameObject.SetActive(true);
                animator.gameObject.SetActive(true);
                moonPhases.gameObject.SetActive(true);
                arabic.gameObject.SetActive(true);
                english.gameObject.SetActive(true);
                moonphases.gameObject.SetActive(false);
                animator.Play("moon", -1, 0f);
                animator.speed = 1;
                asource.PlayOneShot(aclip);
                

            }

      
            else if (mTrackableBehaviour.TrackableName == "landscape")
            {
                canvas.gameObject.SetActive(true);
                pauseBtn.gameObject.SetActive(false);
                moonPhases.gameObject.SetActive(false);
                moonphases.gameObject.SetActive(false);
                arabic.gameObject.SetActive(true);
                english.gameObject.SetActive(true);
                videoplayer.Play();
                asource.PlayOneShot(aclip);


            }
            else if (mTrackableBehaviour.TrackableName == "landmarks")
            {
                canvas.gameObject.SetActive(true);
                pauseBtn.gameObject.SetActive(false);
                moonPhases.gameObject.SetActive(false);
                moonphases.gameObject.SetActive(false);
                arabic.gameObject.SetActive(true);
                english.gameObject.SetActive(true);
                videoplayer.Play();
                asource.PlayOneShot(aclip);


            }
        

        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            OnTrackingLost();
   
            if (mTrackableBehaviour.TrackableName == "solarsystem2")
            {
                   animator.speed = 0;
           
                asource.Stop();
                // asource.Stop();
                //anim.Stop();
            }
            else if (mTrackableBehaviour.TrackableName == "solarsystem1")
            {
                animator.speed = 0;
                asource.Stop();

            }
            else if (mTrackableBehaviour.TrackableName == "wolf")
            {
                animator.speed = 0;
                asource.Stop();

            }
            else if (mTrackableBehaviour.TrackableName == "earthorbit2")
            {
                
                animator.speed = 0;
                asource.Stop();

            }
            else if (mTrackableBehaviour.TrackableName == "earthOrbit")
            {
                
                animator.speed = 0;
                asource.Stop();

            }
            else if (mTrackableBehaviour.TrackableName == "wolf")
            {

                animator.speed = 0;
                asource.Stop();

            }
            else if (mTrackableBehaviour.TrackableName == "watercase2")
            {

                animator.speed = 0;
                asource.Stop();

            }
            else if (mTrackableBehaviour.TrackableName == "watervapor")
            {
                //Debug.Log(mTrackableBehaviour.TrackableName);
                videoplayer.Stop();

            }
            else if (mTrackableBehaviour.TrackableName == "jobs")
            {
                //Debug.Log(mTrackableBehaviour.TrackableName);
                videoplayer.Stop();
                videoplayer2.Stop();
                videoplayer3.Stop();
                videoplayer4.Stop();
                videoplayer5.Stop();
                videoplayer6.Stop();

                asource.Stop();
            }
            else if (mTrackableBehaviour.TrackableName == "landscape")
            {
               // Debug.Log(mTrackableBehaviour.TrackableName);
                videoplayer.Stop();

                asource.Stop();
                pauseBtn.gameObject.SetActive(true);

            }
            else if (mTrackableBehaviour.TrackableName == "landmarks")
            {
                //Debug.Log(mTrackableBehaviour.TrackableName);
                videoplayer.Stop();

                asource.Stop();
                pauseBtn.gameObject.SetActive(true);
            }


        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
            if (mTrackableBehaviour.TrackableName == "solarsystem2")
            {
                animator.speed = 0;
                asource.Stop();
                // asource.Stop();
                //anim.Stop();
            }
            else if (mTrackableBehaviour.TrackableName == "solarsystem1")
            {
                animator.speed = 0;
                asource.Stop();
            }
            else if (mTrackableBehaviour.TrackableName == "earthorbit2")
            {
                animator.speed = 0;
                asource.Stop();

            }
            else if (mTrackableBehaviour.TrackableName == "earthOrbit")
            {
                animator.speed = 0;
                asource.Stop();

            }
            else if (mTrackableBehaviour.TrackableName == "wolf")
            {
                animator.speed = 0;
                asource.Stop();

            }
            else if (mTrackableBehaviour.TrackableName == "watercase2")
            {
                animator.speed = 0;
                asource.Stop();

            }
            else if (mTrackableBehaviour.TrackableName == "watervapor")
            {
                //Debug.Log(mTrackableBehaviour.TrackableName);
                videoplayer.Stop();

            }
            else if (mTrackableBehaviour.TrackableName == "landscape")
            {
                //Debug.Log(mTrackableBehaviour.TrackableName);
                videoplayer.Stop();

            }
            else if (mTrackableBehaviour.TrackableName == "landmarks")
            {
                //Debug.Log(mTrackableBehaviour.TrackableName);
                videoplayer.Stop();

            }
            else if (mTrackableBehaviour.TrackableName == "jobs")
            {
                //Debug.Log(mTrackableBehaviour.TrackableName);
                videoplayer.Stop();
                videoplayer2.Stop();
                videoplayer3.Stop();
                videoplayer4.Stop();
                videoplayer5.Stop();
                videoplayer6.Stop();

                asource.Stop();
            }

        }
    }
 

    #endregion // PUBLIC_METHODS
    public static string trackablename()
    {
        return name1;
    }
   

    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound()
    {
        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

            // Enable rendering:
            foreach (var component in rendererComponents)
                component.enabled = true;

            // Enable colliders:
            foreach (var component in colliderComponents)
                component.enabled = true;

            // Enable canvas':
            foreach (var component in canvasComponents)
                component.enabled = true;
        }
        canvas.gameObject.SetActive(true);
    }


    protected virtual void OnTrackingLost()
    {
        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

            // Disable rendering:
            foreach (var component in rendererComponents)
                component.enabled = false;

            // Disable colliders:
            foreach (var component in colliderComponents)
                component.enabled = false;

            // Disable canvas':
            foreach (var component in canvasComponents)
                component.enabled = false;
        }
        canvas.gameObject.SetActive(false);
        pauseBtn.GetComponent<UnityEngine.UI.Image>().sprite = pausesprite;
    }

    #endregion // PROTECTED_METHODS
   
}
