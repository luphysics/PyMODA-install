# PyMODA installation

This repository contains installers and installation scripts for PyMODA. 

## Installation instructions

This section describes how to install PyMODA.

### Windows

#### Installer

You can install PyMODA using the installer. [Click here](https://github.com/luphysics/pymoda-install/releases/latest/download/setup-win64.exe) to download it.

#### Powershell

You can also install PyMODA using Powershell:

```powershell
Set-ExecutionPolicy Bypass -Scope Process -Force; 
iex ((New-Object System.Net.WebClient).DownloadString(
'https://raw.githubusercontent.com/luphysics/pymoda-install/master/windows/install.ps1'
))
```

### Linux

Copy the following command into the terminal:

```bash
sh -c "$(curl -fsSL https://raw.githubusercontent.com/luphysics/pymoda-install/master/linux/install.sh)"
```

### macOS

Copy the following command into the terminal:

```bash
sh -c "$(curl -fsSL https://raw.githubusercontent.com/luphysics/pymoda-install/master/macos/install.sh)"
```

## Security

Since this repository hosts scripts which are downloaded and executed, security is of paramount importance.

The following security measures are in place:

- Only one GitHub account has write access. This account is protected by 2FA (TOTP and Yubikey only), and it has no fallback SMS number.
- Only GPG-signed commits are accepted.

## Developer notes

### Windows

#### PyMODA launcher

The PyMODA launcher is a wrapper around PyMODA, written in `C#`. To edit and build the launcher, open `windows/launcher/launcher.sln` in Visual Studio.

When the launcher is executed, it starts PyMODA with the command line arguments passed to the launcher. If PyMODA is not installed, it downloads the latest version of PyMODA and launches it automatically. 

#### Installer executable

Inno Setup is used to create an installer for Windows, which packages the PyMODA launcher. To build the installer, compile `windows/installer.iss` with Inno Setup; this will only work if the PyMODA launcher has been built in `Release` mode.
