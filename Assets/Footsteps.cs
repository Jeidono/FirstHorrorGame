using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public GameObject footstep;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        footstep.SetActive(false);
    }

    // Update is called once per frame
void Update()
    {
        if(Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d"))
        {
            footsteps();
        }

        if(!Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("s") && !Input.GetKey("d"))
        {
            StopFootsteps();
        }
    }
void footsteps(){
    footstep.SetActive(true);
}
void StopFootsteps(){
    footstep.SetActive(false);
}

}