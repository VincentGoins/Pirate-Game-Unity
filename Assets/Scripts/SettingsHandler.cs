using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{

    //different screen heights and widths
    List<int> widths = new List<int>() { 568, 960, 1280, 1920 };
    List<int> heights = new List<int>() { 320, 540, 800, 1000 };

    [SerializeField] Slider volumeSlider;
    //get volume value that was set on the start of the game
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            SetVolume(PlayerPrefs.GetFloat("Volume"));
            //so volume is displayed
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
        //set to half volume default
        else {
            SetVolume(0.5f);
        }
    }
    //set volume and put into player prefs so it can be saved between games
    public void SetVolume(float volume) {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
    //setting screen size using the preset values
    public void SetScreenSize(int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
    }
    
    public void SetFullscreen(bool _fullscreen)
    {
        Screen.fullScreen = _fullscreen;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
