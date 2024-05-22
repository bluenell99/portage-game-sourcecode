using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class StatBar : MonoBehaviour
{
    [SerializeField] private Image _fillImage;
    [SerializeField] private TextMeshProUGUI _valueDisplay;


    public void UpdateStat(Stat stat)
    {
        _fillImage.fillAmount = (float) stat.Current / stat.Max;
        _valueDisplay.text = stat.Current.ToString();
    }
    

}
