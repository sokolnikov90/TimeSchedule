:: Положите и запустите файл в директории web-сервисов для создания ".wsdl" файлов.

@echo off

for %%f in (*.asmx) do (
	start /wait "" C:\"Program Files"\"Microsoft SDKs"\Windows\v7.0A\bin\disco.exe /out:%CD% "http://127.0.0.1/webservice/%%f"
)

del "%CD%\*.disco"
del "%CD%\*.discomap"