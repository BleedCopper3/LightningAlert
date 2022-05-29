#Lightning Alert

##How to Run:
- [For GoogleDrive] EXE is in LightningAlert/bin/Release/net6.0/LightningAlert.exe
	- CMD Command: LightningAlert.exe \<asset file\> \<lightning file\>
		- Ex: LightningAlert.exe ..\\..\\..\\..\assets.json ..\\..\\..\\..\lightning.json
- [For GoogleDrive/Github] It is also possible to do a build&run using dotnet run in LightningAlert folder
	- CMD Command: dotnet run \<asset file\> \<lightning file\>
		- Ex: dotnet run ..\assets.json ..\lightning.json

##Essay questions:
1. What is the time complexity for determining if a strike has occurred for a particular asset?
	- Given that converting lat/long to quadkey is O(1), and we are using Dictionaries to store assets, time complexity would be O(1) with space complexity at O(n).
2. If we put this code into production, but found it too slow, or it needed to scale to many more users or more frequent strikes, what are the first things you would think of to speed it up?
	- Threading to handle multiple inputs at one time
	- Caching lat/long to quadkey conversions

