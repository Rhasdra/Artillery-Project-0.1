# Artillery-Project
Worms Inspired Artillery Game
To-Do list and planning board: https://miro.com/app/board/uXjVOC7Wvj8=/?share_link_id=887270065442

## Current Struggles:
I feel somewhat confident in my ability to make the scripts work, but I need some guidance in the whole architecture and organization of the project

### • Referencing objects and scripts
This is the biggest confusion so far. I've rewritten the code a couple times already and each iteration I made the references a little cleaner, but it still is inconveninet to manage. I don't know how a "proper project" looks like in this department, so I would like if you could point me in that direction

Here's some of the problems:

**GameManager > Spawner**  
I feel like I must have a spawner so everything initializes in order and I'm able to properly reference the objects between themselves. Without the spawner sometimes the objects would load out of order and I get errors.
This looks a bit spaghett-y, having to manually order and set the entire scene up. Is there an easier solution?

**Events**  
I started adding events (and still am in the proccess of adding them) to reduce the amount of referencing I have to do, but this feels even more disorganized. Since I can only call an event within its own script, I have a bunch of events scattered around and every one of those scripts are public or static. This looks wrong.
Is there a way to have a single object that takes care of all the events?


### • Interfaces
I kind of understand them and I'll try to add some to the shot and character. I'll probably rewrite the whole thing so I can properly implement it and also solve the whole State Machine situation
