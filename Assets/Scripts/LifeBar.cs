using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    // the worlds most simple life bar slider script O_O

    public Slider slider;
    public void SetMaxLife(int life)
    {
        slider.maxValue = life;
        slider.value = life;
    }

    public void SetLife(int life)
    {
        slider.value = life;
    }

}
