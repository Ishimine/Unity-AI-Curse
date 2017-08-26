using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camino : MonoBehaviour
{

    public List<GameObject> nodos;
    List<Camino_Segmento> segmentos;


    void Start()
    {
        segmentos = GetSegmentos();
    }


    public List<Camino_Segmento> GetSegmentos()
    {
        List<Camino_Segmento> segments = new List<Camino_Segmento>();
        int i;
        for (i = 0; i < nodos.Count - 1; i++)
        {
            Vector3 src = nodos[i].transform.position;
            Vector3 dst = nodos[i + 1].transform.position;
            Camino_Segmento segment = new Camino_Segmento(src, dst);
            segments.Add(segment);
        }
        return segments;
    }


    //Busca el segmento mas cercano
    public float GetParam(Vector3 position, float lastParam)
    {
        float param = 0f;
        Camino_Segmento currentSegment = null;
        float tempParam = 0f; foreach (Camino_Segmento ps in segmentos)
        {
            tempParam += Vector3.Distance(ps.a, ps.b);
            if (lastParam <= tempParam)
            { currentSegment = ps;
                break;
            }
        }
        if (currentSegment == null)
            return 0f;

        Vector3 currPos = position - currentSegment.a;
        Vector3 segmentDirection = currentSegment.b - currentSegment.a;
        segmentDirection.Normalize();

        Vector3 pointInSegment = Vector3.Project(currPos, segmentDirection);

        param = tempParam - Vector3.Distance(currentSegment.a, currentSegment.b);
        param += pointInSegment.magnitude;
        return param;
    }


    public Vector3 GetPosition(float param)
    {
        Vector3 position = Vector3.zero;
       Camino_Segmento currentSegment = null; float tempParam = 0f;
        foreach (Camino_Segmento ps in segmentos)
        {
            tempParam += Vector3.Distance(ps.a, ps.b);
            if (param <= tempParam)
            {
                currentSegment = ps; break;
            }
        }
        if (currentSegment == null) return Vector3.zero;

        Vector3 segmentDirection = currentSegment.b - currentSegment.a;
        segmentDirection.Normalize();
        tempParam -= Vector3.Distance(currentSegment.a, currentSegment.b);
        tempParam = param - tempParam;
        position = currentSegment.a + segmentDirection * tempParam;
        return position;
    }


    void OnDrawGizmos()
    {
        Vector3 direction;
        Color tmp = Gizmos.color; Gizmos.color = Color.magenta;//example color    
        int i; for (i = 0; i < nodos.Count - 1; i++)
        {
            Vector3 src = nodos[i].transform.position;
            Vector3 dst = nodos[i + 1].transform.position;
            direction = dst - src; Gizmos.DrawRay(src, direction);
        }
        Gizmos.color = tmp;
    }
}
