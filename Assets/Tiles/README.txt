The development flow for using the tiles here. Using the Grass tile as an example:

Step 0:
Create a new Tile asset (with a sprite).
Note that the number of pixels is important, and generally I'm sticking to
32x32 pixel size.
See Tiles/Grass/Grass_32

Step 1:
Make a NocabTile script for this tile type.
Create a new Game Object prefab that has the Nocab Tile script attached to the
Game Object. Then fill out the relevant details associated with the tile to the
public fields of the Nocab Tile script, and/ or extend the Nocab Tile script, and/or
make a new script that inherits from NocabTile
Name this Prefab "{TileName}NocabTile", and place it near the Tile object created in step 0
See Tiles/Grass/GrassNocabTile

Step 2:
Map the script from Step 1 to the Tile from Step 0.
Create a new Game Object and attach a Tile To Scrip Mapper scrip to it. 
Add the script from step 1 to the field titled Script For Tiles, and add the 
tile to the array titled Tiles. The idea here is that multiple tiles may have 
the same underlying Script logic. So there might be a several different looking
"grass" tiles, but they all logically behave the same. 
See the SampleScene/Grid/GrassTilesToScript object

Step 3:
Set up the TIle Manager and other logical components
Add the following scripts to the top level Grid object for a Tile Map:
 - Tile Manager
 - Anything else (like MouseOverTileTracker)

3.1 Set up Tile Manager
The Tile Manager script is the top level component that aggregates all the 
TilesToScript pairs created in Step 2.
At time of writing this documentation, a human has to manually drag all the 
Tiles to Script pairs (from step 2) into the Tile Manager 'Maps' field. 
But eventually I'll update it so the Tile Manager will walk over all it's children
and find all the relevant TileToScript pairs and automatically grab that data

3.2 Set up the Mouse Over Tile Tracker
At time of writing there is no human set up for this. 
But I'm nothing it here for the sake of completion. I'm not 100% sure I want to keep this
as a separate script and might refactor it into the Tile Manager script.


