using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject FlashlightLight;
    private bool flashlightActive = false;
    
    private CamMovement camMovement; // Reference to the CamMovement script

    void Start()
    {
        FlashlightLight.gameObject.SetActive(false);
        camMovement = FindObjectOfType<CamMovement>(); // Find CamMovement in the scene
    }

    void Update()
    {
        if (camMovement != null)
        {
            // Make flashlight follow the camera rotation
            transform.rotation = camMovement.transform.rotation;
        }

        // Toggle flashlight on/off
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlightActive = !flashlightActive;
            FlashlightLight.gameObject.SetActive(flashlightActive);
        }
    }
}
