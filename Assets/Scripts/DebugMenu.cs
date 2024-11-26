using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugMenu : MonoBehaviour
{
    public Slider healthSlider;
    public Slider speedSlider;
    public Slider enemySlider;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI enemyText;
    public GameObject debugMenu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            debugMenu.SetActive(!debugMenu.activeSelf);
        }

        healthText.text = $"{healthSlider.value}";
        speedText.text = $"{speedSlider.value}";
        enemyText.text = $"{enemySlider.value + 14}";
    }
}
