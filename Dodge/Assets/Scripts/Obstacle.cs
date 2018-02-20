using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public SpriteRenderer[] spriteRenderer;
    
    public Color[] colors;
    public Color currentColor;

    void Start ()
    {
        //RandomColor();

        
	}
	
	void Update ()
    {
        if (this.transform.position.y < (Camera.main.gameObject.transform.position.y - 10))
            Destroy(this.gameObject);
	}

    public void RandomColor()
    {
        currentColor = colors[Random.Range(0, colors.Length)];

        spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
 
        foreach (SpriteRenderer spriteRend in spriteRenderer)
        {
            spriteRend.GetComponent<SpriteRenderer>().color = currentColor;
        }
    }
}
