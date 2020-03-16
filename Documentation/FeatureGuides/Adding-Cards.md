# Guide for adding new cards to the game

Adding new cards is a simplified process that follows a few basic steps to achomplish. Below you will find a quick reference for adding cards that can be used once you have worked through the complete guide below the quick steps.

## Quick Reference
1. Create a new C# script in the "Scripts/Cards/CardLogic" folder
2. Remove the mono behaviour inheritance from the script
3. In it's place inherit from class "Card"
4. Create a constructor, inside of it set the fixed values for the card (IE title, description etc)
5. over ride the play function and add custom logic that will be used when resolving this specific card
6. Add any more specific member variables and set them to their default value in the constructor
7. You have now made a new card (Note: this guide will be updated with the introduction of the card registry base which will handle the creation of specific card instances in the future)