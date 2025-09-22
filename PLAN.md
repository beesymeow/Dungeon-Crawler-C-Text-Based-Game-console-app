# Plan For Game

Fallen down into dungeon have to find way out.

# Need

- Battle system
- Player data (class, name, inventory )
- Player actions (heal, view inventory, cast spell )

# Player class (called Role because confuse with c# class)

- Player choose class --> Need to be able to have items --> Need to have items created

# Stats
- Player stats affect damage they deal with each weapon, how much damage they can take and resistance to it, and finally a stat with small chance for a unique effect.  <br> <br>  

 Strength: Modifies the amount of damage a melee weapon will deal. <br>
 Attunement: Modifies the amount of damaga a spell will deal. <br>
 Dexterity: Modifies the amount of damage a physical ranged weapon will deal. <br>
 Vigor: Increase the amount of hit points the player has. <br>
 Defence: Decrease the damage taken by the player from attacks. <br>
 Resolve: Unique effect depending on players role. <br> <br> 
 Soldier: Small chance to endure damage that would bring you below 1hp. <br>
 Mage: Small chance to cast divinely powerful magic and remove the current enemy from existance. <br>
 Archer: Small chance to dodge the current attack negating all damage that would have been taken.

# Items 
The following are items to be implemented, each item should have its own class with the unique properties it needs.
- Weapons: <br> Swords, Staves, Bows.
- Armour: <br> Light, Medium, Heavy.
- Restoration: <br> Health, Mana.
- Ammo: <br> Arrows/Bolts. Different type of arrow/bolt can have effect/ damage modifier.

# Enemies
- Have Names 
- Have health 
- Have damage 
- Maybe different types


# Common Words List
The class of common words lists are used to help identify words that the player might enter similar to the "correct" answer for the code. <br><br>

# Battle Sequence
Battle sequence: Player vs Enemy <br><br> Player attack then enemy attack <br> player health - enemy damage = new player health 

# Leaderboard
Have leaderboard "player1.playerName" defeated "totalBattleCount" enemies and died to "enemylist[totalbattlecount]"


# Extra 
Ankh emilie note next game egypt secret