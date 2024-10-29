using UnityEngine;
public class ColourGrade : MonoBehaviour
{
    //public Shader awesomeShader = null;
    public Material[] whichLut = new Material[4];
    public int x = 0;
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, whichLut[x]);
    }

    public void SwitchLut()
    {
        if (x == 3)
        {
            x = 0;
        }
        else
        {
            x++;
        }
    }
}