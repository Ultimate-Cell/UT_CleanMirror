using UnityEngine;
using TMPro;
using System.Collections;

public class NumberDynamicTMP : MonoBehaviour
{
    public TMP_Text tmp;
    public ModeStyle mode;
    public TextStyle textStyle;
    public float IncrementSpeed = 10f;
    public float IncrementRate = 10f;
    public int targetNumber = 99999;

    private int currentNumber;
    private int previousNumber;

    public enum TextStyle
    {
        Sin,
        Shake,
        Scroll,
    }

    public enum ModeStyle
    {
        Single,
        All,
    }

    private void Start()
    {
        currentNumber = int.TryParse(tmp.text, out var parsedNumber) ? parsedNumber : 0;
        previousNumber = currentNumber;

        StartCoroutine(IncrementNumber());
    }

    private IEnumerator IncrementNumber()
    {
        while (currentNumber < targetNumber)
        {
            currentNumber++;
            tmp.text = currentNumber.ToString();

            // Check for digit changes
            if (mode == ModeStyle.Single)
            {
                int digitIndex = DetectDigitChange();
                if (digitIndex != -1)
                {
                    RefreshMeshSingle(digitIndex);
                }
            }
            else if (mode == ModeStyle.All)
            {
                RefreshMeshAll();
            }

            previousNumber = currentNumber;
            yield return new WaitForSeconds(1f / IncrementSpeed);
        }

        ResetMesh();
    }

    private int DetectDigitChange()
    {
        char[] currentDigits = currentNumber.ToString().ToCharArray();
        char[] previousDigits = previousNumber.ToString().ToCharArray();

        for (int i = 0; i < currentDigits.Length; i++)
        {
            if (i >= previousDigits.Length || currentDigits[i] != previousDigits[i])
            {
                return i;
            }
        }

        return -1;
    }

    private void RefreshMeshSingle(int digitIndex)
    {
        tmp.ForceMeshUpdate();
        TMP_TextInfo textInfo = tmp.textInfo;
        for (int i = 0; i < textInfo.characterCount; i++)
        {
            if (i == digitIndex)
            {
                TMP_CharacterInfo charInfo = textInfo.characterInfo[i];
                if (!charInfo.isVisible) continue;

                int materialIndex = charInfo.materialReferenceIndex;
                int vertexIndex = charInfo.vertexIndex;
                Vector3[] vertices = textInfo.meshInfo[materialIndex].vertices;

                ModifyVertices(vertices, vertexIndex, textStyle);
            }
        }

        tmp.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);
    }

    private void RefreshMeshAll()
    {
        tmp.ForceMeshUpdate();
        TMP_TextInfo textInfo = tmp.textInfo;
        for (int i = 0; i < textInfo.characterCount; i++)
        {
            TMP_CharacterInfo charInfo = textInfo.characterInfo[i];
            if (!charInfo.isVisible) continue;

            int materialIndex = charInfo.materialReferenceIndex;
            int vertexIndex = charInfo.vertexIndex;
            Vector3[] vertices = textInfo.meshInfo[materialIndex].vertices;

            ModifyVertices(vertices, vertexIndex, textStyle);
        }

        tmp.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);
    }

    private void ModifyVertices(Vector3[] vertices, int vertexIndex, TextStyle style)
    {
        for (int j = 0; j < 4; j++)
        {
            Vector3 orig = vertices[vertexIndex + j];
            vertices[vertexIndex + j] = GetModifiedVertex(orig, style);
        }
    }

    private Vector3 GetModifiedVertex(Vector3 vertex, TextStyle style)
    {
        switch (style)
        {
            case TextStyle.Sin:
                return vertex + new Vector3(0, (Mathf.Sin(Time.time * 2f + vertex.x * 0.45f) * 0.3f) * IncrementRate, 0);

            case TextStyle.Shake:
                float vertexOffset = UnityEngine.Random.Range(-0.5f, 0.5f);
                return vertex + new Vector3(0, (vertexOffset * Mathf.Sin(Time.time * 10f)) * IncrementRate, 0);

            case TextStyle.Scroll:
                float scrollSpeed = 15f;
                return vertex + new Vector3(0, (Mathf.Repeat(Time.time * scrollSpeed, 0.7f) - 0.35f) * IncrementRate, 0);

            default:
                return vertex;
        }
    }

    private void ResetMesh()
    {
        tmp.ForceMeshUpdate();
        tmp.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);
    }
}
