using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camino_Segmento 
{
    public Vector3 a; public Vector3 b;
    public Camino_Segmento() : this (Vector3.zero, Vector3.zero){ }
    public Camino_Segmento(Vector3 a, Vector3 b) { this.a = a; this.b = b; }
}

