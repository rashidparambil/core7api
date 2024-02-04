# Use the official .NET Core SDK as a parent image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

RUN git clone https://github.com/rashidparambil/core7api.git /app/src
RUN pwd && ls
# Copy the project file and restore any dependencies (use .csproj for the project name)
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./

# Publish the application
RUN dotnet publish -c Release -o out



# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

COPY --from=build /app/out/ .
RUN pwd && ls
CMD ls 
# Expose the port your application will run on
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "/app/core7api.dll"]