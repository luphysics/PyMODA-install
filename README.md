# PyMODA installation

This repository contains installation scripts for PyMODA. 

## Installation instructions

This section describes how to install PyMODA using the scripts from this repository.

### Windows

Copy the following block of code, then paste into Powershell:

```powershell
Set-ExecutionPolicy Bypass -Scope Process -Force; 
iex ((New-Object System.Net.WebClient).DownloadString('https://raw.githubusercontent.com/luphysics/pymoda-install/master/windows/install.ps1'))
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
