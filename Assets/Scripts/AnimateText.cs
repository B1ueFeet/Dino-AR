using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimateText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textComponent;
    private bool located;

    // Update is called once per frame
    void Update()
    {
        if (!located)
        {
            Animate();
        }
        else
        {
            changeText();  
        }
    }

    private void Animate()
    {
        textComponent.ForceMeshUpdate();
        var textInfo = textComponent.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            var charInfo = textInfo.characterInfo[i];

            if (!charInfo.isVisible)
            {
                continue;
            }

            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; j++)
            {
                var origen = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = origen + new Vector3(0, Mathf.Sin(Time.time * 2f + origen.x * 0.01f) * 10f, 0);
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            textComponent.UpdateGeometry(meshInfo.mesh, i);
        }

        Debug.Log("Success");
    }

    public void changeText()
    {
        textComponent.text = "Located";
        located = true;
    }
}
