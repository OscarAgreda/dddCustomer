@ECHO off
cls

ECHO Deleting all BIN and OBJ folders...
ECHO.


FOR /F "tokens=*" %%G IN ('DIR /B /AD /S bin') DO RMDIR /S /Q "%%G"
FOR /F "tokens=*" %%G IN ('DIR /B /AD /S obj') DO RMDIR /S /Q "%%G"
FOR /F "tokens=*" %%G IN ('DIR /B /AD /S node_modules') DO RMDIR /S /Q "%%G"



ECHO.
ECHO.BIN and OBJ folders have been successfully deleted. Press any key to exit.
pause > nul

