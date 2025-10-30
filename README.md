# 🎰 Wheel of Fortune

This project demonstrates modular architecture, dependency injection, and unit-tested gameplay systems through a simple **Wheel of Fortune** game.

---

## 🧩 Tech Stack & Tools

- [Unity 2021.3.45f2]([https://unity.com/releases/editor/whats-new/2022.3.25](https://unity.com/releases/editor/whats-new/2021.3.45f2#installs))  
- [Zenject](https://github.com/Mathijs-Bakker/Extenject)
- [DoTween](http://dotween.demigiant.com/) 

---

## 🕹️ Gameplay

To run the project: Assets/Scenes/Game.unity Open this scene in Unity and press **Play** to start the game.

---

## 🗂️ Project Structure

All main gameplay systems are located under:

### 🧱 CoreSystem
Contains shared systems and utilities, such as:
- Common helpers

### 💬 PopupSystem
Generic popup framework for displaying:
- **Reward**
- **Fail**

### ⚙️ [StateMachineSystem](https://www.youtube.com/watch?v=NnH6ZK5jt7o&t=476s)
A lightweight **state machine** that manages the overall game flow.

### 🎡 WheelOfFortuneSystem
Implements the main game logic.
- Built with an **MVC architecture** for testability
- Includes **unit tests**
