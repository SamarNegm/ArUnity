using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class vedioPlaneCnt : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer vp;
    public Texture DefultTexture;
    public RenderTexture texture;
    public void OnEnable()
    {
        if (vp != null)
        {
            vp.Play();
        }
    }
    public void OnDisable()
    {
        if (vp != null)
        {
            vp.Stop();
            Graphics.Blit(DefultTexture, texture);
        }
    }
}