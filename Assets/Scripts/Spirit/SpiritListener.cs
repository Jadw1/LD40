using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpiritAnimator))]
public class SpiritListener : MonoBehaviour {
	
	[System.Serializable]
	public class SingleArgumentEvent : UnityEvent<string> {}

	[System.Serializable]
	public class DoubleArgumentEvent : UnityEvent<string, int> {}

	[System.Serializable]
	public class OnSpecificFrameEvent {
		public string name;
		public int[] frames;
		public UnityEvent callbacks;
	}

	public DoubleArgumentEvent onFrameChangeEvent;
	public SingleArgumentEvent onAnimationEndEvent;
	public SingleArgumentEvent onAnimationStartEvent;

	public OnSpecificFrameEvent[] onSpecificFrameEvents;

	public void OnFrameChange(string name, int frame) {
		if (onFrameChangeEvent != null) {
			onFrameChangeEvent.Invoke(name, frame);

			foreach (OnSpecificFrameEvent e in onSpecificFrameEvents) {
				if (e.name == name) {
					for (int i = 0; i < e.frames.Length; i++) {
						if (frame == e.frames[i] && e.callbacks != null) e.callbacks.Invoke();
					}
				}
			}
		}
	}

	public void OnAnimationEnd(string name) {
		if (onAnimationEndEvent != null) onAnimationEndEvent.Invoke(name);
	}

	public void OnAnimationStart(string name) {
		if (onAnimationStartEvent != null) onAnimationStartEvent.Invoke(name);
	}
}
