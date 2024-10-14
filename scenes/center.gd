extends Node2D
var conf
var saves
# Called when the node enters the scene tree for the first time.
func _ready():
	if !FileAccess.file_exists("user://config.txt"):
		genConfig()
	getConfig()
	print(saves)
		

func genConfig():
	var _saves=["save_01"]
	conf = FileAccess.open("user://config.txt",FileAccess.WRITE)
	print(conf)
	conf.store_var(saves)
	conf.close()
func getConfig():
	conf = FileAccess.open("user://config.txt",FileAccess.READ)
	saves = conf.get_var()
	conf.close()
func saveConfig():
	conf = FileAccess.open("user://config.txt",FileAccess.WRITE)
	conf.store_var(saves)
	conf.close()
func getSave(_saveName):
	pass
func overwriteSave(_saveName):
	pass
	
# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta):
	pass
