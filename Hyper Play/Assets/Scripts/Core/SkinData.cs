using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "Skin", order = 0)]
public class SkinData : ScriptableObject
{
    public int skinIndex;
    public Material[] skin;

    public Material GetSkin => skin[skinIndex];
}
