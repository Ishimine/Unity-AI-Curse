using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agente_Encarar : Agente_Alinear {

    protected GameObject objetivoAux;


    public override void Awake()
    {
        base.Awake();
        objetivoAux = objetivo;
        objetivo = new GameObject();
        objetivo.AddComponent<Agente>();
    }


    void OnDestroy()
    {
        Destroy(objetivo);
    }


    public override Direccion GetDireccion()
    {
        Vector3 direction = objetivo.transform.position - transform.position;
        if (direction.magnitude > 0.0f)
        {
            float targetOrientation = Mathf.Atan2(direction.x, direction.z);
            targetOrientation *= Mathf.Rad2Deg;
            objetivo.GetComponent<Agente>().orientacion = targetOrientation;
        }
        return base.GetDireccion();
    }

}
