using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloorSystem : MonoBehaviour
{
    public float floorlevel;
    public TextMeshProUGUI floor_text;
    public void AdvanceFloor()
    {
        floorlevel += 1;
    }
    private void OnGUI()
    {
        floor_text.text = floorlevel.ToString();
    }
}
