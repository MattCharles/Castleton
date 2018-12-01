# Block Types
	- Cube: a base block
		- Weight: 1
		- Force: 1
	- Disk: 2 base blocks
		- Weight: .5
		- Force: 5
	- Pyramid: 2 base blocks
		- Weight: 3
		- Force: 2
		- Force(Tip): 5
	- Rectangle: 3 base blocks
		- Weight: 2
		- Force: 2
	- Sphere: 3 base blocks
		- Weight: 1
		- Force: 3
	- Cone: 5 base blocks
		- Weight: 1
		- Force: 5
		- Force(Tip): 15
	- Curved Cylinder: 5 base blocks
		- Weight: 10
		- Force: 3

# Start
	- Each player starts with 10 base blocks

# Zones
	- In Bounds
		- A block within bounds can be picked up and fired, if the player so choses
	- Out of Bounds
		- A block out of bounds can no longer be interacted with by the player, but is still counted on their platform
	
# Turn
	- Every 2 turns, each player receives new 5 base blocks
	- Each player can choose to craft new blocks with their base blocks
		- Once a block is crafted, those resources are spent and cannot revert back to base blocks
	- Each player must place all of their new blocks within the In Bounds zone
	- Each player gets the choice to fire a block, or pass
	
# Player Blocks
	- A block resists with its weight
	- After a block falls off the platform, it is lost and no longer counted towards the total

# Block Firing
	- A block hits opposing blocks with its force
	- After a fired block comes to rest, it disappears
	
# Win Condition
	- After 20 turns, the player with the most blocks on their platform wins