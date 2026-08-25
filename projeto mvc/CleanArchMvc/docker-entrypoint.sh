#!/bin/sh
set -e

dotnet restore CleanArchMvc.slnx

dotnet ef database update \
  --project ClanArchMvc.Data/ClanArchMvc.Infra.Data.csproj \
  --startup-project CleanArchMvc.WebUI/CleanArchMvc.WebUI.csproj

exec dotnet watch \
  --project CleanArchMvc.WebUI/CleanArchMvc.WebUI.csproj \
  run \
  --no-launch-profile \
  --urls http://0.0.0.0:8080
