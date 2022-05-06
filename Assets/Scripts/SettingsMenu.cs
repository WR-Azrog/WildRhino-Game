using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
	public AudioMixer audioMixer;
	public Dropdown resolutionDropdown;
	
	Resolution[] resolutions;
	
	public void Start(){
		// Pick up les resolutions local et empêche les doublons avec DISTINCT
		resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
		
		// Clear le menu déroulant
		resolutionDropdown.ClearOptions();
		
		// Crée et remplis la liste sous forme string avec les resolutions
		List<string> options = new List<string>();
		
		int currentResolutionIndex = 0;
		
		for (int i = 0; i< resolutions.Length; i++){
			string option = resolutions[i].width + "x" + resolutions[i].height;
			options.Add(option);
			
			// Trouve la resolution actuel
			if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height){
				currentResolutionIndex = i;
			}
		}
		
		// Ajoute la la liste au menu déroulant
		resolutionDropdown.AddOptions(options);
		// set la resolution
		resolutionDropdown.value = currentResolutionIndex;
		// Met à jour la value (affiche la bonne valeur actuel)
		resolutionDropdown.RefreshShownValue();
	}
	
	public void SetVolume(float volume){
		audioMixer.SetFloat("volume", volume);
	}
	
	public void FullScreen(bool isFullScreen){
		Screen.fullScreen = isFullScreen;
	}
	
	public void SetResolution(int resolutionIndex){
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}
	
		public void CloseWindow(){
		//SetActive(false);
	}
}
