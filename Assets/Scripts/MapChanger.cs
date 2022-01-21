using UnityEngine;
using UnityEngine.SceneManagement;

public class MapChanger : MonoBehaviour
{
    public string nextMap;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PhotonNetwork.LoadLevel(nextMap);
        }
    }
}
