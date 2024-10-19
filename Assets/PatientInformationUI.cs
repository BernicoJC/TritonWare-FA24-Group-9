using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientInformationUI : MonoBehaviour
{
    public Image Image;
    [SerializeField]
    private List<Sprite> Images = new List<Sprite>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.transform.parent.gameObject.SetActive(false);
        }
    }
    public void ChangePatientName(string name)
    {
        if (name == null)
        {
            return;
        }

        this.transform.parent.gameObject.SetActive(true);

        if (name == "Wow")
        {
            Image.sprite = Images[0];
        }

    }
}
