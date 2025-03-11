using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendShape : MonoBehaviour
{
    int blendShapeCount;
    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;
    int playIndex = 0;
    void Awake()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
    }

    void Start()
    {
        Application.targetFrameRate = 60;
        blendShapeCount = skinnedMesh.blendShapeCount;
    }

    void Update()
    {
        if (playIndex > 0) skinnedMeshRenderer.SetBlendShapeWeight(playIndex - 1, 0f);
        if(playIndex ==0) skinnedMeshRenderer.SetBlendShapeWeight(blendShapeCount-1, 0f);

        skinnedMeshRenderer.SetBlendShapeWeight(playIndex, 100f);
        playIndex++;
        if (playIndex > blendShapeCount - 1) playIndex = 0;
    }
}
