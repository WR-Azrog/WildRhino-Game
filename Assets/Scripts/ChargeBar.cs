using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{
	public Slider slider;
	public Mouvement player;
	
	void Start(){
		slider.value = 0;
    }
	void Update(){
		slider.value = player.moveSpeed;
    }
}
