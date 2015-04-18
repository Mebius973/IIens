# IIens

This project aims at creating a Windows Phone App for the students at the ENSIIE (French Engineering School).

As we don't have access to any API, we will parse the web site http://www.iiens.net/.

## Getting started

### Using Windows

To take part to this project you will need either the windows phone SDK which you can acquire for free online (just google it) or visual studio 2013 ultimate with the windows phone SDK installed (be sure to check it when installing visual studio).


## Git usage

We will follow the following workflow:

- each feature will have its own branch (if it doesn't exist, create it).
- while working on a feature, create a sub-branch from the feature branch. When finished: rebase and merge.
- any work made must have a related issue attached to you using zenhub. Don't hesitate to make the issue as small as possible (an issue called "make the app" would be rejected).

## Features

These are the current list of the features we will implement

### News

The web site iiens.net features a list of news which we are going to parse and siplay in the app.

### Emplois du temps

This is french for timetable: using the web site iiens.net (which we will parse once again), we will display timetable for students and teachers.

First we will keep it quite simple: select a promotion or a teacher name and the timetable is updated.
Then we will upgrade this by adding the selection of options.

### Twitter

We will display the ENSIIE twitter feed.