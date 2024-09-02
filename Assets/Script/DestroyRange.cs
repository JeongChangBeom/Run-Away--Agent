using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyRange : MonoBehaviour
{
    public GameObject destroyrange;
    public GameObject destroyImage;
    public Image destroyimage;
    void Update()
    {
        if(destroyrange.activeSelf == true)
        {
            StartCoroutine(DestroyStop());
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other);
        }
    }

    IEnumerator DestroyStop()
    {
        yield return new WaitForSeconds(1);
        while (destroyimage.color.a > 0)
        {
            var color = destroyimage.color;
            color.a -= (0.03f * Time.deltaTime);

            destroyimage.color = color;
            yield return null;
        }
        destroyrange.SetActive(false);
        destroyImage.SetActive(false);
        destroyimage.color = Color.white;
    }
}
