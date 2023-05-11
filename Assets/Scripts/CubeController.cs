using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeController : MonoBehaviour
{
    private int colorIndex = 0;
    float rotacion = 360.0f;
    private Renderer cubeRenderer;
    // Start is called before the first frame update
    void Start()
    {
        cubeRenderer = this.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", new Color(1.0f,0.0f,0.0f,1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotacion, 0 ) * Time.deltaTime);
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                changeRotation();
            }
        }
    }
    public void changeRotation()
    {
        rotacion = -rotacion;
    }
    public void changeColor()
    {
        colorIndex++;
        if (colorIndex > 5)
            colorIndex =0;
        
        switch (colorIndex)
        {
            case 0://ROJO
                cubeRenderer.material.SetColor("_Color", new Color(1.0f, 0.0f,0.0f,1.0f));
            break;
            case 1://VERDE
                cubeRenderer.material.SetColor("_Color", new Color(0.0f, 1.0f,0.0f,1.0f));
            break;
            case 2://AZUL
                cubeRenderer.material.SetColor("_Color", new Color(0.0f, 0.0f,1.0f,1.0f));
            break;
            case 3://AMARILLO
                cubeRenderer.material.SetColor("_Color", new Color(1.0f, 1.0f,0.0f,1.0f));
            break;
            case 4://BLANCO
                cubeRenderer.material.SetColor("_Color", new Color(1.0f, 1.0f,1.0f,1.0f));
            break;
            case 5://NEGRO
                cubeRenderer.material.SetColor("_Color", new Color(0.0f, 0.0f,0.0f,1.0f));
            break;
            default:
            break;
        }

        Debug.Log("Color Cambiado: "+colorIndex);
    }
}
