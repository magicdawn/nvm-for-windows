fs = require('fs');
path = require('path')

var files = [
    '.git',
    'NVM.exe',
    'Ionic.Zip.dll',
    'Magicdawn.dll',
    "主页.txt",
    path.basename(__filename)
]

fs.readdirSync('.').forEach(function(f) {
    if(files.indexOf(f) < 0)
        fs.unlinkSync(f)
})