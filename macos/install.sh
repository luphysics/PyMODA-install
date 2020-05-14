echo "Downloading PyMODA. Please wait, this may take over a minute..."
curl -fSL --progress-bar "https://github.com/luphysics/PyMODA/releases/latest/download/PyMODA-macOS.tar.gz" -o pymoda.tar.gz

echo "Extracting PyMODA..."

mkdir -p ~/.pymoda/PyMODA
rm -r ~/.pymoda/PyMODA

tar -xvf pymoda.tar.gz -C ~/.pymoda/

echo "Cleaning up..."
rm pymoda.tar.gz

echo "Launching PyMODA..."
open ~/.pymoda/PyMODA/PyMODA.app --args --create-shortcut
