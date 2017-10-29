FROM microsoft/aspnetcore:2.0.0
ARG source
WORKDIR /app
EXPOSE 9100
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "clby-ufop-NPOI.dll"]
