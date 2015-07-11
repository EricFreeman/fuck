# fuck
Fix command line spelling errors like it's 1999.

I ordered my lunch at work late so I decided to spike out a program to fix my command line spelling errors in my free time.

# Installation Instructions

Put the following lines in your .bashrc file:

```
shopt -s histappend
PROMPT_COMMAND="history -a;$PROMPT_COMMAND"
```

Next, add the location of fuck.exe to your path.