using UnityEngine;

public class SpinSelectionResponse : MonoBehaviour, ISelectionResponse
{
    float x;
    float y;
    float z;

    float smoothFactor = 10f;

    bool settingValues = true;

    Transform spinning;

    public void OnSelect(Transform selection)
    {
        
        var spin = selection.GetComponent<Transform>();

        spinning = spin;

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
            //spin.position = Vector3.Lerp(new Vector3(x,y,z), new Vector3(x,y+100,z), Time.deltaTime * smoothFactor);
        }
    }

    private void FixedUpdate()
    {
        if(!settingValues) 
        {
            spinning.position = Vector3.Lerp(new Vector3(x, y, z), new Vector3(x, y + 100, z), Time.deltaTime * smoothFactor);
        }
    }

    public void OnDeselect(Transform selection)
    {
        var spin = selection.GetComponent<Transform>();
        if (spin != null)
        {
            spin.rotation = new Quaternion(0,0,0,0);
            spin.position = new Vector3(x, y, z);
            spin.GetChild(0).gameObject.SetActive(false);
        }

        settingValues = true;
    }
}
