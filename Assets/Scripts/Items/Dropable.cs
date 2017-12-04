using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropable : MonoBehaviour {

    public List<GameObject> items;
    public List<int> weights;

    private void Start() {
        while (weights.Count != items.Count) {
            if (weights.Count > items.Count)
                weights.Remove(weights.Count - 1);
            if (weights.Count > items.Count)
                weights.Add(0);
        }
    }

    public void Drop() {
        int all = AllWeights();
        int rand = Random.Range(0, all);

        for(int i=0; i<items.Count; i++) {
            if(rand >= AllWeightsTo(i) && rand < AllWeightsTo(i+1)) {
                DropItem(i);
                break;
            }
        }
    }

    private int AllWeights() {
        int sum = 0;
        for(int i=0; i<weights.Count; i++) {
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

    private void DropItem(int i) {
        if(items[i] != null) {
            Instantiate(items[i], transform.position, transform.rotation);
        } 
    }
}
