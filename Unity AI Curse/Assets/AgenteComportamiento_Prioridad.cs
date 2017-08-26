using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgenteComportamiento_Prioridad : MonoBehaviour
{
    public int prioridad = 1;
    public float peso = 1.0f;



    public GameObject objetivo;
    protected Agente agente;

    
    public virtual void Awake()
    {
        agente = gameObject.GetComponent<Agente>();
    }


    public virtual void Update()
    {
        agente.SetDireccion(GetDireccion(), prioridad);
    }


    public virtual Direccion GetDireccion()
    {
        return new Direccion();
    }

    public float MapToRange(float rotacion)
    {
        rotacion %= 360.0f;
        if (Mathf.Abs(rotacion) > 180.0f)
        {
            if (rotacion < 0.0f) rotacion += 360.0f;
            else rotacion -= 360.0f;
        }
        return rotacion;
    }


    //Orientacion a Vector
    public Vector3 GetOriAsVec(float orientation)
    {
        Vector3 vector = Vector3.zero; vector.x = Mathf.Sin(orientation * Mathf.Deg2Rad) * 1.0f;
        vector.z = Mathf.Cos(orientation * Mathf.Deg2Rad) * 1.0f;
        return vector.normalized;
    }
}