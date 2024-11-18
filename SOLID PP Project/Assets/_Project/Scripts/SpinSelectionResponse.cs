using UnityEngine;

public class SpinSelectionResponse : MonoBehaviour, ISelectionResponse
{
    float x;
    float y;
    float z;

    float smoothFactor = 10f;

    bool settingValues = true;
    bool shouldRise;

    //Transform spinning;

    Transform spin;

    public void OnSelect(Transform selection)
    {
        spin = selection.GetComponent<Transform>();

        //spinning = spin;

        if (settingValues) 
        {
            x = spin.position.x;
            y = spin.position.y;
            z = spin.position.z;
            settingValues = false;
        }
        

        if (spin != null)
        {
            spin.rotation = new Quaternion(Random.value, Random.value, Random.value, Random.value);
            spin.GetChild(0).gameObject.SetActive(true);
            shouldRise = true;
        }
    }

    private void Update()
    {
        if (shouldRise)
        {
            spin.position = Vector3.Lerp(new Vector3(x, y, z), new Vector3(x, y + 50, z), Time.deltaTime * smoothFactor);
        }
    }

    public void OnDeselect(Transform selection)
    {
        var spin = selection.GetComponent<Transform>();
        if (spin != null)
        {
            shouldRise = false;
            spin.rotation = new Quaternion(0,0,0,0);
            spin.position = new Vector3(x, y, z);
            spin.GetChild(0).gameObject.SetActive(false);
        }

        settingValues = true;
    }
}
