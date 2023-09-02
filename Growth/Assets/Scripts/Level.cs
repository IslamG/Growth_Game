using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Character Character;
    public GameObject[] Exit;

    public void ExitReached()
    {
        Debug.Log("You win!");
    }

}
