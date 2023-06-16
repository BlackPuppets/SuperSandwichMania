using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveText : MonoBehaviour
{

    private TMP_Text _textComponent;


    private void Start()
    {
        _textComponent = GetComponent<TMP_Text>();
    }

    void Update()
    {
        _textComponent.ForceMeshUpdate();
        var textInfo = _textComponent.textInfo;

        for (int i = 0; i < textInfo.characterCount; ++i)
        {

            var charInfo = textInfo.characterInfo[i];

            if (!charInfo.isVisible)
            {
                continue;
            }

            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; ++j)
            {
                var origin = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = origin + new Vector3(0, Mathf.Sin(Time.time * 2f + origin.x * 0.01f) * 4f, 0);
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; ++i)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            _textComponent.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
