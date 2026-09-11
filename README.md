# AstroVision 🔮✨

**AstroVision** is an Augmented Reality (AR) application built in Unity that brings zodiac cards to life. When a user scans a physical zodiac card with their device camera, AstroVision detects the marker and overlays a 3D panel directly onto the screen — displaying the user's **name**, **zodiac sign**, and **daily horoscope prediction** in real time. The goal is to turn a static print card into an interactive, personalized, and fun astrology experience.

## ✨ Features

- 📷 **Marker-based AR tracking** — recognizes printed zodiac cards using image target tracking.
- 🌌 **3D overlay panel** — renders prediction content in 3D space anchored to the scanned card.
- 🔢 **Personalized display** — shows the user's name and zodiac sign alongside their daily prediction.
- 📱 **Mobile-first AR experience** — designed to run on handheld devices via the camera feed.

## 🛠️ Tech Stack

- **Engine:** Unity
- **AR/Tracking SDK:** Vuforia (QCAR) — image target recognition and camera-based tracking
- **Language:** C# (Unity scripts)

## 📁 Project Structure

```
AstroVision/
├── Assets/            # Unity assets — scenes, scripts, prefabs, UI, and 3D panel content
├── Packages/          # Unity Package Manager dependencies
├── ProjectSettings/   # Unity project configuration
├── QCAR/              # Vuforia (QCAR) AR engine resources and image target database
├── .vscode/           # Editor configuration
└── .gitignore
```

## 🚀 Getting Started

### Prerequisites

- [Unity Hub](https://unity.com/download) with a Unity Editor version compatible with this project
- A [Vuforia Engine](https://developer.vuforia.com/) developer account and license key (required for AR image tracking)
- A physical or printed zodiac card set as the image target
- A mobile device (Android/iOS) or webcam for testing AR camera input

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/Simranchaprana/AstroVision.git
   ```
2. **Open in Unity**
   - Launch Unity Hub → *Add project* → select the cloned `AstroVision` folder.
3. **Configure Vuforia**
   - Add your Vuforia license key in `Edit → Project Settings → Vuforia Configuration`.
   - Ensure your zodiac card image targets are added to the Vuforia target database (in the `QCAR` folder).
4. **Run the project**
   - Open the main scene in `Assets/`.
   - Press **Play** in the Unity Editor to test with a webcam, or **Build & Run** to deploy to a mobile device for the full AR experience.

## 📖 Usage

1. Launch the app on a supported device.
2. Point the camera at a zodiac card.
3. Once the card is recognized, a 3D panel appears showing the associated name, zodiac sign, and daily prediction.
