using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    //NEEDS AN INDICTAOR
    public PlayerController player;
    public Renderer render;
    public Material material, material2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>(); //public variable player is a short name to access playercontroller script.
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.hasBlue)
        {
            render.material = material2;
        }
        else
        {
            render.material = material;
        }

        if (player.hasYellow)
        {
            render.material = material2;
        }
        else
        {
            render.material = material;
        }
    }
}
