@echo off
chcp 65001 > nul

setlocal

rem 设置目标路径
set target_path=D:\steam\steamapps\common\Stardew Valley\Mods

rem 获取当前脚本所在的文件夹路径
set current_folder=%~dp0

rem 获取当前文件夹名称
for %%F in ("%current_folder:~0,-1%") do set folder_name=%%~nxF

rem 检查目标路径下是否存在同名文件夹
if exist "%target_path%\%folder_name%" (
    rmdir /s /q "%target_path%\%folder_name%"
)

rem 复制当前文件夹到目标路径
xcopy "%current_folder%" "%target_path%\%folder_name%\" /e /i

rem 删除脚本
del "%target_path%\%folder_name%\install.bat"

endlocal
