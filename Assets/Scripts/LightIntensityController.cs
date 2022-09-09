using System.Collections;
using UnityEngine;


[RequireComponent(typeof(UnityEngine.Rendering.Universal.Light2D))]
public class LightIntensityController : MonoBehaviour
{
    [SerializeField] float minIntensity = 0.0f;
    [SerializeField] float maxIntensity = 0.0f;
    [SerializeField] float minTime = 0.0f;
    [SerializeField] float maxTime = 0.0f;

    private IEnumerator Start()
    {
        UnityEngine.Rendering.Universal.Light2D light = GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        while (true)
        {
            float startIntensity = light.intensity;
            float targetIntensity = Random.Range(minIntensity, maxIntensity);
            float targetTime = Random.Range(minTime, maxTime);

            for (float t = 0; t < targetTime; t += Time.deltaTime)
            {
                light.intensity = Mathf.Lerp(startIntensity, targetIntensity, t / targetTime);
                yield return null;
            }
        }
    }
}
