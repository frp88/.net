echo off
set caminho=%1
cd C:\Program Files\MySQL\MySQL Server 5.0\bin\
mysqldump -u root -peu patrimonio > %caminho%
cls