using TMPro;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lookPercentageLabel;
    [SerializeField] public float LookPercentage;

    void Update()
    {
        //lookPercentageLabel.text = LookPercentage.ToString("F3");    
    }
}
