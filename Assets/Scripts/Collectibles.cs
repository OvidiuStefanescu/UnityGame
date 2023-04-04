using UnityEngine;
using TMPro;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private int score = 1;
    [SerializeField] private Material positiveScoreMaterial;
    [SerializeField] private Material negativeScoreMaterial;
    [SerializeField] private MeshRenderer mr;
    [SerializeField] private TextMeshPro text;

    private void Start()
    {
        UpdateState();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var playerComponent = other.GetComponent<PlayerController>();
            playerComponent.ChangeScore(score);
            Destroy(gameObject);
        }
    }

    private void UpdateState()
    {
        if (score > 0)
        {
            mr.material = positiveScoreMaterial;
        }
        else
        {
            mr.material = negativeScoreMaterial;
        }

        text.SetText(score.ToString());
    }

    public void RandomizeScore(int newScore)
    {
        score = newScore;
        UpdateState();
    }
}
