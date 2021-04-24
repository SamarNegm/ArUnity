using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{

    public Material[] BodyColorMat;
    Material CurrMat;
    Renderer renderer;

    // Use this for initialization
    void Start()
    {

        renderer = this.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //render grey color
    public void GreyColor()
    {
        renderer.material = BodyColorMat[0];
        CurrMat = renderer.material;
    }

    //render red color
    public void RedColor()
    {
        renderer.material = BodyColorMat[1];
        CurrMat = renderer.material;
    }

    //render BlackColor
    public void BlackColor()
    {
        renderer.material = BodyColorMat[2];
        CurrMat = renderer.material;
    }


    //render Navy Blue color
    public void NavyBlueColor()
    {
        renderer.material = BodyColorMat[3];
        CurrMat = renderer.material;
    }
}