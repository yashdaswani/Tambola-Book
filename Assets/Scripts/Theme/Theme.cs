using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Theme",menuName ="Theme")]
public class Theme : ScriptableObject
{
    public Color backGroundColor;
    public Color headerTextColor;
    public Color TicketDetailsColor;
    public Color GridBoundaryColor;
    public Color GridColor;
    public Color GridTextColor;
    public Color MarkedColor;
    public Color MarkedTextColor;
}
