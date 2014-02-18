using UnityEngine;
using System.Collections;
using RTS;

public class HUD : MonoBehaviour {
	
	public GUISkin resourceSkin, ordersSkin, selectBoxSkin;
	
	private Player player;
	
	private const int ORDERS_BAR_WIDTH = 150, RESOURCE_BAR_HEIGHT = 40;
	
	/*** Game Engine Methods ***/
	
	void Start () {
		player = transform.root.GetComponent<Player>();
		ResourceManager.StoreSelectBoxItems(selectBoxSkin);
	}
	
	void OnGUI () {
		//we only want to draw a GUI for human players
		if(player.human) {
			DrawOrdersBar();
			DrawResourceBar();
		}
	}
	
	/*** Private Worker Methods ***/
	
	private void DrawOrdersBar() {
		GUI.skin = ordersSkin;
		GUI.BeginGroup(new Rect(Screen.width-ORDERS_BAR_WIDTH,RESOURCE_BAR_HEIGHT,ORDERS_BAR_WIDTH,Screen.height-RESOURCE_BAR_HEIGHT));
		GUI.Box(new Rect(0,0,ORDERS_BAR_WIDTH,Screen.height-RESOURCE_BAR_HEIGHT),"");
		GUI.EndGroup();
	}
	
	private void DrawResourceBar() {
		GUI.skin = resourceSkin;
		GUI.BeginGroup(new Rect(0,0,Screen.width,RESOURCE_BAR_HEIGHT));
		GUI.Box(new Rect(0,0,Screen.width,RESOURCE_BAR_HEIGHT),"");
		GUI.EndGroup();
	}

	public Rect GetPlayingArea() {
		return new Rect(0, RESOURCE_BAR_HEIGHT, Screen.width - ORDERS_BAR_WIDTH, Screen.height - RESOURCE_BAR_HEIGHT);
	}

	public bool MouseInBounds() {
		//Screen coordinates start in the lower-left corner of the screen
		//not the top-right of the screen like the drawing coordinates do
		Vector3 mousePos = Input.mousePosition;
		bool insideWidth = mousePos.x >= 0 && mousePos.x <= Screen.width - ORDERS_BAR_WIDTH;
		bool insideHeight = mousePos.y >=0 && mousePos.y <= Screen.height - RESOURCE_BAR_HEIGHT;
		return insideWidth && insideHeight;
	}
}
