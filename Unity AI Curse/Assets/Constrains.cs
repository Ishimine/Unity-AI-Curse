using System.Collections;
using UnityEngine;

public class Constraint : MonoBehaviour
{

    public virtual bool WillViolate(Camino camino)
    {
        return true;
    }

    public virtual Goal Suggest(Camino camino)
    {
        return new Goal();
    }
}
