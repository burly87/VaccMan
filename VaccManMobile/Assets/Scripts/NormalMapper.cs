using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMapper : MonoBehaviour
{

    public Texture2D[] source;
    public float strength;

    private int number = 0;
    void Start()
    {
        for (int i = 0; i < source.Length; i++)
        {
            NormalMap(source[i],strength );
            number++;
        }
    }
    private Texture2D NormalMap(Texture2D source,float strength) 
    {
            strength=Mathf.Clamp(strength,0.0F,1.0F);

            Texture2D normalTexture;
            float xLeft;
            float xRight;
            float yUp;
            float yDown;
            float yDelta;
            float xDelta;

            normalTexture = new Texture2D (source.width, source.height, TextureFormat.ARGB32, true);

            for (int y=0; y<normalTexture.height; y++) 
            {
                for (int x=0; x<normalTexture.width; x++) 
                {
                    xLeft = source.GetPixel(x-1,y).grayscale*strength;
                    xRight = source.GetPixel(x+1,y).grayscale*strength;
                    yUp = source.GetPixel(x,y-1).grayscale*strength;
                    yDown = source.GetPixel(x,y+1).grayscale*strength;
                    xDelta = ((xLeft-xRight)+1)*0.5f;
                    yDelta = ((yUp-yDown)+1)*0.5f;
                    normalTexture.SetPixel(x,y,new Color(xDelta,yDelta,1.0f,yDelta));
                }
            }
            normalTexture.Apply();

            //Code for exporting the image to assets folder
            System.IO.File.WriteAllBytes( "Assets/NormalMap" + number + ".png", normalTexture.EncodeToPNG());

            Debug.Log("Finished Normalmap");
            
            return normalTexture;
    }
}
