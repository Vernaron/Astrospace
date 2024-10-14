@tool
extends EditorPlugin


func _enter_tree():
	add_custom_type("SpaceObject", "RigidBody2D", preload("spaceobject.gd"), preload("icon.svg"))


func _exit_tree():
	remove_custom_type("MyButton")
