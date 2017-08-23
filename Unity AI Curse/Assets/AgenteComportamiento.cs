using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgenteComportamiento : MonoBehaviour
{

    public float velMax;
    public float acelMax;
    public float rotMax;
    public float acelAngularMax;
    public GameObject objetivo;
    protected Agente agente;
    public virtual void Awake()
    {
        agente = gameObject.GetComponent<Agente>();
    }
    public virtual void Update()
    {
        agente.SetDireccion(GetDireccion());
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

}