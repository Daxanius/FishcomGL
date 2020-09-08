# FishcomGL
A C# graphics library that can render images, animations and games on any windows console such as Command prompt or PowerShell.

* [Intro](#intro)
* [Setup](#setup)
* [Usage](#usage)

## Intro
Fishcom is a tool that can render graphics on any console.
It's written in C# and powered by .NET Standard.

The idea came from me watching a guy make a graphics card out of breadboards.
Not having te resources to do that myself I decided to make a graphics engine using a concept
he utlised in his project (writing pixels from left to right top to bottom). At first it started simple
but I kep adding stuff and it kept "growing".

This is the result.

## Contribute or support
If you want to help improving Fishcom please consider forking the repository, making your changes, and proposing a Pull Request.

If you need any help you can contact me trough discord (Daxanius#1000).

## Setup

### Windows
- Download the library.
- Unpack the zip file.
- Create a new C# project in visual studio (console required, duh)
- Right click on the project name in the Visual Studio
- Click add --> project reference
- Select the .dll file of Fishcom
- Add 'using FishcomGL; in your program.cs file


## Usage

ComfishGL is a C# class library.

Here are the methods, data types and variables you can use.

```

Comfish 0.1.0
Copyright (C) 2020 Balder Huybreghs

Classes:
  -Window                         The Window class, parameters decide the size the Window will draw.

  -ColorHandler                   Has some methods to convert colors because Console colors are limited.

Data types:
  -Vector2                        Has an int x and an int y value. (coords)

  -Pixel                          Has a Vector 2 position value, has a char character value, has a string backGroundColor and stringForeGroundColor value.

Methods:
  Window:
    - Window(int windowSizeX, int windowSizeY)  Creates a Vector2 from it's int x and int y value to define the size of the drawing board.
    
    - SetChar(char character)                   Sets a character as default background character.
    
    - SetCameraPosition(Vector2 position)       Sets the position of the camera.
    
    - SetPixel(Vector2 position, *char character, *string backGroundColor, *string foreGroundColor) Creates a pixel on the scene.
    
    - GetWindowSize()                           Returns the window size as a Vector2.
    
    - GetCameraPosition()                       Returns the camera position as a Vector 2.
    
    - GetChar()                                 Returns the default character as char.
    
    - GetPixel(Vector2 position)                Returns the value of a pixel at a position.
    
    - ClearScreen()                             Clears all the pixels from the screen.
    
    - LoadImage(string path, *Vector2 position) Loads an image to render.
    
    - Draw(*bool overwrite)                     Draws the screen / window, if overwrite is true, it will overwrite the previous one.
  
  ColorHandler:
    - ClosestConsoleColor(byte r, byte g, byte b) Converts a color to the closest console color. Returns ConsoleColor convertable to string.
    
    - SetConsoleColor(string backGroundColor, string foreGroundColor) Sets Console.BackGroundColor and Console.ForeGroundColor via a string.
 

```
