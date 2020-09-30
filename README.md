# Fuck
Fix command line spelling errors like it's 1999.

![demo](http://i.imgur.com/DIiSuia.gif)

# Installation Instructions

Add the directory fuck.exe is located to your [path](http://www.computerhope.com/issues/ch000549.htm), then put the following lines in your .bashrc file:

```
shopt -s histappend
PROMPT_COMMAND="history -a;$PROMPT_COMMAND"
```

# Why?

I ordered my lunch at work late so I decided to spike out a program to fix command line spelling errors in my newfound free time.

This project was inspired by [The Fuck](https://github.com/nvbn/thefuck).
