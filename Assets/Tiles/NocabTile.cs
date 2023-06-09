using UnityEngine;

public class NocabTile : MonoBehaviour
{
  public int type_;
  public string name_;
  public bool walkable = true;

  public NocabTile()
  {
    type_ = -1;
    name_ = "Default Name";
  }

  public NocabTile(int type, string name)
  {
    type_ = type;
    name_ = name;
  }

  public void onClick()
  {
    Debug.Log("Nocab hello from NocabTile OnClick()!");
    Debug.Log($"Tile clicked is of type: {this.name_}");
  }

  public void onEnter()
  {
    Debug.Log("Nocab hello from NocabTile onEnter()!");
    Debug.Log($"Tile entered is of type: {this.name_}");
  }
}
