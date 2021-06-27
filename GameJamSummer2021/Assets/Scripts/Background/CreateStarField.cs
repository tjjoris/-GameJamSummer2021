using UnityEngine;

namespace FreeEscape.Background
{
    public class CreateStarField : MonoBehaviour
    {
        [SerializeField] private GameObject starPrefab;
        private float starMinSize = 0.01f;
        private float starMaxSize = 0.08f;
        private float mapXMin = -100f;
        private float mapYMin = -100f;
        private float mapXMax = 100f;
        private float mapYMax = 100f;
        private float starCount = 500f;
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
