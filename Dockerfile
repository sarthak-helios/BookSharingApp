# syntax=docker/dockerfile:1

# Use the .NET SDK image for building the application
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

# Copy source code into the container
COPY . /source

# Set the working directory
WORKDIR /source/BookSharingApp

# Define the target architecture
ARG TARGETARCH

# Build the application with cache optimization for NuGet packages
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet publish -a ${TARGETARCH/amd64/x64} --use-current-runtime --self-contained false -o /app

################################################################################
# Runtime Stage
################################################################################
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final

# Set the working directory
WORKDIR /app

# Enable full globalization support
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=0

# Install ICU (International Components for Unicode) for culture-specific operations
RUN apk add --no-cache icu-libs

# Copy the built application from the "build" stage
COPY --from=build /app .

# Ensure wwwroot/images directory exists and has correct permissions
RUN mkdir -p /app/wwwroot/images && chmod -R 777 /app/wwwroot/images

# Switch to a non-root user
ARG APP_UID=1000  # Default user ID if not set externally
RUN adduser -D -u $APP_UID appuser
USER appuser

# Define the entry point for the application
ENTRYPOINT ["dotnet", "BookSharingApp.dll"]
