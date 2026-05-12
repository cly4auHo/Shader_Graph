using System.Collections;
using UnityEngine;

public class AppearanceController : MonoBehaviour
{
    private static readonly int COLOR = Shader.PropertyToID("_EdgeColour");
    private static readonly int THRESHOLD = Shader.PropertyToID("_TreshHold");
    
    [SerializeField] private Material appearanceMaterial;
    [SerializeField] private float stepTime;
    [SerializeField] private Vector4 orange;
    [SerializeField] private Vector4 blue;

    private Coroutine coroutine;
    
    private void Start()
    {
        coroutine = StartCoroutine(SetOrange());
    }
    
    private IEnumerator SetOrange()
    {
        var timer = 0f;
        appearanceMaterial.SetVector(COLOR, orange);
        
        while (timer < stepTime)
        {
            yield return null;
            
            appearanceMaterial.SetFloat(THRESHOLD, 1 - timer / stepTime);
            timer += Time.deltaTime;
        }

        coroutine = StartCoroutine(SetBlue());
    }

    private IEnumerator SetBlue()
    {
        var timer = 0f;
        appearanceMaterial.SetVector(COLOR, blue);

        while (timer < stepTime)
        {
            yield return null;
            
            appearanceMaterial.SetFloat(THRESHOLD, timer / stepTime);
            timer += Time.deltaTime;
        }

        coroutine = StartCoroutine(SetOrange());
    }
}
