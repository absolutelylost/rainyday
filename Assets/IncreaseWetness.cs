using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseWetness : MonoBehaviour
{
    [SerializeField] private ParticleSystem system;
    private int particleCount;
    private int collisionCount = 0;
    private float wetness;
    private static readonly int WetnessPropertyID = Shader.PropertyToID("_Wetness");
    private Material material;

    private void OnParticleCollision(GameObject other)
	{
        collisionCount += 1;
        Debug.Log(collisionCount);

        // if the wetness index is still less than 1 have it grow at normal rate
        //otherwise half that rate
        // the higher the value the faster it fills in the puddles
        wetness += wetness <= 1.0 ? 0.01f : 0.005f;

        material.SetFloat("_Wetness", wetness);

        Debug.Log("accumulated wetness: " + wetness);


    }

    // Start is called before the first frame update
    void Start()
    {
        particleCount = 0;
        Renderer renderer = GetComponent<Renderer>();
        material = renderer.material;

        wetness = material.GetFloat("_Wetness");

        // Modify the property value
        //material.SetFloat("_Wetness", newWetness);

    }

    // Update is called once per frame
    void Update()
    {
		//if (system.isPlaying)
		//{
  //          particleCount += system.particleCount;
  //          Debug.Log("particle count " + particleCount);
  //          Debug.Log("particle count " + system.particleCount);
  //      }
    }
}
