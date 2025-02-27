# Random March Generator (LMB)

This application implements a **pseudo-random walk** using the **linear congruential method (LMB)**. The generated sequence of numbers depends on the input **seed**, which allows reproducing the same results with the same input data.

## Description of work

1. **User input**:
   - `Seed` — the initial number for the random number generator.
   - `Number of points` — the number of steps in a random march.
   - The **Generate** button starts the generation process and the drawing path.

2. **Random Number Generation Algorithm**:

   ```csharp
   X_{n+1} = (a * X_n + c) % m
   ```
   
   Where:
   - `a = 1664525` is the multiplier,
   - `c = 1013904223` is the increment,
   - `m = 2147483647` is the modulus (maximum int value).
   
   Each new number is limited to the range `[0, 20]` for the **X** and **Y** steps.

3. **Display**:
   - The list of coordinates of the path points is displayed in the `ListBox`.
   - The graphical representation of the path is drawn in the `PictureBox` with blue lines.

## Example of work (seed = 12, 100 steps)

The image below shows the output of the program with `seed = 12` and `count = 100`. The starting point is in the center, and the subsequent steps are generated pseudo-randomly.

![Screenshot_11](https://github.com/user-attachments/assets/45d88686-62fe-46bd-9576-9e56ee533c4a)


### Example of several points from the list:
```
(213, 207)
(214, 211)
(234, 192)
(227, 172)
(216, 187)
(233, 167)
(231, 173)
(231, 187)
(208, 200)
(224, 212)
...
```


