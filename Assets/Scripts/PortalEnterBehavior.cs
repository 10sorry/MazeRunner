using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PortalEnterBehavior : MonoBehaviour
{
    public TextMeshProUGUI tmpro;
    public GameObject otherPortal;
    private float alpha = 1f;

    private void Start()
    {
        tmpro.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            StartCoroutine(BlinkText());
            StartCoroutine(WaitForSpace(player));
            tmpro.enabled = true;
        }
    }
    
    private IEnumerator BlinkText()
    {
        while (true)
        {
            alpha = 1f;
            while (alpha > 0f)
            {
                alpha -= Time.deltaTime * 2f;
                tmpro.color = new Color(tmpro.color.r, tmpro.color.g, tmpro.color.b, alpha);
                yield return null;
            }

            alpha = 0f;
            while (alpha < 1f)
            {
                alpha += Time.deltaTime * 2f;
                tmpro.color = new Color(tmpro.color.r, tmpro.color.g, tmpro.color.b, alpha);
                yield return null;
            }
        }
    }

    private IEnumerator WaitForSpace(Player player)
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        player.transform.position = otherPortal.transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            tmpro.enabled = false;
        }
    }
}    