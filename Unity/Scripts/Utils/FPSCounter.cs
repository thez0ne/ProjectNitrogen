using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Author: Anik Patel
// Description: Basic class for use as a UI FPS counter
// Version: 1.0
// Changes: [N/A]
namespace Zone.Core.Utils
{
    public class FPSCounter : MonoBehaviour
    {
        // Boolean for if using TMPro or the base Unity UI
        [SerializeField] private bool usingTMP = false;

        // Refences to the Text Components
        [SerializeField] private Text fpsText = null;
        [SerializeField] private TMP_Text fpsTextTMP;

        private int fps;

        void Update()
        {
            fps = (int) (1f / Time.unscaledDeltaTime);
            if (usingTMP)
            {
                fpsTextTMP.text = $"{fps} fps";
            }
            else
            {
                fpsText.text = $"{fps} fps";
            }
            // Debug.Log($"Running at {fps}");
        }
    }
}
