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
        colors = new List<Color> {
            new Color(0, 255, 0),
            new Color(255, 150, 0),
            new Color(150, 255, 0),
            new Color(255, 0, 0)
        };
    }

    private void Update()
    {
        if (sliders.Count >= 5 && texts.Count >= 5)
        {
            sliders[0].value = playerStateInfo.Hp / 100f;
            sliders[1].value = playerStateInfo.Fatigue / 100f;
            sliders[2].value = playerStateInfo.Hunger / 100f;
            sliders[3].value = playerStateInfo.Contamination / 100f;
            sliders[4].value = playerStateInfo.Panic / 100f;

            texts[0].text = playerStateInfo.Hp.ToString();
            texts[1].text = playerStateInfo.Fatigue.ToString();
            texts[2].text = playerStateInfo.Hunger.ToString();
            texts[3].text = playerStateInfo.Contamination.ToString();
            texts[4].text = playerStateInfo.Panic.ToString();

            UpdateSliderColor(sliders[0], true); 
            for (int i = 1; i < sliders.Count; i++)
            {
                UpdateSliderColor(sliders[i], false); 
            }
        }
    }

    private void UpdateSliderColor(Slider slider, bool reverse)
    {
        if (!reverse)
        {
            if (slider.value > 0.6f && slider.value < 1f)
            {
                slider.fillRect.GetComponent<Image>().color = colors[0];
            }
            else if (slider.value > 0.3f && slider.value <= 0.6f)
            {
                slider.fillRect.GetComponent<Image>().color = colors[2];
            }
            else if (slider.value > 0 && slider.value <= 0.3f)
            {
                slider.fillRect.GetComponent<Image>().color = colors[1]; 
            }
            else if (slider.value == 1f)
            {
                slider.fillRect.GetComponent<Image>().color = colors[3]; 
            }
        }
        else
        {
            if (slider.value > 0.6f && slider.value < 1f)
            {
                slider.fillRect.GetComponent<Image>().color = colors[3];
            }
            else if (slider.value > 0.3f && slider.value <= 0.6f)
            {
                slider.fillRect.GetComponent<Image>().color = colors[1]; 
            }
            else if (slider.value > 0 && slider.value <= 0.3f)
            {
                slider.fillRect.GetComponent<Image>().color = colors[2];
            }
            else if (slider.value == 1f)
            {
                slider.fillRect.GetComponent<Image>().color = colors[0]; 
            }
        }
    }
}