using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Чистим отступы, юзинги, расстояния между методами и фигурными скобками. Это надо выдрочить до автоматизма
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;

    
    public void SetMaxHealth(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;

        _fill.color = _gradient.Evaluate(1f);
    }
     public void SetHealth(int health)
    {
        _slider.value = health;

        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
    
    public void SetHealthMoveTowards( int oldHealth, int newHealth)
    {
        //Явно кастить во флоат не требуется здесь, шарпы сами это сделают, тк ты явно приравниваешь штуки к переменным типа флоат
        //За неймингом тоже следить, непонятно что за a/b
        float a = (float) oldHealth;
        float b = (float) newHealth;

        a = Mathf.MoveTowards(a, b, Time.deltaTime * 0.05f);
        _slider.value = a;

        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }


}
