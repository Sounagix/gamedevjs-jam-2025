# Echoes of Nexus  
**Game Design Document [Gamedev.js GameJam 2025](https://itch.io/jam/gamedevjs-2025)**

---

## Overview
A platformer where you create Echoes (frozen copies of yourself) using Nexus energy. These Echoes inherit your momentum, enabling creative movement and puzzle-solving. Nexus energy is limited and must be managed for clone creation and movement buffs.

---

## Core Mechanics

### 1. Nexus Energy
- **Create Echoes:** Use Nexus to create echoes; they freeze in time completely.
- **Movement Boosts:** Use Nexus to charge a super jump or super slide. The more you charge, the more powerful the effect (with a cap).
- **Explosives:** Nexus energy can attack enemies like a laser or create explosions that push Echoes and Enemies.
- **Nexus Regeneration:** Regenerates at a constant rate, but stops if an Echo is alive.

### 2. Echoes
- **Frozen Copies:** Echoes are frozen snapshots of the player.
- **Actionable:** Can hold switches, trigger mechanisms, or distract enemies.
- **Movement:** Cannot move on their own but are affected by gravity and explosions (not by pushing).
- **Respawn:** If the player dies, they respawn as the last Echo made, with a Nexus regen cooldown.
- **Death:** Echoes can be killed and have the same health the player had when they were created.

---

## Progression

### 1. Levels
- Early levels explain 2-3 mechanics each.
- Later levels mix mechanics into **fast-paced** or **puzzle-focused** challenges.

### 2. Modifiers
- **Temporary Nexus Regeneration:** Double Nexus regeneration even with Echoes alive.
- **Nexus Boosts:** Provides extra Nexus energy (no regeneration help).
- **Storage:** Increases Nexus storage capacity.

### 3. Collectibles
- **Crystals:** Simple collectible, acts as score (potentially for purchases).

### 4. Obstacles
- **Gates:** Opened by giving up Nexus Energy or Pressure Plates.
- **Spikes:** Kill the player on touch.
- **Energy Siphons:** Drain player's energy.
- **Power Disrupters:** Areas where Echoes can't exist.
- **Breaking Platforms:** Collapse if stood on for too long.
- **Pendulums:** Swinging obstacles that deal heavy damage and knockback.
- **Nexus Barriers:** Disappear when hit with Nexus Projectiles.
- **Flames:** Damage the player and Echoes.
- **Bushes:** Slow and damage the player.

### 5. Enemies
- **Protectors:** Knights using swords to attack.
- **Chrono Knights:** Can only be killed from behind; prioritize Echoes over the player; shoot red laser projectiles.
- **Phasers:** Soul-like enemies that levitate, pass through walls, and attack with Nexus powers.
- **Nexus Leeches:** Attach to the player to drain Nexus Energy.
- **Golems:** Tough enemies only affected by Nexus explosions; invulnerable to projectiles.

---

## Controls

- **Movement:**  
  - A / Left Arrow = Move Left  
  - D / Right Arrow = Move Right  
  - Spacebar = Jump  

- **Create Echo:**  
  - E

- **Movement Buffs:**  
  - Hold Q while moving for specific actions  
  - Spacebar + Q = Super Jump  
  - A / Left Arrow + Q = Super Slide Left  
  - D / Right Arrow + Q = Super Slide Right  

- **Projectile & Explosion:**  
  - Right Click = Throw Nexus Projectile towards cursor  
  - Hold Right Click = Throw Nexus Explosion

---