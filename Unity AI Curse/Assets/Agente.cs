using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agente : MonoBehaviour
{
    public float velMax;
    public float acelMax;
    public float orientacion;
    public float rotacion;
    public Vector3 velocity;
    protected Direccion direccion;
    void Start()
    {
        velocity = Vector3.zero;
        direccion = new Direccion();
    }



    public void SetDireccion(Direccion dir)
    {
        this.direccion = dir;
    }



    //Aplica Rotacion y Desplazamiento en relacion a la direccion provista en SetDireccion
    public virtual void Update()
    {
        AplicarDesplazamiento();
        AplicacrRotacion();
    }

    public void AplicarDesplazamiento()
    {
        Vector3 desplazamiento = velocity * Time.deltaTime;
        transform.Translate(desplazamiento, Space.World);
    }

    public void AplicacrRotacion()
    {
        orientacion += rotacion * Time.deltaTime;
        // we need to limit the orientation values   
        // to be in the range (0 – 360)    
        if (orientacion < 0.0f) orientacion += 360.0f;
        else if (orientacion > 360.0f)
            orientacion -= 360.0f;
        transform.rotation = new Quaternion();
        transform.Rotate(Vector3.up, orientacion);
    }



    //Realiza los calculos de Rotacion y Desplazamiento para el siguiente cuadro
    public virtual void LateUpdate()
    {
        CalcularRotacionDesplazamiento();
    }

    void CalcularRotacionDesplazamiento()
    {
        velocity += direccion.linear * Time.deltaTime;
        rotacion += direccion.angular * Time.deltaTime;
        if (velocity.magnitude > velMax)
        {
            velocity.Normalize(); velocity = velocity * velMax;
        }
        if (direccion.angular == 0.0f)
        {
            rotacion = 0.0f;
        }
        if (direccion.linear.sqrMagnitude == 0.0f)
        {
            velocity = Vector3.zero;
        }
        direccion = new Direccion();
    }
}