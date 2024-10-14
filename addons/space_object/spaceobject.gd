@tool
extends RigidBody2D
@export var Functions : Array[String] = []
var highlighted : bool=false
var openMenu: bool=false
var list = ItemList.new()
 
func _enter_tree():
	mouse_entered.connect(entered)
	mouse_exited.connect(exited)
	list.name="List"
	list.size=Vector2(256,256)
	list.visible=false
	list.mouse_filter=Control.MOUSE_FILTER_PASS
	add_child(list)
	$List.mouse_entered.connect(entered)
	$List.mouse_exited.connect(exited)
	for item in Functions:
		$List.add_item(item)
func entered():
	highlighted = true
	print("Enter")
func exited(): 
	highlighted = false
	print("Exit")
	
func _input(event):
	if Input.is_action_pressed("primary_select") and highlighted and not openMenu:
		print("Clicked!")
		openMenu=true
		input_pickable=false;
	elif Input.is_action_pressed("primary_select") and not highlighted and openMenu:
		print("Unclicked!")
		openMenu=false
		input_pickable=true;
	list.visible=openMenu
