# Void Runner
Void Runner is a virtual reality endless runner game inspired by vaporwave elements. It was built using C#, and Unity. Void Runner is releasing on Steam November 11, 2022. Steam page coming soon.

### Tables of content
[Roadmap](#roadmap)  
[How it works](#how-it-works)  
[Motivation](#motivation)  
[Challenges](#challenges)  
[What I would change](#what-i-would-change)

## Roadmap
* Clear copyrighted assets - **(October 1st - October 8th)**
* Make final logo - **(October 9th - October 13th)**
* Collect screenshots and other promotional material - **(October 14th - October 21st)**
* Host Steam store page - **(October 22nd - October 23rd)**
* More play testing - **(October 24th - October 31st)**
* Bug fixes after play testing - **(November 3rd - November 10th)**
* Release Void Runner - **(November 11th)**

## How it works
### Interaction
The way the user interacts with this application is through a VR headset, VR controllers, and body movement. Check out some early alpha gameplay footage by clicking the image below!

[![Early alpha gameplay footage!](https://img.youtube.com/vi/RnADjkk5lF4/maxresdefault.jpg)](https://youtu.be/RnADjkk5lF4)

### Obstacle Pooling
One of the biggest considerations I had while creating this title was performance. The PC I was developing this project on just barely met the minimum specs to run VR, so I knew I had to be mindful of this. A big leap made early on to satisfy this was the implementation of an obstacle pooling system. Essentially, at the start of each game, a set of 30 obstacles are created (6 of each type). As the player passes the incoming obstacles, they become deactivated, their position is reset to its initial value, and a flag is set to let the obstacle pooler know the obstacle is ready to be placed again. This feature improves performance by eliminating the need for an obstacle to be instantiated every time one is needed to be placed.

## Motivation
My biggest motivation for this project was to create a fun, engaging, and visually intersting virtual reality experience that I could release on Steam.

## Challenges
My biggest challenge while developing this project was testing features as I was implementing them. It was a little combersome to have to go back and forth between jumping around wearing a VR headset and sitting down at my desk combing through documentation to solve a bug.

## What I would change
The main thing I would change about this project (And I plan to in future updates) is the addition of power up items, much like other games in the endless-runner genre have, to keep the gameplay fresh. Two ideas for power ups I had are a powerup that lets you see through incoming obstacles to see what the obstacles behind them are and a power up that shields you from a single source of damage.
