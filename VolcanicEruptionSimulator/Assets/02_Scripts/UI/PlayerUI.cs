using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public PlayerStateInfo playerStateInfo;
    public List<Slider> sliders;
    public List<Text> texts;
    private List<Color> colors;

    private void Start()
    {
        if(colors.Count >= 4)
        {
            colors[0] = new Color(0, 255, 0);
            colors[1] = new Color(255, 150, 0);
            colors[2] = new Color(150, 255, 0);
            colors[3] = new Color(255, 0, 0);
        }
    }
    private void Update()
    {
        if (sliders.Count >= 5 && texts.Count >= 5)
        {
            sliders[0].value = playerStateInfo.Hp/100;
            sliders[1].value = playerStateInfo.Fatigue/100;
            sliders[2].value = playerStateInfo.Hunger/100;
            sliders[3].value = playerStateInfo.Contamination/100;
            sliders[4].value = playerStateInfo.Panic/100;

            texts[0].text = playerStateInfo.Hp.ToString();
            texts[1].text = playerStateInfo.Fatigue.ToString();
            texts[2].text = playerStateInfo.Hunger.ToString();
            texts[3].text = playerStateInfo.Contamination.ToString();
            texts[4].text = playerStateInfo.Panic.ToString();
        }
        foreach(var slider in sliders)
        {
            if(slider.value > 0 && slider.value <0.3f)
            {
                colors[0] = new Color(255, 0, 0);
                colors[1] = new Color(0, 255, 0);
                colors[2] = new Color(0, 255, 0);
                colors[3] = new Color(0, 255, 0);
            }
            if (slider.value > 0.3f && slider.value < 0.7f)
            {
                colors[0] = new Color(150, 255, 0);
                colors[1] = new Color(255, 150, 0);
                colors[2] = new Color(255, 150, 0);
                colors[3] = new Color(255, 150, 0);
            }
            if(slider.value >=0.7f && slider.value < 1f)
            {
                colors[0] = new Color(255, 150, 0);
                colors[1] = new Color(150, 255, 0);
                colors[2] = new Color(150, 255, 0);
                colors[3] = new Color(150, 255, 0);
            }
            if(slider.value == 1f)
            {
                colors[0] = new Color(0, 255, 0);
                colors[1] = new Color(255, 0, 0);
                colors[2] = new Color(255, 0, 0);
                colors[3] = new Color(255, 0, 0);
            }
        }
    }
}
