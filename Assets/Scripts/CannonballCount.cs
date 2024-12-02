using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CannonballCount : MonoBehaviour
{

    public TextMeshProUGUI cannonBallText;
    private LaunchCannons launchCannons;
    // Start is called before the first frame update
    void Start()
    {
        cannonBallText = GetComponent<TextMeshProUGUI>();
    }

    
}
