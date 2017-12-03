using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropable : MonoBehaviour {

    public List<GameObject> items;

    public List<int> weights;

    private void Awake() {
        items = new List<GameObject>();
        weights = new List<int>();
    }

    private void OnDestroy() {
        int all = AllWeights();
        int rand = Random.Range(0, all);

        for(int i=0; i<items.Count; i++) {
            if(rand >= AllWeightsTo(i) && rand < AllWeightsTo(i+1)) {
                Drop();
                break;
            }
        }
    }

    private int AllWeights() {
        int sum = 0;
        for(int i=0; i<items.Count; i++) {
            sum += weights[i];
        }
        return sum;
    }

    private int AllWeightsTo(int count) {
        int sum = 0;
        for (int i = 0; i < count; i++) {
            sum += weights[i];
        }
        return sum;
    }

    private void Drop() {

    }
}
