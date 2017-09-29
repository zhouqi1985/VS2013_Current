@echo 安装服务
sc create Platform_PetFeedEventsService DisplayName= "Platform_PetFeedEventsService" binpath= "D:\Publish\Services\Platform_PetFeedEventsService\PetFeedEventsService.exe" start= demand
pause