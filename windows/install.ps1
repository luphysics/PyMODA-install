Write-Output "Downloading PyMODA..."

$url = "https://github.com/luphysics/pymoda-install/releases/latest/download/setup-win64.exe"

$targetDir = "$env:AppData\PyMODA"
$targetFile = "$targetDir\setup.exe"

$uri = New-Object "System.Uri" "$url"

$request = [System.Net.HttpWebRequest]::Create($uri)
$request.set_Timeout(15000)
$response = $request.GetResponse()

$totalLength = [System.Math]::Floor($response.get_ContentLength()/1024)
$responseStream = $response.GetResponseStream()
$targetStream = New-Object -TypeName System.IO.FileStream -ArgumentList $targetFile, Create

$buffer = new-object byte[] 10KB
$count = $responseStream.Read($buffer,0,$buffer.length)
$downloadedBytes = $count

while ($count -gt 0)
{
    $targetStream.Write($buffer, 0, $count)
    $count = $responseStream.Read($buffer,0,$buffer.length)
    $downloadedBytes = $downloadedBytes + $count
    Write-Progress -activity "Downloading file '$($url.split('/') | Select -Last 1)'" -status "Downloaded ($([System.Math]::Floor($downloadedBytes/1024))K of $($totalLength)K): " -PercentComplete ((([System.Math]::Floor($downloadedBytes/1024)) / $totalLength)  * 100)
}

$targetStream.Flush()
$targetStream.Close()
$targetStream.Dispose()
$responseStream.Dispose()

& "$targetFile" /VERYSILENT

Write-Output "Cleaning up..."
Start-Sleep -Seconds 4

rm $targetFile

Write-Output "Exiting."