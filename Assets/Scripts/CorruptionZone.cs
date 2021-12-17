using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptionZone : GameBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameEvents.ReportCorruptionStart();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameEvents.ReportCorruptionStop();
        }
    }
}
