using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Hiza : MonoBehaviour
{
    public PlayerController playerController; 
    Slider _slider;

    // Start is called before the first frame update
    void Start()
    {
        _slider = GameObject.Find("Slider").GetComponent<Slider>();        
    }
  
    // Update is called once per frame
    void Update()
    {
        int stm;
        stm = playerController.stamina;
        _slider.value = stm;
    }
}
