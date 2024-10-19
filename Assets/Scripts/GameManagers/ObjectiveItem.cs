using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveItem : MonoBehaviour
{
    public ProgressManager progressManager;
    public PatientInformationUI patientInformationUI;
    public string patientName;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.tag == "Player")
        {
            progressManager.itemCount += 1;

            patientInformationUI.ChangePatientName(patientName);

            Destroy(gameObject);
        }
    }
}