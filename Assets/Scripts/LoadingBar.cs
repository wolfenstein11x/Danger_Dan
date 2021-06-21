using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBar : MonoBehaviour
{
    private Slider slider;
    private int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 0.03f;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value += Random.Range(0.00f, 0.002f);
        NextScene();
    }

    private void NextScene()
    {
        if (slider.value >= 1f)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
