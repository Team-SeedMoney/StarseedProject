using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public Text dialogText;
    public string dialog;
    public GameObject nextButton;

    private float delay = 0.05f;

    public void Start()
    {
        dialogText.text = " ";
        StartCoroutine(textPrint(delay));
    }

    IEnumerator textPrint(float d)
    {
        int count = 0;

        while (count != dialog.Length)
        {
            if (count < dialog.Length)
            {
                dialogText.text += dialog[count].ToString();
                count++;
            }

            yield return new WaitForSeconds(delay);
        }

        nextButton.SetActive(true);
    }

    public void OnNext()
    {
        SceneManager.LoadScene(2);
    }
}
