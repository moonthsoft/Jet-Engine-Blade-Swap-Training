### Description:
Technical test for Capgemini of an app to train employees on the steps to change a jet engine blade.

A simplistic approach was chosen, with a camera on rails and very basic interaction, requiring only tapping on an object to interact with it, for two reasons:

The first is to prioritize simple controls that allow the application to be used by users unfamiliar with video games and interactive applications.

The second one is to reduce development costs and times, and fit better in the client's budget and schedule.

### Execution:
Unity Version: Unity 6.0.43f1

Open the "BladeSwapScene" or "Init" scene in the following folder: Assets/Scenes/BladeSwapScene.unity

### Links:
WebGL executable on Itch.io:

https://moonthsoft.itch.io/jet-engine-blade-swap-training

WebGL executable on GoogleDrive:

https://drive.google.com/file/d/154Iu25gw9Y813UO36WvbpbnDwl98uL6E/view?usp=sharing

Windows executable on GoogleDrive: 

https://drive.google.com/file/d/1jLCUJBuR4iv_hNapqPB35oeYgX5OBkkA/view?usp=sharing

Repository on GitHub:

https://github.com/moonthsoft/Jet-Engine-Blade-Swap-Training

Project on GoogleDrive:

https://drive.google.com/file/d/1HmN2RNe8rgFL4v3sHB6qyF4xUGuidcX6/view?usp=sharing

### Required Dependencies:
- Zenject
- TextMesh Pro

### Controls:
Click the mouse on the desired area, whether it's a UI element, to advance the text displayed on the screen, or to interact with the jet engine elements.

You can also tap the screen on mobile devices for the same effect.

Press the 'Esc' or 'P' keys to pause the game.

### Features:
- __Game logic:__ execution in order of certain steps to complete the blade change tutorial.
- __Interactables:__ components that use the physics engine to trigger a particular logic.
- __Camera on rails:__ Animated camera to modify its position.
- __UI:__ Different interfaces such as MainMenu, Pause or a Dialog that displays text char by char.
- __Custom shader:__ Shader created for this project called "Fan Old", which shows the old jet engine blade rusted and worn.
- __Animations:__ Different animations to show how the jet engine parts are disconnect and reconnect.
- __3D scene:__ 3D scene with adjustments to materials, lighting, and quality settings to make it look as good as possible without compromising performance.
- __Audio:__ Different sounds to emphasize the actions of the game.

### Project Structure:
The project is located in the Assets folder, with most subfolders divided into two main sections: Core and JEBST (acronym for Jet Engine Blade Swap Training).

Core contains generic elements that can be used in multiple games. JEBST contains elements specific to this project.

### The project's main folders in assets are:
- __Animations:__ Contains animations and animator controllers for the game.
- __Art__: Contains fonts, models, materials, textures, shaders, and sprites. The custom shader Fan Old is used to simulate the wear and rust of the blade.
- __Audio:__ Contains the game's sound effects.
- __Plugins:__ Contains third-party plugins used in the project, in this case, Zenject and TextMesh Pro.
- __Prefabs:__ Includes the prefabs used by the game, such as scene elements, and the managers instantiated by the ProjectContext.
- __Resources:__ Special Unity folder where the ProjectContext prefab is stored to enable dependency injection for managers.
- __Scenes:__ Contains the various game scenes:
  - __BladeSwapScene:__ The main gameplay scene, with the logic of changing the jet engine blade.
  - __Init:__ The first scene executed, which simply loads the Game scene.
  - __Loading:__ A temporary scene used when switching between scenes to avoid loading two at once.
  - __MainMenu:__ Main menu with the functions to start the game and exit the game (only in the Windows version).
- __Scriptables:__ Contains the ScriptableObjects of the project, in this case, ScriptableTexts, which contains the information of the texts that are shown to the player with the steps to follow.
- __Scripts:__ Contains all game scripts.
- __Settings:__ Default Unity folder for configuring and other visual quality elements. 

### Code Architecture:
The game architecture is based on managers, accessed through dependency injection using Zenject. The main managers are:
- __AudioManager:__ Handles sound effects and music playback.
- __InputManager:__ Handles player input.
- __LoadSceneManager:__ Manages scene transitions.
- __CameraManager:__ Manager in charge of managing the movement of the camera on rails to the desired positions.

In addition to the managers, we also highlight SceneLogic, which is responsible for executing the application logic in the proper order.

The classes that manage the UI logic: DialoguesUI, MainMenuUI, and PauseUI.

And the Interactable system, activated by physics, through the InteractionRaycaster class, which launches a raycast to check for any collisions with an Interactable when the corresponding input is activated.

### BladeSwapScene Scene Structure:
In the BladeSwapScene scene hierarchy, the following elements can be found:
- __GlobalVolume:__ URP post-production effects such as Bloom or Tonemapping are defined here.
- __SceneContext:__ Handles dependency injection for managers using Zenject.
- __EventSystem:__ Default Unity component for UI navigation (unused in this project).
- __Directional LightMain:__ Main light of the scene, which casts shadows.
- __Directional LightAuxiliar1:__ First auxiliary light, with a different direction than the main light, to illuminate areas that are becoming too dark. It does not cast shadows.
- __Directional LightAuxiliar2:__ Another auxiliary light to cover other areas. It also doesn't cast shadows.
- __CameraManager:__ Prefab with the game camera and CameraManager.
- __InteractionRaycaster:__ GameObject with the InteractionRaycaster to check if the Interactables are activated.
- __SceneLogic:__ GameObject with the SceneLogic, this class has to have references to the different Interactables, the DialogueUI and the CameraManager.
- __DialoguesUI:__ Interface to display the UI with texts to inform the player of the steps the player has to follow during the application.
- __PauseUI:__ Prefab for the Pause interface, also Pauses the game using Time.timeScale.
- __Floor:__ Plane with a texture to simulate floor.
- __Elements:__ Contains the Jet Engine and table models, as well as the Interactables and all necessary components such as collider and Animators.

### Credits:
This project was developed by Antonio García Tortosa.

The table and Jet Engine models, as well as the texts to be displayed to the player, were provided by Capgemini.

The floor texture is by Charlotte Baglioni:

https://polyhaven.com/a/granite_tile

The different sounds used in the game have been downloaded from Freesound:

https://freesound.org/people/MATRIXXX_/sounds/515823/

https://freesound.org/people/tjandrasounds/sounds/201590/

https://freesound.org/people/Dmitry_mansurev64/sounds/748027/

https://freesound.org/people/kickhat/sounds/264446/

https://freesound.org/people/AdamsArchive/sounds/379022/

https://freesound.org/people/esperar/sounds/170801/

https://freesound.org/people/CJspellsfish/sounds/669474/

https://freesound.org/people/sjturia/sounds/370905/

https://freesound.org/people/JanKoehl/sounds/85584/

https://freesound.org/people/Aiwha/sounds/190019/

https://freesound.org/people/BenjaminNelan/sounds/410361/
