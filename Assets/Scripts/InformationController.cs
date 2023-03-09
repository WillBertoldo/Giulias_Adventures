using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationController : MonoBehaviour
{
    public float timeInScreen, maxTimeInScreen,newColor;
    public Text informationText;

    void Update(){
        timeInScreen += Time.deltaTime;
        if(timeInScreen >= maxTimeInScreen){
            newColor += Time.deltaTime;
            informationText.color = new Color(informationText.color.r, informationText.color.g, informationText.color.b,newColor);
        }
        if(timeInScreen >= maxTimeInScreen + 1){
            Destroy (informationText);
        }
    }
}
