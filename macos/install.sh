echo "Downloading PyMODA. Please wait, this may take over a minute..."
curl -fSL --progress-bar "https://github.com/luphysics/PyMODA/releases/latest/download/PyMODA-macOS.dmg" -o PyMODA.dmg

echo "Mounting .dmg file..."
sudo hdiutil attach PyMODA.dmg

echo "Copying application..."
mkdir -p ~/.pymoda/PyMODA
rm -r ~/.pymoda/PyMODA
mkdir -p ~/.pymoda/PyMODA

cp -r /Volumes/PyMODA/PyMODA.app ~/.pymoda/PyMODA/

echo "Cleaning up..."
sudo hdiutil detach /Volumes/PyMODA
rm PyMODA.dmg

echo "Launching PyMODA..."
open ~/.pymoda/PyMODA/PyMODA.app
