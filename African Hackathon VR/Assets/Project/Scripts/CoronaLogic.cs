using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronaLogic : MonoBehaviour
{

    public float changeTimer = 5.0f;
    float timer = 0;

    bool startCoronaSystem = false;

    MeshRenderer[] gameMeshRenderers;
    SpriteRenderer[] coronaRenderers;

    private void Awake()
    {
        gameMeshRenderers = FindObjectsOfType<MeshRenderer>();
    }
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoronaXRay();
        }

        if (startCoronaSystem)
        {
            if (timer < changeTimer)
            {
                //Debug.Log(timer / changeTimer);

                for (int i = 0; i < gameMeshRenderers.Length; i++)
                {
                    Material[] materials = gameMeshRenderers[i].materials;

                    for (int j = 0; j < materials.Length; j++)
                    {
                        materials[j].color = Color.Lerp(materials[j].color, Color.blue, (timer) / changeTimer);
                        //materials[j].color =  Color.blue * (timer / changeTimer) + ;
                    }
                }

                for (int i = 0; i < coronaRenderers.Length; i++)
                {
                    Material[] materials = coronaRenderers[i].materials;

                    for (int j = 0; j < materials.Length; j++)
                    {
                        materials[j].color = Color.Lerp(materials[j].color, Color.white, (timer) / changeTimer);
                    }
                }

                timer += Time.deltaTime;
            }
        }

    }

    public void StartCoronaXRay()
    {
        coronaRenderers = FindObjectsOfType<SpriteRenderer>();

        startCoronaSystem = true;

        //StartCoroutine(CoronaXRay());
    }

    /*IEnumerator CoronaXRay()
    {
        float timer = 0;

        while (timer < changeTimer)
        {
            for (int i = 0; i < gameMeshRenderers.Length; i++)
            {
                Material[] materials = gameMeshRenderers[i].materials;

                for (int j = 0; j < materials.Length; j++)
                {
                    materials[j].color = Color.Lerp(gameMeshRenderers[i].material.color, Color.blue, timer / changeTimer);
                }
            }

            for (int i = 0; i < coronaRenderers.Length; i++)
            {
                Material[] materials = coronaRenderers[i].materials;

                for (int j = 0; j < materials.Length; j++)
                {
                    materials[j].color = Color.Lerp(gameMeshRenderers[i].material.color, Color.white, timer / changeTimer);
                }
            }

            timer += Time.deltaTime;
            yield return null;
        }
    }*/
}
