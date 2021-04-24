using UnityEngine;
using Vuforia;
using System.Collections;
public class animationscript : MonoBehaviour
{
    private TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;
    public AnimationClip animclip;
    public Animation anim;
    public Transform playbtn;
    // Use this for initialization
    void Start()
    {
        string name = NewBehaviourScriptForCards.trackablename();
  
        anim = GetComponent<Animation>();
        
    }
    // Update is called once per frame
    void Update()
    {
        
        OnTrackingFound();
        
    }
    private void OnTrackingFound()
    {

        //anim.Play("animated");
        
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
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
            if (mTrackableBehaviour.TrackableName == "korty")
            {
                
                anim.Play("animated");
            }
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            
            if (mTrackableBehaviour.TrackableName == "korty")
            {
            
                anim.Stop();
            }
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            
            if (mTrackableBehaviour.TrackableName == "korty")
            {
                
                anim.Stop();
            }
        }
    }
}