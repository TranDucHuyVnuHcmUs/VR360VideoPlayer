# VR360VideoPlayer
Play video on a sphere, then go inside it to watch. Maybe add some other controls too.

# Configurations
This project is made and tested in:
- Unity 2022.2.14f1
- Google Cardboard VR SDK (newest, 5/5/2023)

# How to do?
If anyone's interested, please send me a DM, or you can create an issue in this repo, so I'll consider making a video about building this project from scratch.

- Find/Make 360 videos and import them to Unity.
- Follow the guide from [Google Cardboard VR SDK](https://developers.google.com/cardboard/develop/unity/quickstart) (remember to follow it fully!)
- Copy the important components/objects from Google Cardboard VR SDK's sample into your own scene, such as CardboardStartup component, Main Camera with TrackedPoseDriver component, CardboardReticlePointer...
- Add a sphere, attach VideoPlayer component on the sphere, attach a VideoClip to the VideoPlayer component
- Make an unlit shader, and add line "Cull Front" to allow Unity to show the inside of the sphere, then make a material based on this shader, and attach this material onto the sphere.
- Bring the camera to the center of the sphere.
- Make Dropdown and time Slider UI. Link these two's on value changed event to the function that choose the video, or control the current playing time of the VideoPlayer.
- Add 2 cube, one for playing/resuming video and other for pausing the video.
- Change the layer of these 2 cube into the layer that you want CardboardReticlePointer to act on.
- Implement gaze interaction component, using 2 float variable (gazing time and threshold) to allow user to look at the object and call the event once the gazing time are longer or equal the time threshold. 

# License and Attribution
The project will apply the main license as shown on the project's main page, expect for items taken by other sources, as written below:

## Script
- [Making a shader for an inside out sphere unlit? - Unity Answers](https://answers.unity.com/questions/1155090/making-a-shader-for-an-inside-out-sphere-unlit.html) (the shader "InsideObjectShader" in Assets/Material)

## Youtube videos
To test, this project uses videos from Youtube:

- [Vietnam in 360](https://youtu.be/VprMcdyNOeI)
- [Vietnam’s Paranormal Portal _ Hanoi, Vietnam 360 VR Video _ Discovery TRVLR](https://youtu.be/Q62WHDEqhAs)

You must not use these assets for any other purpose that violate the licenses of these assets. Please replace these assets with your own files that you are allowed to use legally.