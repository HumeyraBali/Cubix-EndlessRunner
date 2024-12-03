using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveControl : MonoBehaviour
{
    [Range(-0.5f, 0.5f)]
    public float curveStrengthX = 0;

    [Range(-0.5f, 0.5f)]
    public float curveStrengthY = 0;

    public Material[] materials;
    private GameTimeManager timer;

    private float incrementStep = 0.01f; 
    private int currentSituation = 1; 
    private int previousSituation = 1; 

    void Start()
    {
        timer = FindObjectOfType<GameTimeManager>();
        UpdateMaterialProperties();
    }

    void Update()
    {
        if (timer.timer > 0)
        {
            switch (currentSituation)
            {
                case 1: // Situation 1: CurveStrengthX = 0 -> 0.4f
                    curveStrengthX = Mathf.MoveTowards(curveStrengthX, 0.4f, incrementStep * Time.deltaTime);
                    if (Mathf.Approximately(curveStrengthX, 0.4f))
                        // NextSituation();
                        currentSituation = 3;
                    break;

                case 2: // Situation 2: CurveStrengthX = 0 -> -0.4f
                    curveStrengthX = Mathf.MoveTowards(curveStrengthX, -0.4f, incrementStep * Time.deltaTime);
                    if (Mathf.Approximately(curveStrengthX, -0.4f))
                        NextSituation();
                    break;

                case 3: // Situation 5: CurveStrengthY = 0 -> 0.1f
                    curveStrengthY = Mathf.MoveTowards(curveStrengthY, 0.1f, incrementStep * Time.deltaTime);
                    if (Mathf.Approximately(curveStrengthY, 0.1f))
                        NextSituation();
                    break;

                case 4: // Situation 6: CurveStrengthY = 0 -> -0.1f
                    curveStrengthY = Mathf.MoveTowards(curveStrengthY, -0.1f, incrementStep * Time.deltaTime);
                    if (Mathf.Approximately(curveStrengthY, -0.1f))
                        NextSituation();
                    break;
            }

            UpdateMaterialProperties();
            
            if ( timer.timer > 20 && incrementStep < 0.05 )
                incrementStep += 0.00001f;

            //Debug.Log($"Situation: {currentSituation}, CurveStrengthX: {curveStrengthX}, CurveStrengthY: {curveStrengthY}, IncrementStep: {incrementStep}");
        }
    }

    private void NextSituation()
    {
        previousSituation = currentSituation;

        do
        {
            currentSituation = Random.Range(1, 5); 
        } while (currentSituation == previousSituation);

        //Debug.Log($"Switching to Situation {currentSituation}");
    }

    private void UpdateMaterialProperties()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            if (materials[i].HasProperty("_CurveStrengthX") && materials[i].HasProperty("_CurveStrengthY"))
            {
                materials[i].SetFloat("_CurveStrengthX", curveStrengthX);
                materials[i].SetFloat("_CurveStrengthY", curveStrengthY);
            }
            else
            {
                Debug.LogError("Material does not have property '_CurveStrengthX' or '_CurveStrengthY'");
            }
        }
    }
}