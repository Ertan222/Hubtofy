#! /bin/bash

BLUE="\033[0;34m"

dotnet run --project ./src/ &
dotnet run --project ./Countrofy/ &
