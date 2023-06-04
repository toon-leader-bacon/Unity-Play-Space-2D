using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelStore {

	// TODO: Make this read only? 
	public Dictionary<Vector2Int, Color> pixels = new Dictionary<Vector2Int, Color>();


	public PixelStore() { }

	public PixelStore(PixelStore other) {
		foreach (KeyValuePair<Vector2Int, Color> kvp in other.pixels) {
			// NOTE: Vector2Int and Color are structs => pass by value => copy on funciton call which is good
			this.pixels.Add(kvp.Key, kvp.Value);
		}
	}

	public void SetPixel(Vector2Int point, Color c) {
		this.pixels[point] = c;
	}

	public void SetPixel(int x, int y, Color c) {
		// TODO: Vector2Int pooling here 
		this.SetPixel(new Vector2Int(x, y), c);
	}

	public void Translate(Vector2Int translationVector) {
		this.Translate(translationVector.x, translationVector.y);
	}

	public void Translate(int x, int y) {
		// Apply the translationVector to every point in this PixelStore
		Dictionary<Vector2Int, Color> newPixelStorage = new Dictionary<Vector2Int, Color>();
		foreach (KeyValuePair<Vector2Int, Color> kvp in this.pixels) {
			Vector2Int oldPosition = kvp.Key;
			Vector2Int newPos = new Vector2Int(oldPosition.x + x, oldPosition.y + y);
			newPixelStorage.Add(newPos, kvp.Value);
		}
		this.pixels = newPixelStorage;
	}

	public void reflect45() {
		// Reflects every point across the y=x axis
		Dictionary<Vector2Int, Color> newPixelStorage = new Dictionary<Vector2Int, Color>();
		foreach (KeyValuePair<Vector2Int, Color> kvp in this.pixels) {
			Vector2Int oldPosition = kvp.Key;
			Vector2Int newPos = new Vector2Int(oldPosition.y, oldPosition.x);
			newPixelStorage.Add(newPos, kvp.Value);
		}
		this.pixels = newPixelStorage;
	}

	public void merge(PixelStore other) {
		// Merge a copy of the other PixelStore into this one. 
		// The other PixelStore will be unmodified
		foreach (KeyValuePair<Vector2Int, Color> kvp in other.pixels) {
			this.pixels[kvp.Key] = kvp.Value;
		}
	}
}