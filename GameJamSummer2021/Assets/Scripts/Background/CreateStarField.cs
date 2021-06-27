using UnityEngine;

namespace FreeEscape.Background
{
    public class CreateStarField : MonoBehaviour
    {
        [SerializeField] private GameObject starPrefab;
        private float starMinSize = 0.01f;
        private float starMaxSize = 0.08f;
        private float mapXMin = -40f;
        private float mapYMin = -40f;
        private float mapXMax = 40f;
        private float mapYMax = 40f;
        private float starCount = 300f;
        // Start is called before the first frame update
        void Start()
        {
            for (int i=0; i<starCount; i++)
            {
                Vector3 starPos = new Vector3(Random.Range(mapXMin, mapXMax), Random.Range(mapYMin, mapYMax), 0);
                GameObject star = Instantiate(starPrefab, starPos, Quaternion.identity);
                float starScale = Random.Range(starMinSize, starMaxSize);
                star.transform.localScale = new Vector3(starScale, starScale, starScale);
                star.transform.parent = gameObject.transform;
            }
        }
    }
}
